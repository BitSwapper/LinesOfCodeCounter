using System.Reflection;
using System.Runtime.InteropServices;

namespace LinesOfCodeCounter;

public partial class Form1 : Form
{
    [DllImport("user32.dll")]
    static extern bool ReleaseCapture();

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, nuint wParam, nint lParam);

    const int WM_NCLBUTTONDOWN = 0xA1;
    const int HT_CAPTION = 0x2;

    Color lineColorA { get; } = Color.FromArgb(255, 48, 48, 48);
    Color lineColorB { get; } = Color.FromArgb(255, 64, 64, 64);
    Color bgColor { get; } = Color.FromArgb(255, 40, 40, 40);
    Color textColor { get; } = Color.WhiteSmoke;

    DataGridColorHelper dataGridColorHelper;
    public string FolderToExamine { get; private set; }
    List<string> acceptedFileTypes = new() {".cs", ".py"};
    List<string> excludedFileTypes = new() {@"\bin", @"\obj", @"\Properties", @"\Debug", @"\Release"};
    List<CodeFile> codeFiles = new();

    long totalFiles = 0;
    long totalLines = 0;
    long totalCharacters = 0;
    float avgCharsPerFile = 0;
    float avgLinesPerFile = 0;
    float avgCharsPerLine = 0;



    public Form1() => InitializeComponent();

    void Form1_Load(object sender, EventArgs e)
    {
        dataGridColorHelper = new(lineColorA, lineColorB, bgColor, dataGridView1, this.Font);

        FillTextBoxDefaults();

        EnableDoubleBufferedDataGrid();
        dataGridView1.ForeColor = textColor;
    }


    void FillTextBoxDefaults()
    {
        UserInputConverter.FillTextFromList(acceptedFileTypes, richTextBoxAllowedFiles);
        UserInputConverter.FillTextFromList(excludedFileTypes, richTextBoxExcludedFiles);
    }


    void EnableDoubleBufferedDataGrid() => typeof(DataGridView).InvokeMember(
            "DoubleBuffered",
            BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
            null,
            dataGridView1,
            new object[] { true });


    void buttonSelectFolder_Click(object sender, EventArgs e)
    {
        using(var fbd = new FolderBrowserDialog())
        {
            DialogResult result = fbd.ShowDialog();

            if(result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                FolderToExamine = fbd.SelectedPath;
        }

        labelSelectedFolder.Text = "Examining Folder: " + FolderToExamine;
    }


    void buttonDoCaluclation_Click(object sender, EventArgs e)
    {
        if(string.IsNullOrEmpty(FolderToExamine))
            return;

        UserInputConverter.ConvertUserInputsToRealSettings(ref acceptedFileTypes, ref excludedFileTypes, richTextBoxAllowedFiles, richTextBoxExcludedFiles);
        DataGridViewFiller.GenerateAndFillDataGridView(ref codeFiles, dataGridView1, FolderToExamine, acceptedFileTypes, excludedFileTypes);

        totalFiles = codeFiles.Count;
        totalLines = codeFiles.Sum(x => x.totalLinesOfCode);
        totalCharacters = codeFiles.Sum(x => x.totalCharacterCount);

        avgLinesPerFile = totalLines / totalFiles;
        avgCharsPerFile = totalCharacters / totalFiles;
        avgCharsPerLine = totalCharacters / totalLines;

        labelFilezCounted.Text = "Files Analyzed: " + totalFiles;
        labelTotalLines.Text = "Total Lines Of Code: " + totalLines;
        labelTotalChars.Text = "Total Chars: " + totalCharacters;
        labelAvgLines.Text = "Avg Lines / File: " + avgLinesPerFile;
        labelAvgChars.Text = "Avg Chars / File: " + avgCharsPerFile;
    }


    void panelMenuBar_MouseDown(object sender, MouseEventArgs e)
    {
        if(e.Button == MouseButtons.Left)
        {
            ReleaseCapture();
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }
    }


    void buttonQuit_Click(object sender, EventArgs e) => Environment.Exit(0);


    void buttonMinimize_Click(object sender, EventArgs e) => this.WindowState = FormWindowState.Minimized;


    void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) => dataGridColorHelper.DoRowBackColor(e);


    void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e) => dataGridColorHelper.DoRowHeaderColor(sender, e);


    void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e) => dataGridColorHelper.DoSelectAllColor(e);


    void dataGridView1_Paint(object sender, PaintEventArgs e) => dataGridColorHelper.DoColumnHeaderColor(e);
}


