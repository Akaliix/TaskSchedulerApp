using System.IO;
using System.Net.Http;

namespace TaskSchedulerApp.Devices.ImageTypes
{
    public class WebImage : BaseImage
    {
        public WebImage(string imagePath) : base(imagePath)
        { }

        public override void SaveImage(string pathToSave)
        {
            Image.Save(pathToSave, System.Drawing.Imaging.ImageFormat.Bmp);
        }

        public override bool VerifyImagePath()
        {
            return ImagePath.StartsWith("http");
        }

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
