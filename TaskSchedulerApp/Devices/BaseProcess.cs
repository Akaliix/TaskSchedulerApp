namespace TaskSchedulerApp.Devices
{
    /// <summary>
    /// Represents the base class for processes. 
    /// It defines the structure for different types of processes (such as Windows processes or web processes).
    /// </summary>
    public abstract class BaseProcess
    {
        /// <summary>
        /// The name of the process. This could represent the process's display name or identifier.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseProcess"/> class with the specified name.
        /// </summary>
        /// <param name="name">The name of the process.</param>
        public BaseProcess(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Starts the process. This method must be implemented in derived classes 
        /// to define how the specific type of process should be started.
        /// </summary>
        public abstract void Start();
    }
}
