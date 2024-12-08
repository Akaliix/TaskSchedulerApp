using System.Diagnostics;

namespace TaskSchedulerApp.Commands
{
    /// <summary>
    /// Command to shut down the PC.
    /// Implements the ITaskCommand interface and initiates a system shutdown after a delay.
    /// </summary>
    public class ShutdownPCCommand : ITaskCommand
    {
        /// <summary>
        /// Executes the command to shut down the PC asynchronously.
        /// Logs the shutdown message, waits for 3 seconds, and then triggers a shutdown.
        /// </summary>
        /// <returns>A Task representing the asynchronous operation.</returns>
        public async Task ExecuteAsync()
        {
            BasicConsole.logger.LogMessage(AbstractLogger.INFO, "Shutting down PC in 3 seconds!");
            await Task.Delay(3000);

            // Execute the shutdown command to shut down the system immediately
            Process.Start("shutdown", "/s /t 0");
        }
    }
}
