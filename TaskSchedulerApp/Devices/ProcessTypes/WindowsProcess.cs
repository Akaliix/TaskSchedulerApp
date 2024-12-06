namespace TaskSchedulerApp.Devices.ProcessTypes
{
    public class WindowsProcess : BaseProcess
    {
        public string Path { get; set; }
        public WindowsProcess(string path) : base("Windows Process: " + path)
        {
            Path = path;
        }
        public override void Start()
        {
            BasicConsole.logger.LogMessage(AbstractLogger.INFO, Name + " Starting...");
            System.Diagnostics.Process.Start(Path);
            BasicConsole.logger.LogMessage(AbstractLogger.SUCCESS, Name + " Started.");
        }
    }
}
