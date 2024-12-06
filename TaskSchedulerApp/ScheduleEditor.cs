using TaskSchedulerApp.CommandVisuals;

namespace TaskSchedulerApp
{
    public partial class ScheduleEditor : Form
    {
        private List<ICommandVisual> commands = new List<ICommandVisual>();
        public ScheduleEditor()
        {
            InitializeComponent();
            guna2NumericUpDown1.Value = decimal.Parse(DateTime.Now.ToString("HH"));
            guna2NumericUpDown2.Value = decimal.Parse(DateTime.Now.ToString("mm"));
        }

        private void AddControlToPanel(Control control)
        {
            if (control != null && control is ICommandVisual)
            {
                control.Location = new Point(0, commandMacroPanel.Controls.Count * 68);
                commands.Add(control as ICommandVisual);
                commandMacroPanel.Controls.Add(control);
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveAndExit_Click(object sender, EventArgs e)
        {
            TaskScheduler taskScheduler = new TaskScheduler(guna2TextBox1.Text, (int)guna2NumericUpDown1.Value, (int)guna2NumericUpDown2.Value);
            foreach (ICommandVisual command in commands)
            {
                TaskHandler taskHandler = new TaskHandler(command.GetCommand());
                taskScheduler.AddTask(taskHandler);
            }
            Form1.singleton?.AddTaskScheduler(taskScheduler);
            this.Close();
        }


        #region Command Buttons
        private void changeWallpaperWebButton_Click(object sender, EventArgs e)
        {
            AddControlToPanel(new ChangeWallpaperWebVisual());
        }

        private void changeWallpaperLocalButton_Click(object sender, EventArgs e)
        {
            AddControlToPanel(new ChangeWallpaperLocalVisual());
        }

        private void sendEmailButton_Click(object sender, EventArgs e)
        {
            AddControlToPanel(new SendNotificationEmailVisual());
        }

        private void sendToastButton_Click(object sender, EventArgs e)
        {
            AddControlToPanel(new SendNotificationToastVisual());
        }

        private void startWebUrlButton_Click(object sender, EventArgs e)
        {
            AddControlToPanel(new StartWebProcessVisual());
        }

        private void startProcessButton_Click(object sender, EventArgs e)
        {
            AddControlToPanel(new StartWindowsProcessVisual());
        }

        private void restartPcButton_Click(object sender, EventArgs e)
        {
            AddControlToPanel(new RestartPCVisual());
        }

        private void shutdownPcButton_Click(object sender, EventArgs e)
        {
            AddControlToPanel(new ShutdownPCVisual());
        }

        private void takeScreenshotButton_Click(object sender, EventArgs e)
        {
            AddControlToPanel(new TakeScreenshotVisual());
        }

        private void addDelayButton_Click(object sender, EventArgs e)
        {
            AddControlToPanel(new DelayVisual());
        }
        #endregion
    }
}
