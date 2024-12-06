using TaskSchedulerApp.Devices;

namespace TaskSchedulerApp.Commands
{
    public class SendNotificationCommand : ITaskCommand
    {
        public BaseNotification _notification;
        public SendNotificationCommand(BaseNotification notification)
        {
            _notification = notification;
        }

        public async Task ExecuteAsync()
        {
            await _notification.Send();
        }
    }
}
