using TaskSchedulerApp.Commands;
using TaskSchedulerApp.Devices.ProcessTypes;

namespace TaskSchedulerApp.CommandVisuals
{
    public partial class StartWebProcessVisual : UserControl, ICommandVisual
    {
        public StartWebProcessVisual()
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
            return new StartProcessCommand(new WebProcess(guna2TextBox1.Text));
        }
    }
}
