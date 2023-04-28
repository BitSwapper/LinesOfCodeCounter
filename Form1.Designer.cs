namespace LinesOfCodeCounter
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
        private void InitializeComponent()
        {
            this.buttonPickFolder = new System.Windows.Forms.Button();
            this.panelMenuBar = new System.Windows.Forms.Panel();
            this.buttonMinimize = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonQuit = new System.Windows.Forms.Button();
            this.labelSelectedFolder = new System.Windows.Forms.Label();
            this.buttonDoCaluclation = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.richTextBoxAllowedFiles = new System.Windows.Forms.RichTextBox();
            this.richTextBoxExcludedFiles = new System.Windows.Forms.RichTextBox();
            this.labelTotalLines = new System.Windows.Forms.Label();
            this.labelAvgChars = new System.Windows.Forms.Label();
            this.labelAvgLines = new System.Windows.Forms.Label();
            this.labelFilezCounted = new System.Windows.Forms.Label();
            this.labelTotalChars = new System.Windows.Forms.Label();
            this.panelMenuBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonPickFolder
            // 
            this.buttonPickFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPickFolder.ForeColor = System.Drawing.Color.White;
            this.buttonPickFolder.Location = new System.Drawing.Point(2, 112);
            this.buttonPickFolder.Name = "buttonPickFolder";
            this.buttonPickFolder.Size = new System.Drawing.Size(110, 23);
            this.buttonPickFolder.TabIndex = 0;
            this.buttonPickFolder.Text = "Choose Folder";
            this.buttonPickFolder.UseVisualStyleBackColor = true;
            this.buttonPickFolder.Click += new System.EventHandler(this.buttonSelectFolder_Click);
            // 
            // panelMenuBar
            // 
            this.panelMenuBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.panelMenuBar.Controls.Add(this.buttonMinimize);
            this.panelMenuBar.Controls.Add(this.label1);
            this.panelMenuBar.Controls.Add(this.buttonQuit);
            this.panelMenuBar.Location = new System.Drawing.Point(0, 0);
            this.panelMenuBar.Name = "panelMenuBar";
            this.panelMenuBar.Size = new System.Drawing.Size(1024, 24);
            this.panelMenuBar.TabIndex = 3;
            this.panelMenuBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelMenuBar_MouseDown);
            // 
            // buttonMinimize
            // 
            this.buttonMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMinimize.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonMinimize.ForeColor = System.Drawing.Color.White;
            this.buttonMinimize.Location = new System.Drawing.Point(978, 1);
            this.buttonMinimize.Name = "buttonMinimize";
            this.buttonMinimize.Size = new System.Drawing.Size(22, 22);
            this.buttonMinimize.TabIndex = 4;
            this.buttonMinimize.Text = "-";
            this.buttonMinimize.UseVisualStyleBackColor = true;
            this.buttonMinimize.Click += new System.EventHandler(this.buttonMinimize_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(146)))), ((int)(((byte)(40)))));
            this.label1.Location = new System.Drawing.Point(2, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Code Stats | Written by Hex";
            // 
            // buttonQuit
            // 
            this.buttonQuit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonQuit.ForeColor = System.Drawing.Color.White;
            this.buttonQuit.Location = new System.Drawing.Point(1002, 1);
            this.buttonQuit.Name = "buttonQuit";
            this.buttonQuit.Size = new System.Drawing.Size(22, 22);
            this.buttonQuit.TabIndex = 2;
            this.buttonQuit.Text = "X";
            this.buttonQuit.UseVisualStyleBackColor = true;
            this.buttonQuit.Click += new System.EventHandler(this.buttonQuit_Click);
            // 
            // labelSelectedFolder
            // 
            this.labelSelectedFolder.AutoSize = true;
            this.labelSelectedFolder.ForeColor = System.Drawing.Color.White;
            this.labelSelectedFolder.Location = new System.Drawing.Point(2, 27);
            this.labelSelectedFolder.Name = "labelSelectedFolder";
            this.labelSelectedFolder.Size = new System.Drawing.Size(124, 15);
            this.labelSelectedFolder.TabIndex = 4;
            this.labelSelectedFolder.Text = "Analyzing Folder:  null";
            // 
            // buttonDoCaluclation
            // 
            this.buttonDoCaluclation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDoCaluclation.ForeColor = System.Drawing.Color.White;
            this.buttonDoCaluclation.Location = new System.Drawing.Point(330, 113);
            this.buttonDoCaluclation.Name = "buttonDoCaluclation";
            this.buttonDoCaluclation.Size = new System.Drawing.Size(110, 23);
            this.buttonDoCaluclation.TabIndex = 5;
            this.buttonDoCaluclation.Text = "Fetch Data";
            this.buttonDoCaluclation.UseVisualStyleBackColor = true;
            this.buttonDoCaluclation.Click += new System.EventHandler(this.buttonDoCaluclation_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(118, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Allowed File Types";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(224, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Excluded Folders";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 141);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(1024, 627);
            this.dataGridView1.TabIndex = 10;
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            this.dataGridView1.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            this.dataGridView1.Paint += new System.Windows.Forms.PaintEventHandler(this.dataGridView1_Paint);
            // 
            // richTextBoxAllowedFiles
            // 
            this.richTextBoxAllowedFiles.Location = new System.Drawing.Point(118, 71);
            this.richTextBoxAllowedFiles.Name = "richTextBoxAllowedFiles";
            this.richTextBoxAllowedFiles.Size = new System.Drawing.Size(100, 64);
            this.richTextBoxAllowedFiles.TabIndex = 11;
            this.richTextBoxAllowedFiles.Text = "";
            // 
            // richTextBoxExcludedFiles
            // 
            this.richTextBoxExcludedFiles.Location = new System.Drawing.Point(224, 72);
            this.richTextBoxExcludedFiles.Name = "richTextBoxExcludedFiles";
            this.richTextBoxExcludedFiles.Size = new System.Drawing.Size(100, 64);
            this.richTextBoxExcludedFiles.TabIndex = 13;
            this.richTextBoxExcludedFiles.Text = "";
            // 
            // labelTotalLines
            // 
            this.labelTotalLines.AutoSize = true;
            this.labelTotalLines.ForeColor = System.Drawing.Color.White;
            this.labelTotalLines.Location = new System.Drawing.Point(567, 76);
            this.labelTotalLines.Name = "labelTotalLines";
            this.labelTotalLines.Size = new System.Drawing.Size(115, 15);
            this.labelTotalLines.TabIndex = 14;
            this.labelTotalLines.Text = "Total Lines Of Code: ";
            // 
            // labelAvgChars
            // 
            this.labelAvgChars.AutoSize = true;
            this.labelAvgChars.ForeColor = System.Drawing.Color.White;
            this.labelAvgChars.Location = new System.Drawing.Point(567, 121);
            this.labelAvgChars.Name = "labelAvgChars";
            this.labelAvgChars.Size = new System.Drawing.Size(90, 15);
            this.labelAvgChars.TabIndex = 15;
            this.labelAvgChars.Text = "Avg Chars / File";
            // 
            // labelAvgLines
            // 
            this.labelAvgLines.AutoSize = true;
            this.labelAvgLines.ForeColor = System.Drawing.Color.White;
            this.labelAvgLines.Location = new System.Drawing.Point(567, 106);
            this.labelAvgLines.Name = "labelAvgLines";
            this.labelAvgLines.Size = new System.Drawing.Size(93, 15);
            this.labelAvgLines.TabIndex = 16;
            this.labelAvgLines.Text = "Avg Lines / File: ";
            // 
            // labelFilezCounted
            // 
            this.labelFilezCounted.AutoSize = true;
            this.labelFilezCounted.ForeColor = System.Drawing.Color.White;
            this.labelFilezCounted.Location = new System.Drawing.Point(567, 61);
            this.labelFilezCounted.Name = "labelFilezCounted";
            this.labelFilezCounted.Size = new System.Drawing.Size(87, 15);
            this.labelFilezCounted.TabIndex = 17;
            this.labelFilezCounted.Text = "Files Analyzed: ";
            // 
            // labelTotalChars
            // 
            this.labelTotalChars.AutoSize = true;
            this.labelTotalChars.ForeColor = System.Drawing.Color.White;
            this.labelTotalChars.Location = new System.Drawing.Point(567, 91);
            this.labelTotalChars.Name = "labelTotalChars";
            this.labelTotalChars.Size = new System.Drawing.Size(76, 15);
            this.labelTotalChars.TabIndex = 18;
            this.labelTotalChars.Text = "Total Letters: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.labelTotalChars);
            this.Controls.Add(this.labelFilezCounted);
            this.Controls.Add(this.labelAvgLines);
            this.Controls.Add(this.labelAvgChars);
            this.Controls.Add(this.labelTotalLines);
            this.Controls.Add(this.richTextBoxExcludedFiles);
            this.Controls.Add(this.richTextBoxAllowedFiles);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonDoCaluclation);
            this.Controls.Add(this.labelSelectedFolder);
            this.Controls.Add(this.panelMenuBar);
            this.Controls.Add(this.buttonPickFolder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelMenuBar.ResumeLayout(false);
            this.panelMenuBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button buttonPickFolder;
        private Panel panelMenuBar;
        private Button buttonQuit;
        private Label label1;
        private Button buttonMinimize;
        private Label labelSelectedFolder;
        private Button buttonDoCaluclation;
        private Label label2;
        private Label label3;
        private DataGridView dataGridView1;
        private RichTextBox richTextBoxAllowedFiles;
        private RichTextBox richTextBoxExcludedFiles;
        private Label labelTotalLines;
        private Label labelAvgChars;
        private Label labelAvgLines;
        private Label labelFilezCounted;
        private Label labelTotalChars;
    }
}