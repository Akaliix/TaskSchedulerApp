using TaskSchedulerApp.Commands;

namespace TaskSchedulerApp.CommandVisuals
{
    public partial class TakeScreenshotVisual : UserControl, ICommandVisual
    {
        public TakeScreenshotVisual()
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
            return new TakeScreenShotCommand(guna2TextBox1.Text + ".bmp");
        }
    }
}
