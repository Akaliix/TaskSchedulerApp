using System.Net;
using System.Net.Mail;

namespace TaskSchedulerApp.Devices.NotificationTypes
{
    public class EmailNotification : BaseNotification
    {
        private readonly string _emailAddress;

        public EmailNotification(string emailAddress, string subject, string message) : base(message, subject)
        {
            _emailAddress = emailAddress;
        }

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
                BasicConsole.logger.LogMessage(AbstractLogger.SUCCESS,"Email sent successfully.");
                return true;
            }
            catch (Exception ex)
            {
                BasicConsole.logger.LogMessage(AbstractLogger.ERROR,$"Failed to send email. Error: {ex.Message}");
            }
            return false;
        }
    }
}