//using System.Runtime.InteropServices;

//namespace LinesOfCodeCounter
//{
//    public partial class Form1 : Form
//    {
//        [DllImport("user32.dll")]
//        static extern bool ReleaseCapture();

//        [DllImport("user32.dll", CharSet = CharSet.Auto)]
//        public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, nuint wParam, nint lParam);

//        //string ourScriptsFolderLoc = @"F:\Coding Projects\GitHub Repos\MazeDrop4\Assets\_Scripts";
//        //string ourScriptsFolderLoc = @"F:\Coding Projects\GitHub Repos\MazeDrop3\Assets\Scripts";
//        //string ourScriptsFolderLoc = @"F:\Coding Projects\GitHub Repos\BlackOpsHexed";
//        string ourScriptsFolderLoc = @"F:\Coding Projects";
//        //string ourScriptsFolderLoc = @"F:\Coding Projects\GitHub Repos\MazeEditor\Assets\Scripts";


//        //string ourScriptsFolderLoc = @"F:\Coding Projects\C#";
//        //string ourScriptsFolderLoc = @"F:\Coding Projects\C#\DataMosh2 - Copy - Copy";

//        string longestLineOfCodeTxtInfo;
//        long totalLinesOfCode = 0;
//        long longestLineOfCode = 0;
//        long characterCount = 0;
//        long totalFiles = 0;
//        float avgCharsPerFile = 0;
//        float avgLinesPerFile = 0;

//        bool bLastColorWasA = false;
//        Color lineColorA = Color.FromArgb(128, 48, 48, 48);
//        Color lineColorB = Color.FromArgb(128, 64, 64, 64);
//        Color nextColor => bLastColorWasA ? lineColorB : lineColorA;


//        const int WM_NCLBUTTONDOWN = 0xA1;
//        const int HT_CAPTION = 0x2;


//        public Form1() => InitializeComponent();

//        private void buttonGo_Click(object sender, EventArgs e) => Go();

//        void Go()
//        {
//            ResetData();
//            string[] directories = System.IO.Directory.GetDirectories(ourScriptsFolderLoc,"*", System.IO.SearchOption.AllDirectories);

//            //richTextBox1.Text += "Lines | Chars | FileName" + Environment.NewLine;
//            AppendText("Lines | Chars | FileName" + Environment.NewLine, true);

//            GetAllFileInformation(directories);

//            avgCharsPerFile = (float)characterCount / (float)totalFiles;
//            avgLinesPerFile = (float)totalLinesOfCode / (float)totalFiles;

//            AppendText(Environment.NewLine + Environment.NewLine, false);
//            AppendText(totalFiles.ToString() + " Files Analyzed." + Environment.NewLine, false);
//            AppendText("Total Lines of Code: " + totalLinesOfCode.ToString() + Environment.NewLine, false);
//            AppendText("Total Characters Typed: " + characterCount.ToString() + Environment.NewLine, false);
//            AppendText("Average # Of Chars / Script: " + avgCharsPerFile.ToString(".0") + Environment.NewLine, false);
//            AppendText("Average # Of Lines / Script: " + avgLinesPerFile.ToString(".0") + Environment.NewLine, false);
//            AppendText(longestLineOfCodeTxtInfo, false);
//            AppendText(Environment.NewLine, false);

