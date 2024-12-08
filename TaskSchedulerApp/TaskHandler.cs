namespace TaskSchedulerApp
{
    /// <summary>
    /// A class responsible for handling tasks using the chain of responsibility pattern.
    /// It delegates the task to the next handler in the chain if available.
    /// </summary>
    public class TaskHandler
    {
        /// <summary>
        /// The next handler in the chain.
        /// </summary>
        public TaskHandler? _nextHandler;

        /// <summary>
        /// The command that this handler will execute.
        /// </summary>
        private readonly ITaskCommand _taskCommand;

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskHandler"/> class with the specified task command.
        /// </summary>
        /// <param name="taskCommand">The task command to execute.</param>
        public TaskHandler(ITaskCommand taskCommand)
        {
            _taskCommand = taskCommand;
        }

        /// <summary>
        /// Sets the next handler in the chain of responsibility.
        /// </summary>
        /// <param name="nextHandler">The next task handler to be set.</param>
        public void SetNext(TaskHandler nextHandler)
        {
            _nextHandler = nextHandler;
        }

        /// <summary>
        /// Handles the task asynchronously by delegating the command to the remote control and executing it.
        /// If a next handler exists in the chain, it will delegate the task further.
        /// </summary>
        public async Task HandleAsync()
        {
            try
            {
                // Set the current task command to the remote control and execute it.
                RemoteControl.Singleton.setCommand(_taskCommand);
                await RemoteControl.Singleton.pressButton();
            }
            catch (Exception ex)
            {
                // Log any errors that occur during task execution.
                BasicConsole.logger.LogMessage(AbstractLogger.ERROR, ex.Message);
                return;
            }

            // If there's a next handler, delegate the task to it.
            if (_nextHandler != null)
            {
                await _nextHandler.HandleAsync();
            }
        }
    }
}
