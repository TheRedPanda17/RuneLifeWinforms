namespace RuneLife
{
    partial class AddProgressForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.titleLabel = new System.Windows.Forms.Label();
            this.addProgressButton = new System.Windows.Forms.Button();
            this.centralPanel = new System.Windows.Forms.Panel();
            this.textboxPanel3 = new System.Windows.Forms.Panel();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateLabel = new System.Windows.Forms.Label();
            this.textboxPanel2 = new System.Windows.Forms.Panel();
            this.otherTextbox = new System.Windows.Forms.TextBox();
            this.otherLabel = new System.Windows.Forms.Label();
            this.textboxPanel1 = new System.Windows.Forms.Panel();
            this.textBoxTime = new System.Windows.Forms.TextBox();
            this.timeLabel = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.centralPanel.SuspendLayout();
            this.textboxPanel3.SuspendLayout();
            this.textboxPanel2.SuspendLayout();
            this.textboxPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(0, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(800, 62);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Add a Progress Item";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // addProgressButton
            // 
            this.addProgressButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.addProgressButton.Location = new System.Drawing.Point(0, 220);
            this.addProgressButton.Name = "addProgressButton";
            this.addProgressButton.Size = new System.Drawing.Size(800, 49);
            this.addProgressButton.TabIndex = 2;
            this.addProgressButton.Text = "Add Progress";
            this.addProgressButton.UseVisualStyleBackColor = true;
            this.addProgressButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // centralPanel
            // 
            this.centralPanel.Controls.Add(this.textboxPanel3);
            this.centralPanel.Controls.Add(this.textboxPanel2);
            this.centralPanel.Controls.Add(this.textboxPanel1);
            this.centralPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.centralPanel.Location = new System.Drawing.Point(0, 62);
            this.centralPanel.Name = "centralPanel";
            this.centralPanel.Size = new System.Drawing.Size(800, 158);
            this.centralPanel.TabIndex = 1;
            // 
            // textboxPanel3
            // 
            this.textboxPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textboxPanel3.Controls.Add(this.dateTimePicker1);
            this.textboxPanel3.Controls.Add(this.dateLabel);
            this.textboxPanel3.Location = new System.Drawing.Point(531, 25);
            this.textboxPanel3.Name = "textboxPanel3";
            this.textboxPanel3.Size = new System.Drawing.Size(233, 70);
            this.textboxPanel3.TabIndex = 2;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(20, 27);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(194, 20);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // dateLabel
            // 
            this.dateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dateLabel.AutoSize = true;
            this.dateLabel.Location = new System.Drawing.Point(25, 9);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(33, 13);
            this.dateLabel.TabIndex = 0;
            this.dateLabel.Text = "Date:";
            // 
            // textboxPanel2
            // 
            this.textboxPanel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textboxPanel2.Controls.Add(this.otherTextbox);
            this.textboxPanel2.Controls.Add(this.otherLabel);
            this.textboxPanel2.Location = new System.Drawing.Point(281, 25);
            this.textboxPanel2.Name = "textboxPanel2";
            this.textboxPanel2.Size = new System.Drawing.Size(233, 70);
            this.textboxPanel2.TabIndex = 1;
            // 
            // otherTextbox
            // 
            this.otherTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.otherTextbox.Location = new System.Drawing.Point(21, 29);
            this.otherTextbox.Name = "otherTextbox";
            this.otherTextbox.Size = new System.Drawing.Size(193, 20);
            this.otherTextbox.TabIndex = 1;
            // 
            // otherLabel
            // 
            this.otherLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.otherLabel.AutoSize = true;
            this.otherLabel.Location = new System.Drawing.Point(27, 8);
            this.otherLabel.Name = "otherLabel";
            this.otherLabel.Size = new System.Drawing.Size(0, 13);
            this.otherLabel.TabIndex = 0;
            // 
            // textboxPanel1
            // 
            this.textboxPanel1.Controls.Add(this.textBoxTime);
            this.textboxPanel1.Controls.Add(this.timeLabel);
            this.textboxPanel1.Location = new System.Drawing.Point(31, 25);
            this.textboxPanel1.Name = "textboxPanel1";
            this.textboxPanel1.Size = new System.Drawing.Size(233, 70);
            this.textboxPanel1.TabIndex = 0;
            // 
            // textBoxTime
            // 
            this.textBoxTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTime.Location = new System.Drawing.Point(20, 29);
            this.textBoxTime.Name = "textBoxTime";
            this.textBoxTime.Size = new System.Drawing.Size(195, 20);
            this.textBoxTime.TabIndex = 1;
            // 
            // timeLabel
            // 
            this.timeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.timeLabel.AutoSize = true;
            this.timeLabel.Location = new System.Drawing.Point(22, 10);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(33, 13);
            this.timeLabel.TabIndex = 0;
            this.timeLabel.Text = "Time:";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // AddProgressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 269);
            this.Controls.Add(this.centralPanel);
            this.Controls.Add(this.addProgressButton);
            this.Controls.Add(this.titleLabel);
            this.Name = "AddProgressForm";
            this.Text = "Add Progress";
            this.centralPanel.ResumeLayout(false);
            this.textboxPanel3.ResumeLayout(false);
            this.textboxPanel3.PerformLayout();
            this.textboxPanel2.ResumeLayout(false);
            this.textboxPanel2.PerformLayout();
            this.textboxPanel1.ResumeLayout(false);
            this.textboxPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button addProgressButton;
        private System.Windows.Forms.Panel centralPanel;
        private System.Windows.Forms.Panel textboxPanel1;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.TextBox textBoxTime;
        private System.Windows.Forms.Panel textboxPanel2;
        private System.Windows.Forms.TextBox otherTextbox;
        private System.Windows.Forms.Label otherLabel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Panel textboxPanel3;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}