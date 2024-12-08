using TaskSchedulerApp.CommandVisuals;

namespace TaskSchedulerApp
{
    /// <summary>
    /// The ScheduleEditor class is a form that allows the user to create and manage task schedules.
    /// Users can specify the task execution time and add commands that will be executed when the task runs.
    /// </summary>
    public partial class ScheduleEditor : Form
    {
        /// <summary>
        /// A list of ICommandVisual objects representing the commands to be executed in the task scheduler.
        /// </summary>
        private List<ICommandVisual> commands = new List<ICommandVisual>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ScheduleEditor"/> class.
        /// Sets the initial values for the numeric controls to the current hour and minute.
        /// </summary>
        public ScheduleEditor()
        {
            InitializeComponent();
            guna2NumericUpDown1.Value = decimal.Parse(DateTime.Now.ToString("HH"));
            guna2NumericUpDown2.Value = decimal.Parse(DateTime.Now.ToString("mm"));
        }

        /// <summary>
        /// Adds a control to the command panel if the control implements the ICommandVisual interface.
        /// The control is positioned based on the current count of controls in the panel.
        /// </summary>
        /// <param name="control">The control to add to the panel.</param>
        private void AddControlToPanel(Control control)
        {
            if (control != null && control is ICommandVisual)
            {
                // Set the location of the control in the panel based on the number of existing controls
                control.Location = new Point(0, commandMacroPanel.Controls.Count * 68);
                commands.Add(control as ICommandVisual);
                commandMacroPanel.Controls.Add(control);
            }
        }

        /// <summary>
        /// Closes the ScheduleEditor form without saving any changes.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Saves the task schedule and closes the ScheduleEditor form.
        /// A new task scheduler is created, and all added commands are saved into the task scheduler.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        private void saveAndExit_Click(object sender, EventArgs e)
        {
            // Create a new task scheduler with the specified name and time
            TaskScheduler taskScheduler = new TaskScheduler(guna2TextBox1.Text, (int)guna2NumericUpDown1.Value, (int)guna2NumericUpDown2.Value);

            // Add all commands to the task scheduler
            foreach (ICommandVisual command in commands)
            {
                TaskHandler taskHandler = new TaskHandler(command.GetCommand());
                taskScheduler.AddTask(taskHandler);
            }

            // Add the task scheduler to the main form
            Form1.Singleton.AddTaskScheduler(taskScheduler);
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
