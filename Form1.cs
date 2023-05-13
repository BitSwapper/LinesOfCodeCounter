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
    HashSet<string> acceptedFileTypes = new() {".cs", ".py"};
    HashSet<string> excludedFileTypes = new() {@"\bin", @"\obj", @"\Properties", @"\Debug", @"\Release", @"\LeanTween", @"\ThirdParty"};
    HashSet<CodeFile> codeFiles = new();

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

        if(codeFiles?.Count <= 0)
        {
            MessageBox.Show("No matches found. Assure file extensions you want are inlcuded.");
            return;
        }

        totalFiles = codeFiles.Count;
        totalLines = codeFiles.Sum(x => x.TotalLinesOfCode);
        totalCharacters = codeFiles.Sum(x => x.TotalCharacterCount);

        avgLinesPerFile = totalLines / totalFiles;
        avgCharsPerFile = totalCharacters / totalFiles;
        avgCharsPerLine = totalCharacters / totalLines;

        labelFilezCounted.Text = "Files Analyzed: " + totalFiles;
        labelTotalLines.Text = "Total Lines Of Code: " + totalLines;
        labelTotalChars.Text = "Total Letters: " + totalCharacters;
        labelAvgLines.Text = "Avg Lines / File: " + avgLinesPerFile;
        labelAvgChars.Text = "Avg Letters / File: " + avgCharsPerFile;
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
