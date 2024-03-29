﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using Sensit.TestSDK.Calculations;
using Sensit.TestSDK.Exceptions;

namespace Sensit.TestSDK.Protocols
{
	/// <summary>
	/// Base abstract class for Modbus master instances
	/// </summary>
	public abstract class ModbusMaster : ModbusBase
	{
		#region Fields

		// Transmission buffer
		protected List<byte> _sendBuffer = new List<byte>();

		// Reception buffer
		protected List<byte> _receiveBuffer = new List<byte>();

		// Modbus transaction ID (only Modbus TCP/UDP)
		protected ushort _transactionID = 0;

		/// <summary>
		/// Interchar timeout timer
		/// </summary>
		protected Stopwatch _timeoutStopwatch;

		#endregion

		#region Properties

		/// <summary>
		/// Remote host connection status
		/// </summary>
		public bool IsConnected { get; set; } = false;

		#endregion

		#region Constructor

		/// <summary>
		/// Constructor
		/// </summary>
		public ModbusMaster()
		{
			// Set device type.
			_deviceType = DeviceType.Master;

			// Initialize interchar timeout timer.
			_timeoutStopwatch = new Stopwatch();
		}

		#endregion

		#region Connection Methods

		/// <summary>
		/// Open connection
		/// </summary>
		public abstract void Connect();

		/// <summary>
		/// Close connection
		/// </summary>
		public abstract void Disconnect();

		#endregion

		#region Send/Receive Methods

		/// <summary>
		/// Function to send trasminission buffer
		/// </summary>
		protected abstract void Send();

		/// <summary>
		/// Function to read a byte from a device
		/// </summary>
		/// <returns>Byte read or -1 if no data are present</returns>
		protected abstract int ReceiveByte();

		#endregion

		#region Helper Methods

