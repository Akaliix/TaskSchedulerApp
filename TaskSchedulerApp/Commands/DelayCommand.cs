namespace TaskSchedulerApp.Commands
{
    public class DelayCommand : ITaskCommand
    {
        public float _seconds;
        public DelayCommand(float seconds)
        {
            _seconds = seconds;
        }
        public async Task ExecuteAsync()
        {
            BasicConsole.logger.LogMessage(AbstractLogger.INFO, _seconds + " seconds delay started!");
            await Task.Delay((int)(_seconds * 1000));
            BasicConsole.logger.LogMessage(AbstractLogger.INFO, _seconds + " seconds delay ended!");
        }
    }
}
