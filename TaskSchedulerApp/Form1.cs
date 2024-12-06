namespace TaskSchedulerApp
{
    public partial class Form1 : Form
    {
        private bool isTimerFuncFinish = true;
        private int lastCheckMinute = -1;
        private List<TaskScheduler> taskSchedulers = new List<TaskScheduler>();

        public static Form1? singleton;
        public Form1()
        {
            singleton = this;
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            // Open ScheduleEditor form
            ScheduleEditor scheduleEditor = new ScheduleEditor();
            scheduleEditor.Show();
        }

        public void AddTaskScheduler(TaskScheduler taskScheduler)
        {
            taskSchedulers.Add(taskScheduler);
            listBox1.Items.Add(taskScheduler);
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!isTimerFuncFinish) return;
            isTimerFuncFinish = false;

            try
            {
                if (BasicConsole.isDirty)
                {
                    BasicConsole.isDirty = false;

                    if (richTextBox1.Lines.Length > 1000)
                    {
                        richTextBox1.Text = string.Join(Environment.NewLine, richTextBox1.Lines.Skip(100));
                    }

                    for (int i = 0; i < BasicConsole.lines.Count; i++)
                    {
                        richTextBox1.SelectionStart = richTextBox1.TextLength;
                        richTextBox1.SelectionLength = 0;
                        richTextBox1.SelectionColor = BasicConsole.lines[i].color;
                        richTextBox1.AppendText(BasicConsole.lines[i].text);
                    }

                    BasicConsole.lines.Clear();
                    richTextBox1.SelectionStart = richTextBox1.Text.Length;
                    richTextBox1.ScrollToCaret();
                }
            }
            finally
            {
                isTimerFuncFinish = true;
            }
        }

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

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            this.Focus();
        }

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

        private void button1_Click(object sender, EventArgs e)
        {
        }

    }
}
