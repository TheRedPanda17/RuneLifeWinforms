using RuneLife.models;
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
    public partial class EditSkillForm : Form
    {
        private Category _category;
        private string _path = "";
        public Category GetCategory() => _category;
        public Boolean SaveChanges = false;
        public EditSkillForm(Category category)
        {
            InitializeComponent();

            this.MinimumSize = new System.Drawing.Size(400, 375);

            _category = category.copy();

            nameTextbox.Text = _category.Name;
            additionalUnitsTextbox.Text = _category.OtherUnits;
            if (_category.ImageLocation != null && _category.ImageLocation != "")
            {
                addIconButton.Text = _category.ImageLocation;
                _path = _category.ImageLocation;
            }

            flowLayoutPanel1.SizeChanged += Form1_Resize;
            var newButtonSize = new System.Drawing.Size((int)Math.Floor((flowLayoutPanel1.Size.Width - 26) / 2.0), addSkillButton.Size.Height);
            addSkillButton.Size = newButtonSize;
            cancelButton.Size = newButtonSize;
        }

        private void Form1_Resize(object sender, System.EventArgs e)
        {
            Control control = (Control)sender;
            var newButtonSize = new System.Drawing.Size((int)Math.Floor((control.Size.Width - 26) / 2.0), addSkillButton.Size.Height);

            addSkillButton.Size = newButtonSize;
            cancelButton.Size = newButtonSize;
        }

        private void addSkillButton_Click(object sender, EventArgs e)
        {
            _category.Name = nameTextbox.Text;
            _category.OtherUnits = additionalUnitsTextbox.Text;
            _category.ImageLocation = _path;
            SaveChanges = true;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            SaveChanges = false;
            this.Close();
        }

        private void addIconButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _path = openFileDialog.FileName;
                    addIconButton.Text = openFileDialog.FileName;
                }
            }
        }
    }
}
