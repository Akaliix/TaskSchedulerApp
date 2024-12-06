using System.Diagnostics;
using System.Runtime.InteropServices;

namespace TaskSchedulerApp.Devices.ProcessTypes
{
    public class WebProcess : BaseProcess
    {
        public string Url { get; set; }
        public WebProcess(string Url) : base("Web Process: " + Url)
        {
            this.Url = Url;
        }
        public override void Start()
        {
            BasicConsole.logger.LogMessage(AbstractLogger.INFO, Name + " Starting...");
            if (!Url.StartsWith("http://") && !Url.StartsWith("https://"))
            {
                Url = "https://www.google.com/search?q=" + Uri.EscapeDataString(Url);
            }
            OpenUrl(Url);
            BasicConsole.logger.LogMessage(AbstractLogger.SUCCESS, Name + " Started.");
        }

        private void OpenUrl(string url)
        {
            try
            {
                Process.Start(url);
            }
            catch
            {
                // hack because of this: https://github.com/dotnet/corefx/issues/10361
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    url = url.Replace("&", "^&");
                    Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    Process.Start("xdg-open", url);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    Process.Start("open", url);
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
