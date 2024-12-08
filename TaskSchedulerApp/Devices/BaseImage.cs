namespace TaskSchedulerApp.Devices
{
    /// <summary>
    /// Abstract base class for handling image operations.
    /// Provides methods for loading, saving, and verifying images.
    /// </summary>
    public abstract class BaseImage
    {
        /// <summary>
        /// The path to the image file.
        /// </summary>
        internal readonly string ImagePath;

        /// <summary>
        /// The image object itself.
        /// </summary>
        internal System.Drawing.Image Image { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseImage"/> class with the given image path.
        /// </summary>
        /// <param name="imagePath">The file path of the image to be handled.</param>
        public BaseImage(string imagePath)
        {
            ImagePath = imagePath;
        }

        /// <summary>
        /// Asynchronously loads the image from the specified path.
        /// This method should be implemented by subclasses to provide image loading functionality.
        /// </summary>
        /// <returns>A Task representing the asynchronous operation.</returns>
        abstract public Task LoadImage();

        /// <summary>
        /// Saves the current image to the specified path.
        /// This method should be implemented by subclasses to provide image saving functionality.
        /// </summary>
        /// <param name="pathToSave">The file path where the image should be saved.</param>
        abstract public void SaveImage(string pathToSave);

        /// <summary>
        /// Verifies whether the image path is valid and the image exists.
        /// This method should be implemented by subclasses to provide image path verification functionality.
        /// </summary>
        /// <returns>True if the image path is valid, otherwise false.</returns>
        abstract public bool VerifyImagePath();
    }
}
