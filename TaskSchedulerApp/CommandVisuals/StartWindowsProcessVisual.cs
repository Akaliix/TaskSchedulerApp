using TaskSchedulerApp.Commands;
using TaskSchedulerApp.Devices.ProcessTypes;

namespace TaskSchedulerApp.CommandVisuals
{
    public partial class StartWindowsProcessVisual : UserControl, ICommandVisual
    {
        private string path = "";
        public StartWindowsProcessVisual()
        {
            InitializeComponent();
        }

        private void VisualForm_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            this.Focus();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            // Open executable file dialog
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Executable Files(*.exe)|*.exe";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog.FileName;
            }
        }

        public ITaskCommand GetCommand()
        {
            return new StartProcessCommand(new WindowsProcess(path));
        }
    }
}