		/// <summary>
		/// Execute a query to a destination master
		/// </summary>
		/// <param name="deviceAddress">Salve device address</param>
		/// <param name="messageLength">Message lenght</param>
		protected void Query(byte deviceAddress, ushort messageLength)
		{
			// Build the message according to the selected protocol.
			switch (_connectionType)
			{
				case ConnectionType.SerialASCII:
					// Insert device address in front of the message.
					_sendBuffer.Insert(0, deviceAddress);

					// Calculate message LCR.
					byte[] lrc = GetASCIIBytesFromBinaryBuffer(new byte[] { Checksum.LRC(_sendBuffer.ToArray()) });

					// Convert the message from binary to ASCII.
					_sendBuffer = GetASCIIBytesFromBinaryBuffer(_sendBuffer.ToArray()).ToList();

					// Add LRC at the end of the message.
					_sendBuffer.AddRange(lrc);

					// Insert the start frame chararacter at the start of the message.
					_sendBuffer.Insert(0, Encoding.ASCII.GetBytes(new char[] { AsciiStartFrame }).First());

					// Insert stop frame characters at the end of the message.
					char[] endFrame = new char[] { AsciiStopFrame1ST, AsciiStopFrame2ND };
					_sendBuffer.AddRange(Encoding.ASCII.GetBytes(endFrame));
					break;

				case ConnectionType.SerialRTU:
					// Insert device address in front of the message.
					_sendBuffer.Insert(0, deviceAddress);

					// Append CRC16 to end of message.
					_sendBuffer.AddRange(BitConverter.GetBytes(Checksum.Crc16(_sendBuffer.ToArray())));

					// Wait for interframe delay.
					Thread.Sleep(_interframeDelay);
					break;

				// For Modbus TCP/UDP, build MBAP header.
				case ConnectionType.UDPIP:
				case ConnectionType.TCPIP:
					// Transaction ID (incremented by 1 on each trasmission)
					_sendBuffer.InsertRange(0, GetBytes(_transactionID));

					// Protocol ID (fixed value)
					_sendBuffer.InsertRange(2, GetBytes(ProtocolID));

					// Message length
					_sendBuffer.InsertRange(4, GetBytes(messageLength));

					// Remote unit ID
					_sendBuffer.Insert(6, deviceAddress);
					break;
			}

			// Send the message.
			Send();

			// Clear the receive message buffer.
			_receiveBuffer.Clear();

			long elapsedTime = ReceiveMessage();
			// If the response timed out...
			if (elapsedTime >= RxTimeout)
			{
				throw new ModbusTimeoutException("Timeout waiting for response.");
			}
			// If we got a response...
			else
			{
				// Fetch the minimum message length...
				int minFrameLength;
				switch (_connectionType)
				{
					default:
					case ConnectionType.SerialRTU:
						minFrameLength = 5;
						break;

					case ConnectionType.SerialASCII:
						minFrameLength = 11;
						break;

					case ConnectionType.UDPIP:
					case ConnectionType.TCPIP:
						minFrameLength = 9;
						break;
				}

				// If the message was incomplete...
				if (_receiveBuffer.Count < minFrameLength)
				{
					ReceiveMessage(); // try again to see if anything else made it in.
					if (_receiveBuffer.Count < minFrameLength)
						throw new ModbusTimeoutException("Wrong message length.");
                }

				switch (_connectionType)
				{
					// If we're using MODBUS ASCII...
					case ConnectionType.SerialASCII:
						// If we didn't get the correct start character...
						if (_receiveBuffer[0] != _sendBuffer[0])
						{
							throw new ModbusTimeoutException("Start character not found.");
						}

						// Remove the start character (a colon).
						_receiveBuffer.RemoveRange(0, 1);

						// If we didn't get the correct stop characters...
						char[] endFrameSent = new char[] { AsciiStopFrame1ST, AsciiStopFrame2ND };
						char[] endFrameReceived = Encoding.ASCII.GetChars(_receiveBuffer.GetRange(_receiveBuffer.Count - 2, 2).ToArray());
						if (!endFrameSent.SequenceEqual(endFrameReceived))
						{
							throw new ModbusTimeoutException("End characters not found.");
						}

						// Remove the stop characters.
						_receiveBuffer.RemoveRange(_receiveBuffer.Count - 2, 2);

						// Convert receive buffer from ASCII to binary.
						_receiveBuffer = GetBinaryBufferFromASCIIBytes(_receiveBuffer.ToArray()).ToList();

						// Parse the received LRC.
						byte lrc_received = _receiveBuffer[_receiveBuffer.Count - 1];

						// Remove the LRC.
						_receiveBuffer.RemoveRange(_receiveBuffer.Count - 1, 1);

						// If the LRC is incorrect...
						byte lrc_calculated = Checksum.LRC(_receiveBuffer.ToArray());
						if (lrc_calculated != lrc_received)
						{
							throw new ModbusResponseException("Wrong LRC");
						}

						// Remove address byte.
						_receiveBuffer.RemoveRange(0, 1);
						break;

					// If we're using MODBUS RTU...
					case ConnectionType.SerialRTU:
						// Parse the received CRC.
						ushort crcReceived = BitConverter.ToUInt16(_receiveBuffer.ToArray(), _receiveBuffer.Count - 2);

						// Remove CRC.
						_receiveBuffer.RemoveRange(_receiveBuffer.Count - 2, 2);

						// If the 16-bit CRC is incorrect...
						ushort crcCalculated = Checksum.Crc16(_receiveBuffer.ToArray());
						if (crcReceived != crcCalculated)
						{
							_receiveBuffer.AddRange(BitConverter.GetBytes(crcReceived));
							ReceiveMessage(); // try again to see if anything else made it in.

							crcReceived = BitConverter.ToUInt16(_receiveBuffer.ToArray(), _receiveBuffer.Count - 2);

							// Remove CRC.
							_receiveBuffer.RemoveRange(_receiveBuffer.Count - 2, 2);

							crcCalculated = Checksum.Crc16(_receiveBuffer.ToArray());
							if (crcReceived != crcCalculated)
							{
								throw new ModbusResponseException("Wrong CRC.");
                            }
                        }

						// If the device address is incorrect...
						byte addr = _receiveBuffer[0];
						if (addr != _sendBuffer[0])
						{
							throw new ModbusResponseException("Wrong response address.");
						}

						// Remove address.
						_receiveBuffer.RemoveRange(0, 1);
						break;

					// If we're using MODBUS IP...
					case ConnectionType.UDPIP:
					case ConnectionType.TCPIP:
						// If the MBAP header is incorrect...
						ushort tid = ToUInt16(_receiveBuffer.ToArray(), 0);
						if (tid != _transactionID)
						{
							throw new ModbusResponseException("Wrong transaction ID.");
						}

						// If the protocol ID is incorect...
						ushort pid = ToUInt16(_receiveBuffer.ToArray(), 2);
						if (pid != ProtocolID)
						{
							throw new ModbusResponseException("Wrong transaction ID.");
						}

						// If the length is incorrect...
						ushort len = ToUInt16(_receiveBuffer.ToArray(), 4);
						if ((_receiveBuffer.Count - MbapHeaderLength + 1) < len)
						{
							throw new ModbusResponseException("Wrong message length.");
						}

						// If the device address is incorrect...
						byte uid = _receiveBuffer[6];
						if (uid != _sendBuffer[6])
						{
							throw new ModbusResponseException("Wrong device address.");
						}

						// Remove the header from the message.
						_receiveBuffer.RemoveRange(0, MbapHeaderLength);
						break;
				}

				// If an error message was received...
				if (_receiveBuffer[0] > 0x80)
				{
					// An error has been reported.
					// Throw an error according to the exception code.
					switch (_receiveBuffer[1])
					{
						case 1:
							throw new ModbusIllegalFunctionException();

						case 2:
							throw new ModbusIllegalDataAddressException();

						case 3:
							throw new ModbusIllegalDataValueException();

						case 4:
							throw new ModbusSlaveDeviceFailureException();
					}
				}
			}
		}