//            richTextBox1.ScrollToCaret();
//        }

//        void GetAllFileInformation(string[] directories)
//        {
//            GetFileInfo(new DirectoryInfo(ourScriptsFolderLoc).GetFiles()); // i think this line fixes not counting the og folder. needs testing
//            foreach(var d in directories)
//            {
//                if(d.Contains(@"\bin") || d.Contains(@"\obj") || d.Contains(@"\C# Book Samples") || d.Contains(@"\Properties"))
//                    continue;

//                DirectoryInfo directoryLocation = new DirectoryInfo(d);
//                FileInfo[] Files = directoryLocation.GetFiles();

//                GetFileInfo(Files);
//            }
//        }

//        void ResetData()
//        {
//            richTextBox1.Text = "";
//            longestLineOfCodeTxtInfo = "";
//            totalLinesOfCode = 0;
//            longestLineOfCode = 0;
//            characterCount = 0;
//            totalFiles = 0;
//            avgCharsPerFile = 0;
//            avgLinesPerFile = 0;
//        }

//        void GetFileInfo(FileInfo[] Files)
//        {
//            //foreach(FileInfo i in Files)
//            //    if(i.Name.Length > longestFileName)
//            //        longestFileName = i.Name.Length;

//            foreach(FileInfo i in Files)
//            {
//                if(i.Extension != ".cs")
//                    continue;

//                int lineCounterCurrent = 0;
//                foreach(var line in File.ReadAllLines(i.FullName))
//                {
//                    if(line.Length > longestLineOfCode)
//                    {
//                        longestLineOfCode = line.Length;
//                        longestLineOfCodeTxtInfo = "Longest Line of Code is in: " + i.Name + " | " + "Line number " + (lineCounterCurrent + 1) + " is " + (line.Length + 1) + " characters long!";
//                    }
//                    lineCounterCurrent++;
//                }

//                int charcterCountCurrent = 0;
//                foreach(var character in File.ReadAllText(i.FullName))
//                    charcterCountCurrent++;


//                int lineCt = File.ReadAllLines(i.FullName.ToString()).Length;
//                characterCount += charcterCountCurrent;
//                totalLinesOfCode += lineCt;
//                totalFiles++;

//                string spacesLineCt = GetSpaces(7 - lineCt.ToString().Length);
//                string spacesCharsCt = GetSpaces(7 - charcterCountCurrent.ToString().Length);
//                string spacesNameCt = GetSpaces(40 + 7 - i.Name.Length);

//                AppendText(lineCt + ":" + spacesLineCt + charcterCountCurrent + ":" + spacesCharsCt + i.Name + spacesNameCt + i.DirectoryName + "\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t" + Environment.NewLine, true);
//            }
//        }

//        public void AppendText(string text, bool bShouldColorize)
//        {
//            richTextBox1.SelectionStart = richTextBox1.TextLength;
//            richTextBox1.SelectionLength = 0;
//            richTextBox1.AppendText(text);

//            if(bShouldColorize)
//            {
//                richTextBox1.SelectionBackColor = nextColor;
//            }

//            richTextBox1.ScrollToCaret();

//            bLastColorWasA = !bLastColorWasA;
//        }

//        string GetSpaces(int num)
//        {
//            List<char> spaces = new List<char>();
//            for(int i = 0; i < num; i++)
//                spaces.Add(' ');

//            return new string(spaces.ToArray());
//        }

//        private void panelMenuBar_MouseDown(object sender, MouseEventArgs e)
//        {
//            if(e.Button == MouseButtons.Left)
//            {
//                ReleaseCapture();
//                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
//            }
//        }

//        private void buttonQuit_Click(object sender, EventArgs e) => Environment.Exit(0);

//        private void buttonMinimize_Click(object sender, EventArgs e) => this.WindowState = FormWindowState.Minimized;
//    }
//}