using TaskSchedulerApp.Commands;
using TaskSchedulerApp.Devices.ImageTypes;

namespace TaskSchedulerApp.CommandVisuals
{
    public partial class ChangeWallpaperWebVisual : UserControl, ICommandVisual
    {
        public ChangeWallpaperWebVisual()
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

        public ITaskCommand GetCommand()
        {
            return new ChangeWallpaperCommand(new WebImage(guna2TextBox1.Text), (Wallpaper.Style)comboBox1.SelectedIndex);
        }
    }
}
