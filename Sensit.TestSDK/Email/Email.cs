using System;
using System.IO;
using System.Net.Mail;
using System.Threading;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;


namespace Sensit.TestSDK.Email
{
	/// <summary>
	/// Used for sending email notification through GMail using OAuth2 Authentication
	/// </summary>
	/// <remarks>Inspired by: https://console.developers.google.com/apis/ </remarks>
	/// <remarks>Inspired by: https://developers.google.com/gmail/api/quickstart/dotnet </remarks>
	public class Email
	{
		// If modifying these scopes, delete your previously saved credentials
		// at ~/.credentials/gmail-dotnet-quickstart.json
		private string[] _scopes =
		{
			GmailService.Scope.GmailSend,		// Gmail Send is used to send emails 
			GmailService.Scope.GmailReadonly	// GmailReadonly is used to read emails
		};
		private string _applicationName = "STP Email Client API";	// Name of the application in your Google API Console

		private string _body;			// email's body
		private string _subject;		// email's subject line
		private string[] _recipients;	// array of emails to send to
		private string _fromAddress;	// address the email will appear to be from
		private string _clientSecret;   // client secret from Google API console

		/// <summary>
		/// Email's body
		/// </summary>
		public string Body 
		{
			get => _body;
			set => _body = value;
		}

		/// <summary>
		/// Email's subject line
		/// </summary>
		public string Subject
		{
			get => _subject;
			set => _subject = value;
		}

		/// <summary>
		/// Email's recipient list
		/// </summary>
		public string[] Recipients
		{
			get => _recipients;
			set => _recipients = value;
		}

		/// <summary>
		/// Address email will appear to be sent from
		/// </summary>
		public string FromAddress
		{
			get => _fromAddress;
			set => _fromAddress = value;
		}

		/// <summary>
		/// Name of the client secret JSON file used to authenticate with Gmail
		/// </summary>
		/// <remarks>
		/// This file is obtained from Gmail by following instructions found in
		/// the quickstart guide referenced above.
		/// </remarks>
		public string ClientSecret
		{
			get => _clientSecret;
			set => _clientSecret = value;
		}

		/// <summary>
		/// Base64 Encodes an input string
		/// </summary>
		/// <param name="input">Input String</param>
		/// <returns>Base64 Encoded String</returns>
		private static string Base64UrlEncode(string input)
		{
			var inputBytes = System.Text.Encoding.UTF8.GetBytes(input);
			// Special "url-safe" base64 encode.
			return Convert.ToBase64String(inputBytes)
				.Replace('+', '-')
				.Replace('/', '_')
				.Replace("=", "");
		}

		/// <summary>
		/// Sends an email to an array of recipients
		/// </summary>
		/// <remarks>
		/// Inspired by: https://developers.google.com/gmail/api/guides/sending
		/// </remarks>
		public void SendEmail()
		{
			UserCredential credential;

			// Check to see if there's the client secret file in the proper location before continuing on to send the email
			if (!File.Exists(_clientSecret))
			{
				throw new Exception("Client Secret JSON file is missing from the application.");
			}

			// Checks to verify the email has a body, subject, from address, and an array of recipients
			if ((_body == null) || (_subject == null) || (_recipients == null) || (_fromAddress == null))
			{
				throw new Exception("The email has not been formatted properly.  Be sure to include a body, subject, fromAddress, and an array of recipients.");
			}

			// Verifies client credentials using client_secret.json file
			using (var stream =
				new FileStream(_clientSecret, FileMode.Open, FileAccess.Read)) // Make sure client_secret.json is the specified location
			{
				string credPath = System.Environment.GetFolderPath(
					System.Environment.SpecialFolder.Personal);
				credPath = Path.Combine(credPath, ".credentials/gmail-dotnet-quickstart.json");

				credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
					GoogleClientSecrets.Load(stream).Secrets,
					_scopes,
					"user",
					CancellationToken.None,
					new FileDataStore(credPath, true)).Result;
				Console.WriteLine("Credential file saved to: " + credPath);
			}

			// Create Gmail API service.
			var service = new GmailService(new BaseClientService.Initializer()
			{
				HttpClientInitializer = credential,
				ApplicationName = _applicationName,
			});

			// Define parameters of request.
			UsersResource.LabelsResource.ListRequest request = service.Users.Labels.List("me");

			// Inspired by: https://stackoverflow.com/questions/24728793/creating-a-message-for-gmail-api-in-c-sharp
			// Creates a message with the provided list of recipients, subject, and body that were passed into the method
			var msg = new AE.Net.Mail.MailMessage
			{
				Subject = _subject,
				Body = _body,
				From = new MailAddress(_fromAddress)
			};

			// Loops through all the values in the recipients array and adds them to the email
			foreach (var recipient in _recipients)
			{
				msg.To.Add(new MailAddress(recipient));
			}

			// Adds the return address
			msg.ReplyTo.Add(msg.From); // Bounces without this!!
			var msgStr = new StringWriter();
			msg.Save(msgStr);

			// Sends an email message using the provided list of recipients, subject, and body that were passed into the method
			var result = service.Users.Messages.Send(new Message
			{
				Raw = Base64UrlEncode(msgStr.ToString())  // Make sure to Base64Encode the message, otherwise it will fail
			}, "me").Execute();
		}
	}
}
