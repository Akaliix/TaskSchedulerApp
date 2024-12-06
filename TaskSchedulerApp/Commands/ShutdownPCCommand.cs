using System.Diagnostics;

namespace TaskSchedulerApp.Commands
{
    public class ShutdownPCCommand : ITaskCommand
    {
        public async Task ExecuteAsync()
        {
            BasicConsole.logger.LogMessage(AbstractLogger.INFO,"Shutting down PC in 3 seconds!");
            await Task.Delay(3000);
            Process.Start("shutdown", "/s /t 0");
        }
    }
}