        protected long ReceiveMessage()
        {
            bool done = false;
            bool firstByteReceived = false;
            long elapsedTime = 0;

            // Start a timeout stopwatch.
            Stopwatch sw = new Stopwatch();
            sw.Start();
            do
            {
                // Try to read a byte.
                int rcv = ReceiveByte();

                // If a byte was received...
                if (rcv > -1)
                {
                    // If it is the first byte...
                    if (firstByteReceived == false)
                    {
                        // Remember that at least one byte has been received.
                        firstByteReceived = true;
                    }

                    // If we're using MODBUS ASCII...
                    if (_connectionType == ConnectionType.SerialASCII)
                    {
                        // If the byte we received was a colon (the first byte of an ASCII message)...
                        if ((byte)rcv == Encoding.ASCII.GetBytes(new char[] { AsciiStartFrame }).First())
                        {
                            // Clear the receive message buffer of any previous partial message.
                            _receiveBuffer.Clear();
                        }
                    }

                    // Add the received byte to the receive message buffer.
                    _receiveBuffer.Add((byte)rcv);
                }
                // If we've stopped receiving bytes...
                else if ((rcv == -1) && firstByteReceived)
                {
                    done = true;
                }

                // Fetch how many milliseconds have elapsed.
                // Keep receiving until we stop receiving bytes.
                elapsedTime = sw.ElapsedMilliseconds;
            } while ((!done) && (RxTimeout > elapsedTime));

            // Stop the stopwatch.
            _timeoutStopwatch.Stop();
            sw.Stop();

            return elapsedTime;
        }

        #endregion

        #region Protocol Methods

