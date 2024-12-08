using System.IO;

namespace TaskSchedulerApp.Devices.ImageTypes
{
    /// <summary>
    /// A concrete implementation of the <see cref="BaseImage"/> class for handling local image files.
    /// Provides methods for loading, saving, and verifying local image files.
    /// </summary>
    public class LocalImage : BaseImage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LocalImage"/> class with the given image path.
        /// </summary>
        /// <param name="imagePath">The file path of the local image to be handled.</param>
        public LocalImage(string imagePath) : base(imagePath)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="LocalImage"/> class with the given image path.
        /// </summary>
        /// <param name="imagePath">The file path of the local image to be handled.</param>
        public override async void SaveImage(string pathToSave)
        {
            Image.Save(pathToSave, System.Drawing.Imaging.ImageFormat.Bmp);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LocalImage"/> class with the given image path.
        /// </summary>
        /// <param name="imagePath">The file path of the local image to be handled.</param>
        public override bool VerifyImagePath()
        {
            return File.Exists(ImagePath);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LocalImage"/> class with the given image path.
        /// </summary>
        /// <param name="imagePath">The file path of the local image to be handled.</param>
        public override async Task LoadImage()
        {
            Image = System.Drawing.Image.FromFile(ImagePath);
        }
    }
}
