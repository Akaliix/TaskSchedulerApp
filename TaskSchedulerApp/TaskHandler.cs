namespace TaskSchedulerApp
{
    public class TaskHandler
    {
        public TaskHandler? _nextHandler;
        private readonly ITaskCommand _taskCommand;

        public TaskHandler(ITaskCommand taskCommand)
        {
            _taskCommand = taskCommand;
        }

        public void SetNext(TaskHandler nextHandler)
        {
            _nextHandler = nextHandler;
        }

        public async Task HandleAsync()
        {
            try
            {
                RemoteControl.Singleton.setCommand(_taskCommand);
                await RemoteControl.Singleton.pressButton();
            }
            catch (Exception ex)
            {
                BasicConsole.logger.LogMessage(AbstractLogger.ERROR, ex.Message);
                return;
            }

            if (_nextHandler != null)
            {
                await _nextHandler.HandleAsync();
            }
        }
    }
}
