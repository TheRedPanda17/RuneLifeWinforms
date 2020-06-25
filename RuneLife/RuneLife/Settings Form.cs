using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RuneLife
{
    public partial class SettingsForm : Form
    {
        private string _path;
        private bool _showRemainingProgress;
        public SettingsForm()
        {
            InitializeComponent();

            _showRemainingProgress = Properties.Settings.Default.ShowRemainingProgress;
            showRemainingProgress.Checked = _showRemainingProgress;
            _path = Properties.Settings.Default.DefaultDirectory;
            defaultDirectory.Text = "Default Directory: " + (_path == null || _path == ""
                ? "N/A"
                : _path);
        }

        private void defaultDirectory_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog openFileDialog = new FolderBrowserDialog())
            {

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _path = openFileDialog.SelectedPath;
                    defaultDirectory.Text = "Default Directory: " + openFileDialog.SelectedPath;
                }
            }
        }

        private void showRemainingProgress_CheckedChanged(object sender, EventArgs e)
        {
            _showRemainingProgress = showRemainingProgress.Checked;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ShowRemainingProgress = _showRemainingProgress;
            Properties.Settings.Default.DefaultDirectory = _path;
            Properties.Settings.Default.Save();
            this.Close();
        }
    }
}
