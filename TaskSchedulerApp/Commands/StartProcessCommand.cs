using TaskSchedulerApp.Devices;

namespace TaskSchedulerApp.Commands
{
    /// <summary>
    /// Command to start a process.
    /// Implements the ITaskCommand interface and starts a given process asynchronously.
    /// </summary>
    public class StartProcessCommand : ITaskCommand
    {
        /// <summary>
        /// The process object that will be started by the command.
        /// </summary>
        private BaseProcess _process;

        /// <summary>
        /// Initializes a new instance of the <see cref="StartProcessCommand"/> class.
        /// </summary>
        /// <param name="process">The process object to be started.</param>
        public StartProcessCommand(BaseProcess process)
        {
            _process = process;
        }

        /// <summary>
        /// Executes the command asynchronously to start the process.
        /// Starts the process by invoking its Start method on a separate task.
        /// </summary>
        /// <returns>A Task representing the asynchronous operation of starting the process.</returns>
        public async Task ExecuteAsync()
        {
            // Run the Start method of the process asynchronously on a separate thread
            await Task.Run(() => _process.Start());
        }
    }
}
