using Microsoft.Win32;
using System.IO;
using System.Runtime.InteropServices;
using TaskSchedulerApp.Devices;

namespace TaskSchedulerApp.Commands
{
    /// <summary>
    /// Command to change the desktop wallpaper.
    /// Implements the ITaskCommand interface and performs actions related to wallpaper change.
    /// </summary>
    public class ChangeWallpaperCommand : ITaskCommand
    {
        // Path for temporary wallpaper storage
        private static string tempPath = Path.Combine(Path.GetTempPath(), "wallpaper.bmp");

        /// <summary>
        /// Base image object representing the wallpaper image.
        /// </summary>
        public BaseImage baseImage { get; set; }

        /// <summary>
        /// The style of wallpaper (e.g., Fill, Fit, Stretch).
        /// </summary>
        public Wallpaper.Style style { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeWallpaperCommand"/> class.
        /// </summary>
        /// <param name="baseImage">The image to be set as wallpaper.</param>
        /// <param name="style">The style of wallpaper.</param>
        public ChangeWallpaperCommand(BaseImage baseImage, Wallpaper.Style style)
        {
            this.baseImage = baseImage;
            this.style = style;
        }

        /// <summary>
        /// Executes the command asynchronously to change the wallpaper.
        /// Verifies the image, loads it, and then sets the wallpaper with the specified style.
        /// </summary>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        public async Task ExecuteAsync()
        {
            // Log the verification process
            BasicConsole.logger.LogMessage(AbstractLogger.INFO, "Verifying wallpaper path!");

            // Verify if the image path is valid
            if (!baseImage.VerifyImagePath())
            {
                BasicConsole.logger.LogMessage(AbstractLogger.ERROR, "Invalid wallpaper path!");
                return;
            }
            BasicConsole.logger.LogMessage(AbstractLogger.SUCCESS, "Wallpaper path verified.");
            BasicConsole.logger.LogMessage(AbstractLogger.INFO, "Loading wallpaper!");

            try
            {
                // Attempt to load the image asynchronously
                await baseImage.LoadImage();
            }
            catch (Exception)
            {
                // Log the error if loading fails
                BasicConsole.logger.LogMessage(AbstractLogger.ERROR, "Failed to load wallpaper!");
                return;
            }

            BasicConsole.logger.LogMessage(AbstractLogger.SUCCESS, "Wallpaper loaded successfully.");

            // Save the loaded image temporarily
            baseImage.SaveImage(tempPath);
            BasicConsole.logger.LogMessage(AbstractLogger.INFO, "Changing wallpaper!");

            // Change the wallpaper using the Wallpaper class
            Wallpaper.Set(tempPath, style);
            BasicConsole.logger.LogMessage(AbstractLogger.SUCCESS, "Wallpaper changed successfully.");
        }
    }

    /// <summary>
    /// Provides methods to set the wallpaper with various styles.
    /// </summary>
    public static class Wallpaper
    {
        // Constants for wallpaper setting
        const int SPI_SETDESKWALLPAPER = 20;
        const int SPIF_UPDATEINIFILE = 0x01;
        const int SPIF_SENDWININICHANGE = 0x02;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

        /// <summary>
        /// Enum to define different wallpaper styles.
        /// </summary>
        public enum Style : int
        {
            Fill,      // Fill the screen with the image
            Fit,       // Fit the image within the screen
            Span,      // Span the image across multiple monitors (Windows 8 or newer)
            Stretch,   // Stretch the image to fill the screen
            Tile,      // Tile the image across the screen
            Center     // Center the image on the screen
        }

        /// <summary>
        /// Sets the desktop wallpaper to the specified image path with the given style.
        /// </summary>
        /// <param name="path">The file path of the wallpaper image.</param>
        /// <param name="style">The style in which to display the wallpaper.</param>
        /// <returns>True if the wallpaper was successfully set; otherwise, false.</returns>
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
