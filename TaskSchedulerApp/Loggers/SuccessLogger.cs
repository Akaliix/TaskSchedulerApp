namespace TaskSchedulerApp.Loggers
{
    public class SuccessLogger : AbstractLogger
    {
        public SuccessLogger(int level)
        {
            this.level = level;
        }

        protected override void Write(string message)
        {
            BasicConsole.WriteLine(message, Color.Green);
        }
    }
}
