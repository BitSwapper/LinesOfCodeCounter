namespace LinesOfCodeCounter
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if(disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        void InitializeComponent()
        {
            buttonPickFolder = new Button();
            panelMenuBar = new Panel();
            buttonMinimize = new Button();
            label1 = new Label();
            buttonQuit = new Button();
            labelSelectedFolder = new Label();
            buttonDoCaluclation = new Button();
            label2 = new Label();
            label3 = new Label();
            dataGridView1 = new DataGridView();
            richTextBoxAllowedFiles = new RichTextBox();
            richTextBoxExcludedFiles = new RichTextBox();
            labelTotalLines = new Label();
            labelAvgChars = new Label();
            labelAvgLines = new Label();
            labelFilezCounted = new Label();
            labelTotalChars = new Label();
            labelTimeTaken = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            panelMenuBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // buttonPickFolder
            // 
            buttonPickFolder.FlatStyle = FlatStyle.Flat;
            buttonPickFolder.ForeColor = Color.White;
            buttonPickFolder.Location = new Point(2, 112);
            buttonPickFolder.Name = "buttonPickFolder";
            buttonPickFolder.Size = new Size(110, 23);
            buttonPickFolder.TabIndex = 0;
            buttonPickFolder.Text = "Choose Folder";
            buttonPickFolder.UseVisualStyleBackColor = true;
            buttonPickFolder.Click += buttonSelectFolder_Click;
            // 
            // panelMenuBar
            // 
            panelMenuBar.BackColor = Color.FromArgb(24, 24, 24);
            panelMenuBar.Controls.Add(buttonMinimize);
            panelMenuBar.Controls.Add(label1);
            panelMenuBar.Controls.Add(buttonQuit);
            panelMenuBar.Location = new Point(0, 0);
            panelMenuBar.Name = "panelMenuBar";
            panelMenuBar.Size = new Size(1120, 24);
            panelMenuBar.TabIndex = 3;
            panelMenuBar.MouseDown += panelMenuBar_MouseDown;
            // 
            // buttonMinimize
            // 
            buttonMinimize.FlatStyle = FlatStyle.Flat;
            buttonMinimize.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            buttonMinimize.ForeColor = Color.White;
            buttonMinimize.Location = new Point(1071, 0);
            buttonMinimize.Name = "buttonMinimize";
            buttonMinimize.Size = new Size(22, 22);
            buttonMinimize.TabIndex = 4;
            buttonMinimize.Text = "-";
            buttonMinimize.UseVisualStyleBackColor = true;
            buttonMinimize.Click += buttonMinimize_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(251, 146, 40);
            label1.Location = new Point(2, 2);
            label1.Name = "label1";
            label1.Size = new Size(246, 19);
            label1.TabIndex = 3;
            label1.Text = "Code Stats | Github.com/BitSwapper";
            // 
            // buttonQuit
            // 
            buttonQuit.FlatStyle = FlatStyle.Flat;
            buttonQuit.ForeColor = Color.White;
            buttonQuit.Location = new Point(1095, 0);
            buttonQuit.Name = "buttonQuit";
            buttonQuit.Size = new Size(22, 22);
            buttonQuit.TabIndex = 2;
            buttonQuit.Text = "X";
            buttonQuit.UseVisualStyleBackColor = true;
            buttonQuit.Click += buttonQuit_Click;
            // 
            // labelSelectedFolder
            // 
            labelSelectedFolder.AutoSize = true;
            labelSelectedFolder.ForeColor = Color.White;
            labelSelectedFolder.Location = new Point(2, 27);
            labelSelectedFolder.Name = "labelSelectedFolder";
            labelSelectedFolder.Size = new Size(124, 15);
            labelSelectedFolder.TabIndex = 4;
            labelSelectedFolder.Text = "Analyzing Folder:  null";
            // 
            // buttonDoCaluclation
            // 
            buttonDoCaluclation.FlatStyle = FlatStyle.Flat;
            buttonDoCaluclation.ForeColor = Color.White;
            buttonDoCaluclation.Location = new Point(451, 113);
            buttonDoCaluclation.Name = "buttonDoCaluclation";
            buttonDoCaluclation.Size = new Size(110, 23);
            buttonDoCaluclation.TabIndex = 5;
            buttonDoCaluclation.Text = "Fetch Data";
            buttonDoCaluclation.UseVisualStyleBackColor = true;
            buttonDoCaluclation.Click += buttonDoCaluclation_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.White;
            label2.Location = new Point(118, 53);
            label2.Name = "label2";
            label2.Size = new Size(103, 15);
            label2.TabIndex = 7;
            label2.Text = "Allowed File Types";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.White;
            label3.Location = new Point(245, 53);
            label3.Name = "label3";
            label3.Size = new Size(96, 15);
            label3.TabIndex = 9;
            label3.Text = "Excluded Folders";
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.BackgroundColor = Color.FromArgb(32, 32, 32);
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Bottom;
            dataGridView1.Location = new Point(0, 141);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(1120, 627);
            dataGridView1.TabIndex = 10;
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
            dataGridView1.CellPainting += dataGridView1_CellPainting;
            dataGridView1.RowPostPaint += dataGridView1_RowPostPaint;
            dataGridView1.Paint += dataGridView1_Paint;
            // 
            // richTextBoxAllowedFiles
            // 
            richTextBoxAllowedFiles.Location = new Point(121, 71);
            richTextBoxAllowedFiles.Name = "richTextBoxAllowedFiles";
            richTextBoxAllowedFiles.Size = new Size(118, 64);
            richTextBoxAllowedFiles.TabIndex = 11;
            richTextBoxAllowedFiles.Text = "";
            // 
            // richTextBoxExcludedFiles
            // 
            richTextBoxExcludedFiles.Location = new Point(245, 71);
            richTextBoxExcludedFiles.Name = "richTextBoxExcludedFiles";
            richTextBoxExcludedFiles.Size = new Size(200, 64);
            richTextBoxExcludedFiles.TabIndex = 13;
            richTextBoxExcludedFiles.Text = "";
            // 
            // labelTotalLines
            // 
            labelTotalLines.AutoSize = true;
            labelTotalLines.ForeColor = Color.Gold;
            labelTotalLines.Location = new Point(687, 76);
            labelTotalLines.Name = "labelTotalLines";
            labelTotalLines.Size = new Size(34, 15);
            labelTotalLines.TabIndex = 14;
            labelTotalLines.Text = "Texty";
            // 
            // labelAvgChars
            // 
            labelAvgChars.AutoSize = true;
            labelAvgChars.ForeColor = Color.Gold;
            labelAvgChars.Location = new Point(687, 121);
            labelAvgChars.Name = "labelAvgChars";
            labelAvgChars.Size = new Size(34, 15);
            labelAvgChars.TabIndex = 15;
            labelAvgChars.Text = "Texty";
            // 
            // labelAvgLines
            // 
            labelAvgLines.AutoSize = true;
            labelAvgLines.ForeColor = Color.Gold;
            labelAvgLines.Location = new Point(687, 106);
            labelAvgLines.Name = "labelAvgLines";
            labelAvgLines.Size = new Size(34, 15);
            labelAvgLines.TabIndex = 16;
            labelAvgLines.Text = "Texty";
            // 
            // labelFilezCounted
            // 
            labelFilezCounted.AutoSize = true;
            labelFilezCounted.ForeColor = Color.Gold;
            labelFilezCounted.Location = new Point(687, 61);
            labelFilezCounted.Name = "labelFilezCounted";
            labelFilezCounted.Size = new Size(34, 15);
            labelFilezCounted.TabIndex = 17;
            labelFilezCounted.Text = "Texty";
            // 
            // labelTotalChars
            // 
            labelTotalChars.AutoSize = true;
            labelTotalChars.ForeColor = Color.Gold;
            labelTotalChars.Location = new Point(687, 91);
            labelTotalChars.Name = "labelTotalChars";
            labelTotalChars.Size = new Size(34, 15);
            labelTotalChars.TabIndex = 18;
            labelTotalChars.Text = "Texty";
            // 
            // labelTimeTaken
            // 
            labelTimeTaken.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelTimeTaken.AutoSize = true;
            labelTimeTaken.ForeColor = Color.White;
            labelTimeTaken.Location = new Point(687, 27);
            labelTimeTaken.Name = "labelTimeTaken";
            labelTimeTaken.RightToLeft = RightToLeft.No;
            labelTimeTaken.Size = new Size(0, 15);
            labelTimeTaken.TabIndex = 19;
            labelTimeTaken.TextAlign = ContentAlignment.TopRight;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.White;
            label4.Location = new Point(567, 91);
            label4.Name = "label4";
            label4.Size = new Size(97, 15);
            label4.TabIndex = 23;
            label4.Text = "Total Characters :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.White;
            label5.Location = new Point(567, 106);
            label5.Name = "label5";
            label5.Size = new Size(93, 15);
            label5.TabIndex = 22;
            label5.Text = "Avg Lines / File: ";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = Color.White;
            label6.Location = new Point(567, 121);
            label6.Name = "label6";
            label6.Size = new Size(119, 15);
            label6.TabIndex = 21;
            label6.Text = "Avg Characters / File:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ForeColor = Color.White;
            label7.Location = new Point(567, 76);
            label7.Name = "label7";
            label7.Size = new Size(115, 15);
            label7.TabIndex = 20;
            label7.Text = "Total Lines Of Code: ";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.ForeColor = Color.White;
            label8.Location = new Point(567, 61);
            label8.Name = "label8";
            label8.Size = new Size(87, 15);
            label8.TabIndex = 24;
            label8.Text = "Files Analyzed: ";
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(36, 36, 36);
            ClientSize = new Size(1120, 768);
            Controls.Add(label8);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(label7);
            Controls.Add(labelTimeTaken);
            Controls.Add(labelTotalChars);
            Controls.Add(labelFilezCounted);
            Controls.Add(labelAvgLines);
            Controls.Add(labelAvgChars);
            Controls.Add(labelTotalLines);
            Controls.Add(richTextBoxExcludedFiles);
            Controls.Add(richTextBoxAllowedFiles);
            Controls.Add(dataGridView1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(buttonDoCaluclation);
            Controls.Add(labelSelectedFolder);
            Controls.Add(panelMenuBar);
            Controls.Add(buttonPickFolder);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormMain";
            SizeGripStyle = SizeGripStyle.Show;
            Text = "Form1";
            Load += Form1_Load;
            panelMenuBar.ResumeLayout(false);
            panelMenuBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        Button buttonPickFolder;
        Panel panelMenuBar;
        Button buttonQuit;
        Label label1;
        Button buttonMinimize;
        Label labelSelectedFolder;
        Button buttonDoCaluclation;
        Label label2;
        Label label3;
        DataGridView dataGridView1;
        RichTextBox richTextBoxAllowedFiles;
        RichTextBox richTextBoxExcludedFiles;
        Label labelTotalLines;
        Label labelAvgChars;
        Label labelAvgLines;
        Label labelFilezCounted;
        Label labelTotalChars;
        private Label labelTimeTaken;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
    }
}