        /// <summary>
        /// Read coil registers.
        /// </summary>
        /// <param name="deviceAddress">Slave device address</param>
        /// <param name="startAddress">Address of first register to be read</param>
        /// <param name="numCoils">Number of coils to be read</param>
        /// <returns>Array of registers from slave</returns>
        public bool[] ReadCoils(byte deviceAddress, ushort startAddress, ushort numCoils)
		{
			if (numCoils < 1)
			{
				throw new ModbusRequestException("Zero coils requested.");
			}
			if (numCoils > MaxCoilsInReadMessage)
			{
				throw new ModbusRequestException("Too many coils requested.");
			}

			// Set message length of six bytes.
			ushort messageLength = 6;

			// Increase transaction ID (only used for TCP/UDP).
			_transactionID++;

			// Form the request.
			_sendBuffer.Clear();
			_sendBuffer.Add((byte)ModbusCode.ReadCoils);
			_sendBuffer.AddRange(GetBytes(startAddress));
			_sendBuffer.AddRange(GetBytes(numCoils));

			// Send the request and receive the response.
			Query(deviceAddress, messageLength);

			// Parse the response.
			BitArray ba = new BitArray(_receiveBuffer.GetRange(2, _receiveBuffer.Count - 2).ToArray());
			bool[] ret = new bool[ba.Count];
			ba.CopyTo(ret, 0);
			return ret;
		}

		/// <summary>
		/// Read a set of discrete inputs.
		/// </summary>
		/// <param name="deviceAddress">Slave device address</param>
		/// <param name="startAddress">Address of first register to be read</param>
		/// <param name="numInputs">Number of registers to be read</param>
		/// <returns>Array of readed registers</returns>
		public bool[] ReadDiscreteInputs(byte deviceAddress, ushort startAddress, ushort numInputs)
		{
			if (numInputs < 1)
			{
				throw new ModbusRequestException("Zero discrete inputs requested.");
			}
			if (numInputs > MaxDiscreteInputsInReadMessage)
			{
				throw new ModbusRequestException("Too many coils requested.");
			}

			// Set message length of six bytes.
			ushort messageLength = 6;

			// Increase transaction ID (only used for TCP/UDP).
			_transactionID++;

			// Form the request.
			_sendBuffer.Clear();
			_sendBuffer.Add((byte)ModbusCode.ReadDiscreteInputs);
			_sendBuffer.AddRange(GetBytes(startAddress));
			_sendBuffer.AddRange(GetBytes(numInputs));

			// Send the request and receive the response.
			Query(deviceAddress, messageLength);

			// Parse the response.
			BitArray ba = new BitArray(_receiveBuffer.GetRange(2, _receiveBuffer.Count - 2).ToArray());
			bool[] ret = new bool[ba.Count];
			ba.CopyTo(ret, 0);
			return ret;
		}

		/// <summary>
		/// Read a set of holding registers.
		/// </summary>
		/// <param name="deviceAddress">Slave device address</param>
		/// <param name="startAddress">Address of first register to be read</param>
		/// <param name="numRegisters">Number of registers to be read</param>
		/// <returns>Array of readed registers</returns>
		public ushort[] ReadHoldingRegisters(byte deviceAddress, ushort startAddress, ushort numRegisters)
		{
			if (numRegisters < 1)
			{
				throw new ModbusRequestException("Zero registers requested.");
			}
			if (numRegisters > MaxHoldingRegistersInReadMessage)
			{
				throw new ModbusRequestException("Too many registers requested.");
			}

			// Set message length of six bytes.
			ushort messageLength = 6;

			// Increase transaction ID (only used for TCP/UDP).
			_transactionID++;

            // Form the request.
            _sendBuffer.Clear();
			_sendBuffer.Add((byte)ModbusCode.ReadHoldingRegisters);
			_sendBuffer.AddRange(GetBytes(startAddress));
			_sendBuffer.AddRange(GetBytes(numRegisters));

            // Send the request and receive the response.
            Query(deviceAddress, messageLength);

            // Parse the response.
            List<ushort> ret = new List<ushort>();
			for (int ii = 0; ii < _receiveBuffer[1]; ii += 2)
			{
				ret.Add(ToUInt16(_receiveBuffer.ToArray(), ii + 2));
			}

			return ret.ToArray();
		}

