using System.Net;
using System.Net.Mail;

namespace TaskSchedulerApp.Devices.NotificationTypes
{
    /// <summary>
    /// A concrete implementation of the <see cref="BaseNotification"/> class for sending email notifications.
    /// Provides functionality for creating and sending an email message.
    /// </summary>
    public class EmailNotification : BaseNotification
    {
        /// <summary>
        /// The email address to which the notification will be sent.
        /// </summary>
        private readonly string _emailAddress;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailNotification"/> class with the given email address, subject, and message.
        /// </summary>
        /// <param name="emailAddress">The recipient's email address.</param>
        /// <param name="subject">The subject of the email.</param>
        /// <param name="message">The body message of the email.</param>
        public EmailNotification(string emailAddress, string subject, string message) : base(message, subject)
        {
            _emailAddress = emailAddress;
        }

        /// <summary>
        /// Sends the email notification asynchronously.
        /// This method overrides the abstract <see cref="Send"/> method from <see cref="BaseNotification"/>.
        /// </summary>
        /// <returns>A Task representing the asynchronous operation. Returns <c>true</c> if the email was sent successfully, <c>false</c> otherwise.</returns>
        public override async Task<bool> Send()
        {
            try
            {
                // Create the email message
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(TaskSchedulerSettings.EmailFrom);
                mail.To.Add(_emailAddress);
                mail.Subject = _title;
                mail.Body = _message;

                // Configure the SMTP client
                SmtpClient smtpClient = new SmtpClient(TaskSchedulerSettings.EmailServer, TaskSchedulerSettings.EmailServerPort)
                {
                    Credentials = new NetworkCredential(TaskSchedulerSettings.EmailServerUsername, TaskSchedulerSettings.EmailServerPassword),
                    EnableSsl = true
                };

                // Send the email
                smtpClient.Send(mail);
                BasicConsole.logger.LogMessage(AbstractLogger.SUCCESS, "Email sent successfully.");
                return true;
            }
            catch (Exception ex)
            {
                BasicConsole.logger.LogMessage(AbstractLogger.ERROR, $"Failed to send email. Error: {ex.Message}");
            }
            return false;
        }
    }
}
