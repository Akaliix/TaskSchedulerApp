using TaskSchedulerApp.Commands;

namespace TaskSchedulerApp.CommandVisuals
{
    public partial class DelayVisual : UserControl, ICommandVisual
    {
        public DelayVisual()
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
            return new DelayCommand(Math.Max((float)guna2NumericUpDown1.Value, 0f));
        }
    }
}