		/// <summary>
		/// Read a set of input registers.
		/// </summary>
		/// <param name="deviceAddress">Slave device address</param>
		/// <param name="startAddress">Address of first register to be read</param>
		/// <param name="numRegisters">Number of registers to be read</param>
		/// <returns>Array of readed registers</returns>
		public ushort[] ReadInputRegisters(byte deviceAddress, ushort startAddress, ushort numRegisters)
		{
			if (numRegisters < 1)
			{
				throw new ModbusRequestException("Zero registers requested.");
			}
			if (numRegisters > MaxInputRegistersInReadMessage)
			{
				throw new ModbusRequestException("Too many registers requested.");
			}

			// Set message length of six bytes.
			ushort messageLength = 6;

			// Increase transaction ID (only used for TCP/UDP).
			_transactionID++;

			// Form the request.
			_sendBuffer.Clear();
			_sendBuffer.Add((byte)ModbusCode.ReadInputRegisters);
			_sendBuffer.AddRange(GetBytes(startAddress));
			_sendBuffer.AddRange(GetBytes(numRegisters));

			// Send the request and receive the response.
			Query(deviceAddress, messageLength);

			// Parse the response.
			List<ushort> ret = new List<ushort>();
			for (int ii = 0; ii < _receiveBuffer[1]; ii += 2)
				ret.Add(ToUInt16(_receiveBuffer.ToArray(), ii + 2));
			return ret.ToArray();
		}

		/// <summary>
		/// Write a coil register.
		/// </summary>
		/// <param name="deviceAddress">Slave device address</param>
		/// <param name="coilAddress">coil's address</param>
		/// <param name="value">Value to write</param>
		public void WriteSingleCoil(byte deviceAddress, ushort coilAddress, bool value)
		{
			// Set message length of six bytes.
			ushort messageLength = 6;

			// Increase transaction ID (only used for TCP/UDP).
			_transactionID++;

			// Form the request.
			_sendBuffer.Clear(); _sendBuffer.Add((byte)ModbusCode.WriteSingleCoil);
			_sendBuffer.AddRange(GetBytes(coilAddress));
			_sendBuffer.AddRange(GetBytes((ushort)(value == true ? 0xFF00 : 0x0000)));

			// Send the request and receive the response.
			Query(deviceAddress, messageLength);

			// Parse the response.
			ushort addr = ToUInt16(_receiveBuffer.ToArray(), 1);
			ushort regval = ToUInt16(_receiveBuffer.ToArray(), 3);

			// Check for errors in the response.
			if (addr != coilAddress)
			{
				throw new ModbusResponseException("Wrong response address.");
			}
			if ((regval == 0xFF00) && !value)
			{
				throw new ModbusResponseException("Wrong response value.");
			}
		}

		/// <summary>
		/// Write a holding register.
		/// </summary>
		/// <param name="deviceAddress">Slave device address</param>
		/// <param name="registerAddress">Register address</param>
		/// <param name="value">Value to write</param>
		public void WriteSingleRegister(byte deviceAddress, ushort registerAddress, ushort value)
		{
			// Set message length of six bytes.
			ushort messageLength = 6;

			// Increase transaction ID (only used for TCP/UDP).
			_transactionID++;

			// Form the request.
			_sendBuffer.Clear();
			_sendBuffer.Add((byte)ModbusCode.WriteSingleRegister);
			_sendBuffer.AddRange(GetBytes(registerAddress));
			_sendBuffer.AddRange(GetBytes(value));

			// Send the request and receive the response.
			Query(deviceAddress, messageLength);

			// Parse the response.
			ushort addr = ToUInt16(_receiveBuffer.ToArray(), 1);
			if (addr != registerAddress)
			{
				throw new ModbusResponseException("Wrong response address.");
			}
		}

