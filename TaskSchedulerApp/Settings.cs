namespace TaskSchedulerApp
{
    public static class TaskSchedulerSettings
    {
        public static int TaskInterval { get; set; } = 1000;
        public static string EmailServer { get; set; } = "smtp-relay.brevo.com";
        public static int EmailServerPort { get; set; } = 587;
        public static string EmailServerUsername { get; set; } = "814bb3001@smtp-brevo.com";
        public static string EmailServerPassword { get; set; } = "kY8wAcCEa6qbyg5x";
        public static string EmailFrom { get; set; } = "mehmetexpress3@gmail.com";

        //public static string EmailTo { get; set; }
        //public static string EmailSubject { get; set; }
        //public static string EmailBody { get; set; }
        //public static string ScreenShotPath { get; set; }
        //public static string ShutdownCommand { get; set; }
        //public static string RestartCommand { get; set; }
    }
}
