using TaskSchedulerApp.Commands;
using TaskSchedulerApp.Devices.NotificationTypes;

namespace TaskSchedulerApp.CommandVisuals
{
    public partial class SendNotificationToastVisual : UserControl, ICommandVisual
    {
        public SendNotificationToastVisual()
        {
            InitializeComponent();
        }

        private void VisualForm_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            this.Focus();
        }

        public ITaskCommand GetCommand()
        {
            return new SendNotificationCommand(new ToastNotification(guna2TextBox1.Text, guna2TextBox2.Text));
        }
    }
}
