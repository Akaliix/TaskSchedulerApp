namespace TaskSchedulerApp.Devices.ProcessTypes
{
    /// <summary>
    /// Represents a Windows process that starts an executable or a script from a specified file path.
    /// Inherits from <see cref="BaseProcess"/> and overrides the <see cref="Start"/> method to initiate the process.
    /// </summary>
    public class WindowsProcess : BaseProcess
    {
        /// <summary>
        /// The file path of the executable or script to run.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WindowsProcess"/> class with the given file path.
        /// The file path is used to start a process (executable or script).
        /// </summary>
        /// <param name="path">The file path of the executable or script to run.</param>
        public WindowsProcess(string path) : base("Windows Process: " + path)
        {
            Path = path;
        }

        /// <summary>
        /// Starts the Windows process by executing the specified file at <see cref="Path"/>.
        /// </summary>
        public override void Start()
        {
            BasicConsole.logger.LogMessage(AbstractLogger.INFO, Name + " Starting...");
            System.Diagnostics.Process.Start(Path);
            BasicConsole.logger.LogMessage(AbstractLogger.SUCCESS, Name + " Started.");
        }
    }
}
