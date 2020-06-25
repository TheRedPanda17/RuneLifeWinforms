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
    public partial class LevelUpForm : Form
    {
        private Category _category;
        public LevelUpForm(Category category)
        {
            InitializeComponent();

            _category = category;

            this.Size = new Size(415, 250);
            this.StartPosition = FormStartPosition.CenterParent;

            messageLabel.Text = $"Your {_category.Name} skill is now level {_category.Level}!";

           levelPictureBox.Image = _category.Image;
        }
    }
}
