using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


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
        static string[] Scopes = { GmailService.Scope.GmailSend, GmailService.Scope.GmailReadonly };  //Gmail Send is used to send emails where GmailReadonly is used to read emails on the account
        static string ApplicationName = "STP Email Client API";  // Name of the application in your Google API Console

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
        /// <param name="recipients">String array of recipients</param>
        /// <param name="subject">Subject</param>
        /// <param name="body">Body</param>
        /// <param name="fromAddress">Email that is sending the notifications</param>
        /// <remarks>Inspired by: https://developers.google.com/gmail/api/guides/sending </remarks>
        public static void SendEmail(string[] recipients, string subject, string body, string fromAddress)
        {
            UserCredential credential;

            // Verifies client credentials using client_secret.json file
            using (var stream =
                new FileStream("client_secret.json", FileMode.Open, FileAccess.Read)) // Make sure client_secret.json is the specified location
            {
                string credPath = System.Environment.GetFolderPath(
                    System.Environment.SpecialFolder.Personal);
                credPath = Path.Combine(credPath, ".credentials/gmail-dotnet-quickstart.json");

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }

            // Create Gmail API service.
            var service = new GmailService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            // Define parameters of request.
            UsersResource.LabelsResource.ListRequest request = service.Users.Labels.List("me");

            // Inspired by: https://stackoverflow.com/questions/24728793/creating-a-message-for-gmail-api-in-c-sharp
            // Creates a message with the provided list of recipients, subject, and body that were passed into the method
            var msg = new AE.Net.Mail.MailMessage
            {
                Subject = subject,
                Body = body,
                From = new MailAddress(fromAddress)
            };

            // Loops through all the values in the recipients array and adds them to the email
            foreach (var vRecipient in recipients)
            {
                msg.To.Add(new MailAddress(vRecipient));
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
            Console.WriteLine("Message ID {0} sent.", result.Id);

        }

    }
}