		/// <summary>
		/// Write a set of coil registers.
		/// </summary>
		/// <param name="deviceAddress">Slave device address</param>
		/// <param name="startAddress">Address of first register to be write</param>
		/// <param name="values">Array of values to write</param>
		public void WriteMultipleCoils(byte deviceAddress, ushort startAddress, bool[] values)
		{
			if (values == null)
			{
				throw new ModbusRequestException("Zero registers requested.");
			}
			if (values.Length < 1)
			{
				throw new ModbusRequestException("Zero registers requested.");
			}
			if (values.Length > MaxCoilsInWriteMessage)
			{
				throw new ModbusRequestException("Too many registers requested.");
			}

			// Set the message length based on how many boolean values we are sending.
			byte byteCount = (byte)((values.Length / 8) + ((values.Length % 8) == 0 ? 0 : 1));
			ushort messageLength = (ushort)(1 + 6 + byteCount);

			// Transform the array of boolean values into an array of bytes.
			byte[] data = new byte[byteCount];
			BitArray ba = new BitArray(values);
			ba.CopyTo(data, 0);

			// Increase transaction ID (only used for TCP/UDP).
			_transactionID++;

			// Form the request.
			_sendBuffer.Clear();
			_sendBuffer.Add((byte)ModbusCode.WriteMultipleCoils);
			_sendBuffer.AddRange(GetBytes(startAddress));
			_sendBuffer.AddRange(GetBytes((ushort)values.Length));
			_sendBuffer.Add(byteCount);
			_sendBuffer.AddRange(data);

			// Send the request and receive the response.
			Query(deviceAddress, messageLength);

			// Parse the response.
			ushort sa = ToUInt16(_receiveBuffer.ToArray(), 1);
			ushort nr = ToUInt16(_receiveBuffer.ToArray(), 3);

			// Check for errors in the response.
			if (sa != startAddress)
			{
				throw new ModbusResponseException("Wrong response address.");
			}
			if (nr != values.Length)
			{
				throw new ModbusResponseException("Wrong response registers.");
			}
		}

		/// <summary>
		/// Write a set of holding registers
		/// </summary>
		/// <param name="deviceAddress">Slave device address</param>
		/// <param name="startAddress">Address of first register to be write</param>
		/// <param name="values">Array of values to write</param>
		public void WriteMultipleRegisters(byte deviceAddress, ushort startAddress, ushort[] values)
		{
			if (values == null)
			{
				throw new ModbusRequestException("Zero registers requested.");
			}
			if (values.Length < 1)
			{
				throw new ModbusRequestException("Zero registers requested.");
			}
			if (values.Length > MaxHoldingRegistersInWriteMessage)
			{
				throw new ModbusRequestException("Too many registers requested.");
			}

			// Set the message length according to how many registers we are writing.
			ushort messageLength = (ushort)(7 + (values.Length * 2));

			// Increase transaction ID (only used for TCP/UDP).
			_transactionID++;

			// Form the request.
			_sendBuffer.Clear();
			_sendBuffer.Add((byte)ModbusCode.WriteMultipleRegisters);
			_sendBuffer.AddRange(GetBytes(startAddress));
			_sendBuffer.AddRange(GetBytes((ushort)values.Length));
			_sendBuffer.Add((byte)(values.Length * 2));
			for (int ii = 0; ii < values.Length; ii++)
			{
				_sendBuffer.AddRange(GetBytes(values[ii]));
			}

			// Send the request and receive the response.
			Query(deviceAddress, messageLength);

			// Parse the response.
			ushort sa = ToUInt16(_receiveBuffer.ToArray(), 1);
			ushort nr = ToUInt16(_receiveBuffer.ToArray(), 3);

			// Check for errors in the response.
			if (sa != startAddress)
			{
				throw new ModbusResponseException("Wrong response address.");
			}
			if (nr != values.Length)
			{
				throw new ModbusResponseException("Wrong response registers.");
			}

		}

