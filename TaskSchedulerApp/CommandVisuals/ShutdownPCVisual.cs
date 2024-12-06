using TaskSchedulerApp.Commands;

namespace TaskSchedulerApp.CommandVisuals
{
    public partial class ShutdownPCVisual : UserControl, ICommandVisual
    {
        public ShutdownPCVisual()
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
            return new ShutdownPCCommand();
        }
    }
}
