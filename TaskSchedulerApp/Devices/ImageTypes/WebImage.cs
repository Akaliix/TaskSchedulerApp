using System.IO;
using System.Net.Http;

namespace TaskSchedulerApp.Devices.ImageTypes
{
    /// <summary>
    /// A concrete implementation of the <see cref="BaseImage"/> class for handling web-based images.
    /// Provides methods for loading, saving, and verifying web image files.
    /// </summary>
    public class WebImage : BaseImage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WebImage"/> class with the given image URL.
        /// </summary>
        /// <param name="imagePath">The URL of the image to be handled.</param>
        public WebImage(string imagePath) : base(imagePath)
        { }

        /// <summary>
        /// Saves the image to the specified path in BMP format.
        /// Overrides the abstract method from the <see cref="BaseImage"/> class to provide saving functionality.
        /// </summary>
        /// <param name="pathToSave">The file path where the image should be saved.</param>
        public override void SaveImage(string pathToSave)
        {
            Image.Save(pathToSave, System.Drawing.Imaging.ImageFormat.Bmp);
        }

        /// <summary>
        /// Verifies whether the image URL is valid.
        /// This method checks if the image path is a valid HTTP or HTTPS URL.
        /// </summary>
        /// <returns>True if the image path starts with "http", indicating a web-based image, otherwise false.</returns>
        public override bool VerifyImagePath()
        {
            return ImagePath.StartsWith("http");
        }

        /// <summary>
        /// Loads the image from the web using the specified URL.
        /// Overrides the abstract method from the <see cref="BaseImage"/> class to provide image loading functionality.
        /// </summary>
        /// <returns>A Task representing the asynchronous operation of loading the image from the web.</returns>
        public override async Task LoadImage()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(ImagePath);
                response.EnsureSuccessStatusCode();
                using (Stream stream = await response.Content.ReadAsStreamAsync())
                {
                    Image = System.Drawing.Image.FromStream(stream);
                }
            }
        }
    }
}
