namespace TaskSchedulerApp
{
    /// <summary>
    /// The base class for a chain of responsibility pattern implementation in a logging system.
    /// This class defines the core functionality for logging messages at different levels (INFO, SUCCESS, ERROR).
    /// </summary>
    public abstract class AbstractLogger
    {
        public static int INFO = 1;
        public static int SUCCESS = 2;
        public static int ERROR = 3;

        protected int level;

        // The next logger in the chain of responsibility.
        protected AbstractLogger? nextLogger;

        /// <summary>
        /// Sets the next logger in the chain of responsibility.
        /// This allows for passing the log message to the next logger if necessary.
        /// </summary>
        /// <param name="nextLogger">The next logger in the chain to pass messages to.</param>
        public void SetNextLogger(AbstractLogger nextLogger)
        {
            this.nextLogger = nextLogger;
        }

        /// <summary>
        /// Logs a message if the current logger's level is less than or equal to the specified level.
        /// If there is a next logger in the chain, the message will be passed to it as well.
        /// </summary>
        /// <param name="level">The level of the message being logged.</param>
        /// <param name="message">The message to be logged.</param>
        public void LogMessage(int level, String message)
        {
            // Log the message if the level is equal to or greater than the current logger's level
            if (this.level <= level)
            {
                Write(message);
            }
            if (nextLogger != null)
            {
                nextLogger.LogMessage(level, message);
            }
        }

        /// <summary>
        /// Writes the message to the output (to be implemented by subclasses).
        /// This method is abstract, and each subclass should provide its own implementation.
        /// </summary>
        /// <param name="message">The message to be written/logged.</param>
        abstract protected void Write(string message);
    }
}
