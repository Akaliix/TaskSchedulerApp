using TaskSchedulerApp.Devices;

namespace TaskSchedulerApp.Commands
{
    public class StartProcessCommand : ITaskCommand
    {
        private BaseProcess _process;
        public StartProcessCommand(BaseProcess process)
        {
            _process = process;
        }

        public async Task ExecuteAsync()
        {
            await Task.Run(() => _process.Start());
        }
    }
}
