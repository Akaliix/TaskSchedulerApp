namespace TaskSchedulerApp.Commands
{
    /// <summary>
    /// Command to introduce a delay in task execution.
    /// Implements the ITaskCommand interface and introduces a delay in the execution flow.
    /// </summary>
    public class DelayCommand : ITaskCommand
    {
        /// <summary>
        /// The number of seconds to delay.
        /// </summary>
        public float _seconds;

        /// <summary>
        /// Initializes a new instance of the <see cref="DelayCommand"/> class.
        /// </summary>
        /// <param name="seconds">The number of seconds to wait before proceeding.</param>
        public DelayCommand(float seconds)
        {
            _seconds = seconds;
        }

        /// <summary>
        /// Executes the delay command asynchronously.
        /// Logs the start and end of the delay.
        /// </summary>
        /// <returns>A Task representing the asynchronous operation.</returns>
        public async Task ExecuteAsync()
        {
            BasicConsole.logger.LogMessage(AbstractLogger.INFO, _seconds + " seconds delay started!");

            // Wait asynchronously for the specified amount of time (converted from seconds to milliseconds)
            await Task.Delay((int)(_seconds * 1000));


            BasicConsole.logger.LogMessage(AbstractLogger.INFO, _seconds + " seconds delay ended!");
        }
    }
}
