namespace TaskSchedulerApp.Loggers
{
    public class ErrorLogger : AbstractLogger
    {
        public ErrorLogger(int level)
        {
            this.level = level;
        }

        protected override void Write(string message)
        {
            BasicConsole.WriteLine(message, Color.Firebrick);
        }
    }
}
