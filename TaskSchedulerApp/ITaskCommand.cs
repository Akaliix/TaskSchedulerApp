namespace TaskSchedulerApp
{
    /// <summary>
    /// ITaskCommand interface defines a contract for all command objects in the system.
    /// Any class that implements this interface must provide the implementation of the ExecuteAsync method.
    /// </summary>
    public interface ITaskCommand
    {
        /// <summary>
        /// Executes a task asynchronously.
        /// </summary>
        /// <returns>A Task representing the asynchronous operation.</returns>
        public Task ExecuteAsync();
    }
}
