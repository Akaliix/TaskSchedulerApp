using TaskSchedulerApp.Commands;

namespace TaskSchedulerApp.CommandVisuals
{
    public partial class RestartPCVisual : UserControl, ICommandVisual
    {
        public RestartPCVisual()
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
            return new RestartPCCommand();
        }
    }
}
