using System.Diagnostics;

namespace TaskSchedulerApp.Commands
{
    public class RestartPCCommand : ITaskCommand
    {
        public async Task ExecuteAsync()
        {
            BasicConsole.logger.LogMessage(AbstractLogger.INFO,"Restarting PC in 3 seconds!");
            await Task.Delay(3000);
            Process.Start("shutdown", "/r /t 0");
        }
    }
}
