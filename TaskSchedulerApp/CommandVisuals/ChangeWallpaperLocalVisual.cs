using TaskSchedulerApp.Commands;
using TaskSchedulerApp.Devices.ImageTypes;

namespace TaskSchedulerApp.CommandVisuals
{
    public partial class ChangeWallpaperLocalVisual : UserControl, ICommandVisual
    {
        private LocalImage _localImage = new LocalImage("");
        public ChangeWallpaperLocalVisual()
        {
            InitializeComponent();

            //populate combobox with wallpaper styles using enum values
            comboBox1.DataSource = Enum.GetValues(typeof(Wallpaper.Style));

            comboBox1.SelectedIndex = 0;
        }

        private void VisualForm_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            this.Focus();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _localImage = new LocalImage(openFileDialog.FileName);
            }
        }

        public ITaskCommand GetCommand()
        {
            return new ChangeWallpaperCommand(_localImage, (Wallpaper.Style)comboBox1.SelectedIndex);
        }
    }
}