		/// <summary>
		/// Make an AND and OR mask of a single holding register
		/// </summary>
		/// <param name="deviceAddress">Slave device address</param>
		/// <param name="registerAddress">Register address</param>
		/// <param name="andMask">AND mask</param>
		/// <param name="orMask">OR mask</param>
		public void MaskWriteRegister(byte deviceAddress, ushort registerAddress, ushort andMask, ushort orMask)
		{
			// Set message length to eight bytes.
			ushort messageLength = 8;

			// Increase transaction ID (only used for TCP/UDP).
			_transactionID++;

			// Form the request.
			_sendBuffer.Clear(); _sendBuffer.Add((byte)ModbusCode.MaskWriteRegister);
			_sendBuffer.AddRange(GetBytes(registerAddress));
			_sendBuffer.AddRange(GetBytes(andMask));
			_sendBuffer.AddRange(GetBytes(orMask));

			// Send the request and receive the response.
			Query(deviceAddress, messageLength);

			// Check address.
			ushort addr = ToUInt16(_receiveBuffer.ToArray(), 1);
			if (registerAddress != addr)
			{
				throw new ModbusResponseException("Wrong response address.");
			}
			// Check AND mask
			ushort am = ToUInt16(_receiveBuffer.ToArray(), 3);
			if (andMask != am)
			{
				throw new ModbusResponseException("Wrong response AND mask.");
			}
			// Check OR mask
			ushort om = ToUInt16(_receiveBuffer.ToArray(), 5);
			if (orMask != om)
			{
				throw new ModbusResponseException("Wrong response OR mask.");
			}

		}

		/// <summary>
		/// Read and write a set of holding registers in a single shot
		/// </summary>
		/// <param name="deviceAddress">Slave device address</param>
		/// <param name="readStartAddress">Address of first registers to be read</param>
		/// <param name="readNumRegisters">Number of registers to be read</param>
		/// <param name="writeStartAddress">Address of first registers to be write</param>
		/// <param name="values">Array of values to be write</param>
		/// <returns>Array of readed registers</returns>
		/// <remarks>
		/// Write is the first operation, than the read operation
		/// </remarks>
		public ushort[] ReadWriteMultipleRegisters(byte deviceAddress, ushort readStartAddress, ushort readNumRegisters, ushort writeStartAddress, ushort[] values)
		{
			if (values == null)
			{
				throw new ModbusRequestException("Zero registers requested.");
			}
			if ((readNumRegisters < 1) || (values.Length < 1))
			{
				throw new ModbusRequestException("Zero registers requested.");
			}
			if ((readNumRegisters > MaxHoldingRegistersToReadInReadWriteMessage) ||
				(values.Length > MaxHoldingRegistersToWriteInReadWriteMessage))
			{
				throw new ModbusRequestException("Too many registers requested.");
			}

			// Set message length according to how many registers we are writing.
			ushort messageLength = (ushort)(11 + (values.Length * 2));

			// Increase transaction ID (only used for TCP/UDP).
			_transactionID++;

			// Form the request.
			_sendBuffer.Clear(); _sendBuffer.Add((byte)ModbusCode.ReadWriteMultipleRegisters);
			_sendBuffer.AddRange(GetBytes(readStartAddress));
			_sendBuffer.AddRange(GetBytes(readNumRegisters));
			_sendBuffer.AddRange(GetBytes(writeStartAddress));
			_sendBuffer.AddRange(GetBytes((ushort)values.Length));
			_sendBuffer.Add((byte)(values.Length * 2));
			for (int ii = 0; ii < values.Length; ii++)
			{
				_sendBuffer.AddRange(GetBytes(values[ii]));
			}

			// Send the request and receive the response.
			Query(deviceAddress, messageLength);

			// Parse the response.
			List<ushort> ret = new List<ushort>();
			for (int ii = 0; ii < _receiveBuffer[1]; ii += 2)
			{
				ret.Add(ToUInt16(_receiveBuffer.ToArray(), ii + 2));
			}

			return ret.ToArray();
		}

		#endregion
	}
}
