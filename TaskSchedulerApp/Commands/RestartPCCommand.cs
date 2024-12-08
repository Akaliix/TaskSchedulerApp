using System.Diagnostics;

namespace TaskSchedulerApp.Commands
{
    /// <summary>
    /// Command to restart the PC.
    /// Implements the ITaskCommand interface and initiates a system restart after a delay.
    /// </summary>
    public class RestartPCCommand : ITaskCommand
    {
        /// <summary>
        /// Executes the command to restart the PC asynchronously.
        /// Logs the restart message, waits for 3 seconds, and then triggers a restart.
        /// </summary>
        /// <returns>A Task representing the asynchronous operation.</returns>
        public async Task ExecuteAsync()
        {
            BasicConsole.logger.LogMessage(AbstractLogger.INFO, "Restarting PC in 3 seconds!");
            await Task.Delay(3000);

            // Execute the shutdown command to restart the system immediately
            Process.Start("shutdown", "/r /t 0");
        }
    }
}
