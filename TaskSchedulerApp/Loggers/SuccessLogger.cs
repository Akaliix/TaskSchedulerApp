namespace TaskSchedulerApp.Loggers
{
    /// <summary>
    /// A concrete implementation of <see cref="AbstractLogger"/> that handles logging success messages.
    /// This logger writes messages with a specific color to indicate successful operations.
    /// </summary>
    public class SuccessLogger : AbstractLogger
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SuccessLogger"/> class with the specified logging level.
        /// </summary>
        /// <param name="level">The logging level that controls the verbosity of the logger.</param>
        public SuccessLogger(int level)
        {
            this.level = level;
        }

        /// <summary>
        /// Writes a success message to the console with a specific color.
        /// This method overrides the <see cref="Write"/> method from the abstract logger class.
        /// </summary>
        /// <param name="message">The message to be logged.</param>
        protected override void Write(string message)
        {
            BasicConsole.WriteLine(message, Color.Green);
        }
    }
}
