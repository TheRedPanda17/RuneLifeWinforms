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
    public partial class AddProgressForm : Form
    {
        private string _otherUnits;
        private ProgressItem _progressItem;
        public ProgressItem GetResult() =>_progressItem;
        
        public AddProgressForm(string otherUnits)
        {
            _otherUnits = otherUnits;

            InitializeComponent();

            otherLabel.Text = otherUnits + ":";

            this.AcceptButton = addProgressButton;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _progressItem = new ProgressItem();
            double otherDouble;
            double timeDouble;
            if (double.TryParse(otherTextbox.Text, out otherDouble) && double.TryParse(textBoxTime.Text, out timeDouble))
            {
                _progressItem.AdditionalInfo = otherDouble;
                _progressItem.Time = timeDouble;
                _progressItem.Date = dateTimePicker1.Value;
            }
            this.Close();
        }
    }
}
