using Microsoft.Win32;
using System.IO;
using System.Runtime.InteropServices;
using TaskSchedulerApp.Devices;

namespace TaskSchedulerApp.Commands
{
    public class ChangeWallpaperCommand : ITaskCommand
    {
        private static string tempPath = Path.Combine(Path.GetTempPath(), "wallpaper.bmp");
        public BaseImage baseImage { get; set; }
        public Wallpaper.Style style { get; set; }

        public ChangeWallpaperCommand(BaseImage baseImage, Wallpaper.Style style)
        {
            this.baseImage = baseImage;
            this.style = style;
        }

        public async Task ExecuteAsync()
        {
            //verify
            BasicConsole.logger.LogMessage(AbstractLogger.INFO, "Verifying wallpaper path!");
            if (!baseImage.VerifyImagePath())
            {
                BasicConsole.logger.LogMessage(AbstractLogger.ERROR, "Invalid wallpaper path!");
                return;
            }
            BasicConsole.logger.LogMessage(AbstractLogger.SUCCESS, "Wallpaper path verified.");
            BasicConsole.logger.LogMessage(AbstractLogger.INFO, "Loading wallpaper!");

            try
            {
                await baseImage.LoadImage();
            }
            catch (Exception)
            {
                BasicConsole.logger.LogMessage(AbstractLogger.ERROR, "Failed to load wallpaper!");
                return;
            }

            BasicConsole.logger.LogMessage(AbstractLogger.SUCCESS, "Wallpaper loaded successfully.");
            baseImage.SaveImage(tempPath);
            BasicConsole.logger.LogMessage(AbstractLogger.INFO, "Changing wallpaper!");
            Wallpaper.Set(tempPath, style);
            BasicConsole.logger.LogMessage(AbstractLogger.SUCCESS, "Wallpaper changed successfully.");
        }
    }
    public static class Wallpaper
    {
        const int SPI_SETDESKWALLPAPER = 20;
        const int SPIF_UPDATEINIFILE = 0x01;
        const int SPIF_SENDWININICHANGE = 0x02;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

        public enum Style : int
        {
            Fill,
            Fit,
            Span,
            Stretch,
            Tile,
            Center
        }

        public static bool Set(string path, Style style)
        {
            RegistryKey? key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);
            if (key == null) return false;

            if (style == Style.Fill)
            {
                key.SetValue(@"WallpaperStyle", 10.ToString());
                key.SetValue(@"TileWallpaper", 0.ToString());
            }
            else if (style == Style.Fit)
            {
                key.SetValue(@"WallpaperStyle", 6.ToString());
                key.SetValue(@"TileWallpaper", 0.ToString());
            }
            else if (style == Style.Span) // Windows 8 or newer only!
            {
                key.SetValue(@"WallpaperStyle", 22.ToString());
                key.SetValue(@"TileWallpaper", 0.ToString());
            }
            else if (style == Style.Stretch)
            {
                key.SetValue(@"WallpaperStyle", 2.ToString());
                key.SetValue(@"TileWallpaper", 0.ToString());
            }
            else if (style == Style.Tile)
            {
                key.SetValue(@"WallpaperStyle", 0.ToString());
                key.SetValue(@"TileWallpaper", 1.ToString());
            }
            else if (style == Style.Center)
            {
                key.SetValue(@"WallpaperStyle", 0.ToString());
                key.SetValue(@"TileWallpaper", 0.ToString());
            }

            SystemParametersInfo(SPI_SETDESKWALLPAPER,
                0,
                path,
                SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
            return true;
        }
    }
}
