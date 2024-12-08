using TaskSchedulerApp.Loggers;

namespace TaskSchedulerApp
{
    /// <summary>
    /// A static class that simulates a console output system with different log levels and colors.
    /// It uses the Chain of Responsibility pattern to handle different log messages (error, success, info).
    /// </summary>
    public static class BasicConsole
    {
        /// <summary>
        /// A structure to represent a line of text with an associated color.
        /// </summary>
        public struct LineStruct
        {
            public Color color;
            public string text;

            /// <summary>
            /// Constructor to initialize a new line with text and color.
            /// </summary>
            /// <param name="text">The text of the line.</param>
            /// <param name="color">The color of the text.</param>
            public LineStruct(string text, Color color)
            {
                this.text = text;
                this.color = color;
            }
        }

        /// <summary>
        /// A logger that will be used to log messages.
        /// The logger follows a chain of responsibility pattern with three levels: error, success, and info.
        /// </summary>
        public static AbstractLogger logger;

        /// <summary>
        /// Static constructor that sets up the chain of responsibility for logging.
        /// The loggers are set in the order: ErrorLogger -> SuccessLogger -> InfoLogger.
        /// </summary>
        static BasicConsole()
        {
            AbstractLogger errorLogger = new ErrorLogger(AbstractLogger.ERROR);
            AbstractLogger successLogger = new SuccessLogger(AbstractLogger.SUCCESS);
            AbstractLogger infoLogger = new InfoLogger(AbstractLogger.INFO);

            // Setting the chain of responsibility
            errorLogger.SetNextLogger(successLogger);  // Error logger hands off to success logger
            successLogger.SetNextLogger(infoLogger);   // Success logger hands off to info logger

            logger = errorLogger; // Starting point for logging is the error logger
        }

        /// <summary>
        /// A list to store all the lines that need to be displayed in the console.
        /// </summary>
        public static List<LineStruct> lines = new List<LineStruct>();

        /// <summary>
        /// A flag to check if the console has been modified (i.e., a new line has been added).
        /// </summary>
        public static bool isDirty = false;

        /// <summary>
        /// Adds a line to the list of lines to be displayed with a timestamp and color.
        /// The message is prepended with the current time (HH:mm:ss).
        /// </summary>
        /// <param name="message">The message to be displayed.</param>
        /// <param name="color">The color of the text.</param>
        public static void WriteLine(string message, Color color)
        {
            // Adding a new line to the lines list with the current time, message, and color
            lines.Add(
                new LineStruct(string.Join("", DateTime.Now.ToString("[HH:mm:ss] "), message, Environment.NewLine), color)
            );
            isDirty = true;  // Flagging that the console has new content
        }
    }
}
