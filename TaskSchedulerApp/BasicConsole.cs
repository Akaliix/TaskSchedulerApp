using TaskSchedulerApp.Loggers;

namespace TaskSchedulerApp
{
    public static class BasicConsole
    {
        public struct LineStruct
        {
            public Color color;
            public string text;

            public LineStruct(string text, Color color)
            {
                this.text = text;
                this.color = color;
            }
        }

        public static AbstractLogger logger;

        static BasicConsole()
        {
            AbstractLogger errorLogger = new ErrorLogger(AbstractLogger.ERROR);
            AbstractLogger successLogger = new SuccessLogger(AbstractLogger.SUCCESS);
            AbstractLogger infoLogger = new InfoLogger(AbstractLogger.INFO);

            errorLogger.SetNextLogger(successLogger);
            successLogger.SetNextLogger(infoLogger);

            logger = errorLogger;
        }

        public static List<LineStruct> lines = new List<LineStruct>();
        public static bool isDirty = false;
        public static void WriteLine(string message, Color color)
        {
            lines.Add(
                new LineStruct(string.Join("", DateTime.Now.ToString("[HH:mm:ss] "), message, Environment.NewLine), color)
            );
            isDirty = true;
        }
    }
}
