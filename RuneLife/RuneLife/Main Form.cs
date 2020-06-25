using RuneLife.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using System.Runtime.InteropServices;

namespace RuneLife
{
    public partial class RuneLifeMain : Form
    {
        private List<Category> categories = new List<Category>();
        private BindingSource bindingSource1 = new BindingSource();
        private string openFilePath = "";
        private const int REMAINING_PROGRESS_INDEX = 3;
        public RuneLifeMain(string path)
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
            this.MinimumSize = new System.Drawing.Size(700, 350);

            flowLayoutPanel1.SizeChanged += Form1_Resize;

            createColumns();

            openFilePath = path;

            var text = File.ReadAllText(path);

            fillJsonObjects(text);
        }

        public RuneLifeMain()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
            this.MinimumSize = new System.Drawing.Size(700, 350);

            flowLayoutPanel1.SizeChanged += Form1_Resize;

            createColumns();
        }
        private void Form1_Resize(object sender, System.EventArgs e)
        {
            Control control = (Control)sender;
            var  newButtonSize = new System.Drawing.Size((int) Math.Floor((control.Size.Width - 52) / 4.0), editProgressButton.Size.Height);

            addSkillButton.Size = newButtonSize;
            addProgressButton.Size = newButtonSize;
            editSkillButton.Size = newButtonSize;
            editProgressButton.Size = newButtonSize;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory =
                    Properties.Settings.Default.DefaultDirectory == null || Properties.Settings.Default.DefaultDirectory == ""
                        ? Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                        : Properties.Settings.Default.DefaultDirectory;
                openFileDialog.Filter = "RuneLife File|*.rnlf";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    var filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        var fileContent = reader.ReadToEnd();
                        fillJsonObjects(fileContent);
                        openFilePath = openFileDialog.FileName;
                    }
                }
            }
        }
        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string jsonText = JsonConvert.SerializeObject(categories);

            if(openFilePath != null && openFilePath != "")
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(openFilePath))
                {
                    file.Write(jsonText);
                }
                MessageBox.Show("Successfully Saved", "Success");
            }
            else
                MessageBox.Show("You do not have a file set to which the rnlf file can be saved", "No File", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string jsonText = JsonConvert.SerializeObject(categories);

            SaveFileDialog saveDialog = new SaveFileDialog();

            saveDialog.Filter = "RuneLife File|*.rnlf";
            saveDialog.FilterIndex = 2;
            saveDialog.RestoreDirectory = true;
            saveDialog.InitialDirectory =
                Properties.Settings.Default.DefaultDirectory == null || Properties.Settings.Default.DefaultDirectory == ""
                    ? Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    : Properties.Settings.Default.DefaultDirectory;

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(saveDialog.OpenFile()))
                {
                    file.Write(jsonText);
                }
                openFilePath = saveDialog.FileName;
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            using(AddSkillForm addSkillForm = new AddSkillForm())
            {
                addSkillForm.ShowDialog();
                Category category = addSkillForm.getCategory();
                if (category != null)
                {
                    categories.Add(category);
                    bindingSource1.Add(category);
                }
            }
        }

        private void addProgressButton_Click(object sender, EventArgs e)
        {
            var source = (Category)bindingSource1.Current;
            bool levelUp = false;
            int oldLevel = source.Level;

            if (source == null)
                MessageBox.Show("You will need to select a skill to which you can add progress", "Nothing to Edit", MessageBoxButtons.OK, MessageBoxIcon.Error);
           
            else 
                using(AddProgressForm addProgressForm = new AddProgressForm(source.OtherUnits))
                {
                    addProgressForm.MinimumSize = new System.Drawing.Size(750, 250);
                    addProgressForm.ShowDialog();
                    ProgressItem progress = addProgressForm.GetResult();
                    if (progress != null)
                    {
                        source.ProgressItems.Add(progress);

                        if (source.Level > oldLevel)
                            levelUp = true;

                        var position = bindingSource1.Position;
                        bindingSource1.List.RemoveAt(position);
                        categories.RemoveAt(position);
                        bindingSource1.List.Insert(position, source);
                       categories.Insert(position, source);
                    }
                }


            if (levelUp)
                using (LevelUpForm levelUpForm = new LevelUpForm(source))
                {
                    levelUpForm.ShowDialog();
                }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var source = (Category)bindingSource1.Current;
            bool levelUp = false;
            
            if (source == null)
                MessageBox.Show("You will need to select a skill to which you can add progress", "Nothing to Edit", MessageBoxButtons.OK, MessageBoxIcon.Error);

            else
                using (EditProgressForm editProgressForm = new EditProgressForm(source))
                {
                    editProgressForm.MinimumSize = new System.Drawing.Size(750, 250);
                    editProgressForm.ShowDialog();
                    if (editProgressForm.SaveChanges)
                    {
                        if (source.Level < editProgressForm.GetCategory().Level)
                            levelUp = true;

                        source = editProgressForm.GetCategory();
                        var position = bindingSource1.Position;
                        bindingSource1.List.RemoveAt(position);
                        categories.RemoveAt(position);
                        bindingSource1.List.Insert(position, source);
                        categories.Insert(position, source);
                    }
                }

            if (levelUp)
                using (LevelUpForm levelUpForm = new LevelUpForm(source))
                {
                    levelUpForm.ShowDialog();
                }
        }

        private void editSkillButton_Click(object sender, EventArgs e)
        {
            var source = (Category)bindingSource1.Current;

            if (source == null)
                MessageBox.Show("You will need to select a skill to which you can add progress", "Nothing to Edit", MessageBoxButtons.OK, MessageBoxIcon.Error);

            else
                using (EditSkillForm editSkillForm = new EditSkillForm(source))
                {
                    editSkillForm.ShowDialog();
                    if (editSkillForm.SaveChanges)
                    {
                        source = editSkillForm.GetCategory();
                        var position = bindingSource1.Position;
                        bindingSource1.List.RemoveAt(position);
                        categories.RemoveAt(position);
                        bindingSource1.List.Insert(position, source);
                        categories.Insert(position, source);
                    }
                }
        }

        private void fillJsonObjects(string jsonString)
        {
            categories = JsonConvert.DeserializeObject<List<Category>>(jsonString);
            bindingSource1 = new BindingSource();

            int i = 0;
            foreach (var category in categories)
            {
                category.ProgressItems = category.ProgressItems.OrderBy(x => x.Date).ToList();
                bindingSource1.Add(category);
                i++;
            }
            dataGridView1.DataSource = bindingSource1;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFilePath = "";
            categories = new List<Category>();
            bindingSource1 = new BindingSource();
            dataGridView1.DataSource = bindingSource1;
        }

        private void createColumns()
        {
            // Initialize the DataGridView.
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = bindingSource1;

            // Initialize and add a text box column.
            var imageColumn = new DataGridViewImageColumn();
            imageColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            imageColumn.Width = 50;
            imageColumn.DataPropertyName = "Image";
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
            dataGridView1.Columns.Add(imageColumn);

            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Name";
            column.Name = "Skill";
            dataGridView1.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "LevelString";
            column.Name = "Level";
            dataGridView1.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "TimeToNextLevel";
            column.Name = "Time To Next Level";
            column.Visible = Properties.Settings.Default.ShowRemainingProgress;
            dataGridView1.Columns.Add(column);

            // Initialize and add a text box column.
            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "TotalTime";
            column.Name = "Time Invested";
            dataGridView1.Columns.Add(column);

            // Initialize and add a text box column.
            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "TotalOtherString";
            column.Name = "Additional Quantity";
            dataGridView1.Columns.Add(column);

            // Initialize and add a text box column.
            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "LastUpdated";
            column.Name = "Last Progress";
            dataGridView1.Columns.Add(column);
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using(SettingsForm settingsForm = new SettingsForm())
            {
                settingsForm.ShowDialog();
                dataGridView1.Columns[REMAINING_PROGRESS_INDEX].Visible = Properties.Settings.Default.ShowRemainingProgress;
            }
        }
    }
}
