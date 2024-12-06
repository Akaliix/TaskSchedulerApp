namespace TaskSchedulerApp.Devices
{
    public abstract class BaseProcess
    {
        public string Name { get; set; }
        public BaseProcess(string name)
        {
            Name = name;
        }

        public abstract void Start();
    }
}
