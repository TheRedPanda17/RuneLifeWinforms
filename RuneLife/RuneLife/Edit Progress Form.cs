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
    public partial class EditProgressForm : Form
    {
        private Category _category;
        private BindingSource bindingSource1 = new BindingSource();
        public Category GetCategory() => _category;
        public bool SaveChanges = false;
        public EditProgressForm(Category category)
        {
            _category = category.copy();
            InitializeComponent();

            // Initialize the DataGridView.
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = bindingSource1;

            // Initialize and add a text box column.
            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Time";
            column.Name = "Time";
            dataGridView1.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "AdditionalInfo";
            column.Name = category.OtherUnits;
            dataGridView1.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Date";
            column.Name = "Date";
            dataGridView1.Columns.Add(column);

            foreach (var item in _category.ProgressItems)
                bindingSource1.Add(item);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveChanges = true;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            SaveChanges = false;
            this.Close();
        }
    }
}
