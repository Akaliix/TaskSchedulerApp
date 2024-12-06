using System.IO;

namespace TaskSchedulerApp.Devices.ImageTypes
{
    public class LocalImage : BaseImage
    {
        public LocalImage(string imagePath) : base(imagePath)
        { }

        public override async void SaveImage(string pathToSave)
        {
            Image.Save(pathToSave, System.Drawing.Imaging.ImageFormat.Bmp);
        }

        public override bool VerifyImagePath()
        {
            return File.Exists(ImagePath);
        }

        public override async Task LoadImage()
        {
            Image = System.Drawing.Image.FromFile(ImagePath);
        }
    }
}
