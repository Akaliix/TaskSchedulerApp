using Microsoft.Toolkit.Uwp.Notifications;

namespace TaskSchedulerApp.Devices.NotificationTypes
{
    public class ToastNotification : BaseNotification
    {
        public ToastNotification(string title, string message) : base(message, title)
        {
        }

        public override async Task<bool> Send()
        {
            new ToastContentBuilder()
            .AddText(_title)
            .AddText(_message).Show();
            BasicConsole.logger.LogMessage(AbstractLogger.SUCCESS,$"Toast notification sent succesfully!");

            return true;
        }
    }
}
