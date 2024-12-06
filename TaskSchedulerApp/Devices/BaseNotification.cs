namespace TaskSchedulerApp.Devices
{
    public abstract class BaseNotification
    {
        internal readonly string _message;
        internal readonly string _title;
        public BaseNotification(string message, string title)
        {
            _message = message;
            _title = title;
        }

        abstract public Task<bool> Send();
    }
}
