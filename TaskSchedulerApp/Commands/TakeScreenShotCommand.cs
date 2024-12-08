using System.Drawing.Imaging;

namespace TaskSchedulerApp.Commands
{
    /// <summary>
    /// Command to take a screenshot and save it as a PNG file.
    /// Implements the ITaskCommand interface and captures the screen or a specified region.
    /// </summary>
    public class TakeScreenShotCommand : ITaskCommand
    {
        /// <summary>
        /// The file name where the screenshot will be saved.
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// The rectangle area of the screen to capture.
        /// By default, this captures the entire screen.
        /// </summary>
        public Rectangle ScreenshotRect { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TakeScreenShotCommand"/> class.
        /// </summary>
        /// <param name="fileName">The file name where the screenshot will be saved.</param>
        public TakeScreenShotCommand(string fileName)
        {
            FileName = fileName;

            ScreenshotRect = Screen.GetBounds(Point.Empty);
        }

        /// <summary>
        /// Executes the command to take a screenshot and save it as a PNG file.
        /// Logs the screenshot taking operation and saves the screenshot to the specified file name.
        /// </summary>
        /// <returns>A Task representing the asynchronous operation.</returns>
        public async Task ExecuteAsync()
        {
            BasicConsole.logger.LogMessage(AbstractLogger.INFO, "Taking screenshot: " + FileName);

            // Capture the screen as a bitmap
            Bitmap bmp = BitBLTCapture(ScreenshotRect.X, ScreenshotRect.Y, ScreenshotRect.Width, ScreenshotRect.Height);

            bmp.Save(FileName, ImageFormat.Png);
        }

        /// <summary>
        /// Captures a screenshot of a specified area on the screen.
        /// </summary>
        /// <param name="_x">The x-coordinate of the top-left corner of the capture area.</param>
        /// <param name="_y">The y-coordinate of the top-left corner of the capture area.</param>
        /// <param name="_width">The width of the capture area.</param>
        /// <param name="_height">The height of the capture area.</param>
        /// <returns>A Bitmap containing the screenshot of the specified area.</returns>
        private static Bitmap BitBLTCapture(int _x, int _y, int _width, int _height)
        {
            Bitmap bmpScreenshot = new Bitmap(_width, _height, PixelFormat.Format32bppArgb);
            Graphics gfxScreenshot = Graphics.FromImage(bmpScreenshot);
            gfxScreenshot.CopyFromScreen(_x, _y, 0, 0, new Size(_width, _height), CopyPixelOperation.SourceCopy);
            gfxScreenshot.Dispose();
            return bmpScreenshot;
        }
    }
}
