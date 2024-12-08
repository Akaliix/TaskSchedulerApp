namespace TaskSchedulerApp.Devices
{
    /// <summary>
    /// Represents the base class for notifications. 
    /// It provides the structure and contract for all notification types (such as email, toast, etc.) to follow.
    /// </summary>
    public abstract class BaseNotification
    {
        /// <summary>
        /// The message content of the notification.
        /// </summary>
        internal readonly string _message;

        /// <summary>
        /// The title of the notification.
        /// </summary>
        internal readonly string _title;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseNotification"/> class with the specified message and title.
        /// </summary>
        /// <param name="message">The content of the notification.</param>
        /// <param name="title">The title of the notification.</param>
        public BaseNotification(string message, string title)
        {
            _message = message;
            _title = title;
        }

        /// <summary>
        /// Sends the notification.
        /// This method must be overridden in derived classes to implement the specific logic for sending the notification.
        /// </summary>
        /// <returns>A task representing the asynchronous operation. Returns <c>true</c> if the notification is sent successfully, <c>false</c> otherwise.</returns>
        abstract public Task<bool> Send();
    }
}
