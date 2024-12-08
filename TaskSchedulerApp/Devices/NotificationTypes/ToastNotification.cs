using Microsoft.Toolkit.Uwp.Notifications;

namespace TaskSchedulerApp.Devices.NotificationTypes
{
    /// <summary>
    /// A concrete implementation of the <see cref="BaseNotification"/> class for sending toast notifications.
    /// Provides functionality to create and show a simple toast notification.
    /// </summary>
    public class ToastNotification : BaseNotification
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ToastNotification"/> class with the given title and message.
        /// </summary>
        /// <param name="title">The title of the toast notification.</param>
        /// <param name="message">The body message of the toast notification.</param>
        public ToastNotification(string title, string message) : base(message, title)
        {
        }

        /// <summary>
        /// Sends the toast notification asynchronously.
        /// This method overrides the abstract <see cref="Send"/> method from <see cref="BaseNotification"/>.
        /// </summary>
        /// <returns>A Task representing the asynchronous operation. Always returns <c>true</c> since no failure condition is expected for a simple toast notification.</returns>
        public override async Task<bool> Send()
        {
            // Create and display the toast notification
            new ToastContentBuilder()
                .AddText(_title) // Add the title of the notification
                .AddText(_message) // Add the body message of the notification
                .Show(); // Show the notification

            BasicConsole.logger.LogMessage(AbstractLogger.SUCCESS, $"Toast notification sent succesfully!");

            return true;
        }
    }
}
