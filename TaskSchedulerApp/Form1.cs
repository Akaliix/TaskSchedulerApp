namespace TaskSchedulerApp
{
    /// <summary>
    /// Main form class for the task scheduler application.
    /// Provides the user interface to interact with scheduled tasks.
    /// </summary>
    public partial class Form1 : Form
    {
        // Flag to ensure that the timer function completes before running again.
        private bool isTimerFuncFinish = true;

        // Variable to track the last checked minute, preventing redundant checks within the same minute.
        private int lastCheckMinute = -1;

        // List of task schedulers to store all scheduled tasks.
        private List<TaskScheduler> taskSchedulers = new List<TaskScheduler>();

        private static Form1? singleton;
        /// <summary>
        /// Static reference to the current instance of Form1.
        /// </summary>
        public static Form1 Singleton
        {
            get
            {
                if (singleton == null)
                {
                    throw new InvalidOperationException("Form1 instance not created");
                }
                return singleton;
            }
        }

        /// <summary>
        /// Constructor for the form.
        /// Initializes the singleton instance and UI components.
        /// </summary>
        public Form1()
        {
            if (singleton == null)
            {
                singleton = this;
            }

            InitializeComponent();
        }

        /// <summary>
        /// Event handler for the "Add Task" button click.
        /// Opens the ScheduleEditor form to allow the user to create or edit tasks.
        /// </summary>
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            // Open ScheduleEditor form
            ScheduleEditor scheduleEditor = new ScheduleEditor();
            scheduleEditor.Show();
        }

        /// <summary>
        /// Adds a new task scheduler to the list and displays it in the list box.
        /// </summary>
        /// <param name="taskScheduler">The task scheduler to add.</param>
        public void AddTaskScheduler(TaskScheduler taskScheduler)
        {
            taskSchedulers.Add(taskScheduler);
            listBox1.Items.Add(taskScheduler);
        }

        /// <summary>
        /// Timer tick event handler for updating the UI with new log messages.
        /// Ensures the rich text box is updated with log information periodically.
        /// </summary>
        private void timer1_Tick(object sender, EventArgs e)
        {
            // Check if a previous timer function is still running
            if (!isTimerFuncFinish) return;

            // Set the flag to false to indicate the timer function is running
            isTimerFuncFinish = false;

            try
            {
                // Check if new log messages need to be displayed in the rich text box
                if (BasicConsole.isDirty)
                {
                    BasicConsole.isDirty = false;

                    // If there are more than 1000 lines in the log, trim the older lines
                    if (richTextBox1.Lines.Length > 1000)
                    {
                        richTextBox1.Text = string.Join(Environment.NewLine, richTextBox1.Lines.Skip(100));
                    }

                    // Add all new log messages to the rich text box
                    for (int i = 0; i < BasicConsole.lines.Count; i++)
                    {
                        richTextBox1.SelectionStart = richTextBox1.TextLength;
                        richTextBox1.SelectionLength = 0;
                        richTextBox1.SelectionColor = BasicConsole.lines[i].color;

                        // Append the new log message to the rich text box
                        richTextBox1.AppendText(BasicConsole.lines[i].text);
                    }

                    // Clear the log message list after adding them to the UI
                    BasicConsole.lines.Clear();

                    // Ensure the rich text box is scrolled to the bottom after appending new messages
                    richTextBox1.SelectionStart = richTextBox1.Text.Length;
                    richTextBox1.ScrollToCaret();
                }
            }
            finally
            {
                isTimerFuncFinish = true;
            }
        }

        /// <summary>
        /// Event handler for the "Delete Task" button click.
        /// Removes the selected task scheduler from the list and updates the UI.
        /// </summary>
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            // Delete selected task scheduler
            if (listBox1.SelectedItem != null)
            {
                TaskScheduler taskScheduler = (TaskScheduler)listBox1.SelectedItem;
                taskSchedulers.Remove(taskScheduler);
                listBox1.Items.Remove(taskScheduler);
                listBox1.SelectedIndex = -1;
            }
            this.ActiveControl = null;
            this.Focus();
        }

        /// <summary>
        /// Event handler when the form loads.
        /// Ensures no control is focused when the form loads.
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            this.Focus();
        }

        /// <summary>
        /// Timer tick event handler for checking if any tasks need to be executed.
        /// Runs every minute to check the scheduled tasks and execute them.
        /// </summary>
        private void timer2_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            if (lastCheckMinute == now.Minute) return;
            lastCheckMinute = now.Minute;
            foreach (TaskScheduler taskScheduler in taskSchedulers)
            {
                if (taskScheduler._hour == now.Hour && taskScheduler._minute == now.Minute)
                {
                    _ = taskScheduler.ExecuteAllAsync();
                }
            }
        }
    }
}
