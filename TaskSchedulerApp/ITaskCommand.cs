namespace TaskSchedulerApp
{
    // Command Pattern - Interface
    public interface ITaskCommand
    {
        public Task ExecuteAsync();
    }
}
