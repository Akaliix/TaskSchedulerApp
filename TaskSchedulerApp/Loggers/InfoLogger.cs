namespace TaskSchedulerApp.Loggers
{
    public class InfoLogger : AbstractLogger
    {
        public InfoLogger(int level)
        {
            this.level = level;
        }

        protected override void Write(string message)
        {
            BasicConsole.WriteLine(message, Color.Gray);
        }
    }
}
