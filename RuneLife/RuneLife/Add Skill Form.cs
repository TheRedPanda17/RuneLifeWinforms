using RuneLife.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RuneLife
{
    public partial class AddSkillForm : Form
    {
        private Category category;
        private string _path ="";
        public Category getCategory() => category;
        public AddSkillForm()
        {
            InitializeComponent();

            this.AcceptButton = addSkillButton;
            this.MinimumSize = new System.Drawing.Size(400, 350);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            category = new Category();
            category.Name = nameTextbox.Text;
            category.OtherUnits = additionalUnitsTextbox.Text;
            category.ImageLocation = _path;
            category.ProgressItems = new List<ProgressItem>();
            this.Close();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
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
