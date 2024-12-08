namespace TaskSchedulerApp
{
    /// <summary>
    /// A static class that contains configuration settings for the task scheduler.
    /// </summary>
    public static class TaskSchedulerSettings
    {
        /// <summary>
        /// The interval (in milliseconds) between each task execution check.
        /// Default is 1000 milliseconds (1 second).
        /// </summary>
        public static int TaskInterval { get; set; } = 1000;


        public static string EmailServer { get; set; } = "smtp-relay.brevo.com";
        public static int EmailServerPort { get; set; } = 587;
        public static string EmailServerUsername { get; set; } = "814bb3001@smtp-brevo.com";
        public static string EmailServerPassword { get; set; } = "kY8wAcCEa6qbyg5x";
        public static string EmailFrom { get; set; } = "mehmetexpress3@gmail.com";
    }
}
