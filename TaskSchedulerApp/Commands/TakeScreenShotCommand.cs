using System.Drawing.Imaging;
namespace TaskSchedulerApp.Commands
{
    public class TakeScreenShotCommand : ITaskCommand
    {
        public string FileName { get; set; }
        public Rectangle ScreenshotRect { get; set; }

        public TakeScreenShotCommand(string fileName)
        {
            FileName = fileName;

            ScreenshotRect = Screen.GetBounds(Point.Empty);
        }

        public async Task ExecuteAsync()
        {
            BasicConsole.logger.LogMessage(AbstractLogger.INFO, "Taking screenshot: " + FileName);
            Bitmap bmp = BitBLTCapture(ScreenshotRect.X, ScreenshotRect.Y, ScreenshotRect.Width, ScreenshotRect.Height);
            bmp.Save(FileName, ImageFormat.Png);
        }

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
