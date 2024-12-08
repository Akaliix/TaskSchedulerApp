using TaskSchedulerApp.Devices;

namespace TaskSchedulerApp.Commands
{
    /// <summary>
    /// Command to send a notification.
    /// Implements the ITaskCommand interface and sends a notification using a provided notification object.
    /// </summary>
    public class SendNotificationCommand : ITaskCommand
    {
        /// <summary>
        /// The notification object that will be used to send the notification.
        /// </summary>
        public BaseNotification _notification;

        /// <summary>
        /// Initializes a new instance of the <see cref="SendNotificationCommand"/> class.
        /// </summary>
        /// <param name="notification">The notification object that contains the details for the notification to send.</param>
        public SendNotificationCommand(BaseNotification notification)
        {
            _notification = notification;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SendNotificationCommand"/> class.
        /// </summary>
        /// <param name="notification">The notification object that contains the details for the notification to send.</param>
        public async Task ExecuteAsync()
        {
            await _notification.Send();
        }
    }
}
