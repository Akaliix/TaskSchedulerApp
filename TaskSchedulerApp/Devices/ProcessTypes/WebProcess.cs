using System.Diagnostics;
using System.Runtime.InteropServices;

namespace TaskSchedulerApp.Devices.ProcessTypes
{
    /// <summary>
    /// Represents a web process that opens a specified URL in the default browser.
    /// Inherits from <see cref="BaseProcess"/> and overrides the <see cref="Start"/> method to initiate a web page opening.
    /// </summary>
    public class WebProcess : BaseProcess
    {
        /// <summary>
        /// The URL to open in the default web browser.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WebProcess"/> class with the given URL.
        /// The URL is used to open a web page in the default browser.
        /// </summary>
        /// <param name="Url">The URL to be opened by the process.</param>
        public WebProcess(string Url) : base("Web Process: " + Url)
        {
            this.Url = Url;
        }

        /// <summary>
        /// Starts the web process by opening the specified URL in the default web browser.
        /// If the URL doesn't start with "http://" or "https://", it adds a Google search query.
        /// </summary>
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

        /// <summary>
        /// Attempts to open the provided URL in the default browser based on the platform.
        /// Supports Windows, Linux, and macOS.
        /// </summary>
        /// <param name="url">The URL to open.</param>
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
