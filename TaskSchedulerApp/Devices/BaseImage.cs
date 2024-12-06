namespace TaskSchedulerApp.Devices
{
    public abstract class BaseImage
    {
        internal readonly string ImagePath;
        internal System.Drawing.Image Image { get; set; }

        public BaseImage(string imagePath)
        {
            ImagePath = imagePath;
        }

        abstract public Task LoadImage();
        abstract public void SaveImage(string pathToSave);
        abstract public bool VerifyImagePath();
    }
}
