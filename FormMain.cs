using System.Reflection;

namespace LinesOfCodeCounter;

public partial class FormMain : Form
{


    string FolderToExamine { get; set; }
    DataGridColorHelper dataGridColorHelper;
    HashSet<string> acceptedFileTypes = new() {".cs", ".py"};
    HashSet<string> excludedFileTypes = new() {@"\bin", @"\obj", @"\Properties", @"\Debug", @"\Release", @"\LeanTween", @"\ThirdParty"};
    HashSet<CodeFile> codeFiles = new();


    public FormMain() => InitializeComponent();


    void Form1_Load(object sender, EventArgs e)
    {
        dataGridColorHelper = new(dataGridView1, this.Font);

        FillTextBoxDefaults();

        EnableDoubleBufferedDataGrid();
        dataGridView1.ForeColor = dataGridColorHelper.TextColor;
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
        if(string.IsNullOrEmpty(FolderToExamine)) return;

        UpdateSettings();
        UpdateUILabels(GetResults());


        void UpdateSettings()
        {
            UserInputConverter.ConvertUserInputsToRealSettings(ref acceptedFileTypes, ref excludedFileTypes, richTextBoxAllowedFiles, richTextBoxExcludedFiles);
            DataGridViewFiller.GenerateAndFillDataGridView(ref codeFiles, dataGridView1, FolderToExamine, acceptedFileTypes, excludedFileTypes);
        }

        CodeAnalysisResult GetResults()
        {
            if(codeFiles?.Count <= 0)
            {
                MessageBox.Show("No matches found. Assure file extensions you want are inlcuded.");
                return null;
            }

            return new CodeAnalysisService().AnalyzeCode(ref codeFiles!, FolderToExamine, acceptedFileTypes, excludedFileTypes);
        }

        void UpdateUILabels(CodeAnalysisResult result)
        {
            if(result == null) return;
            labelFilezCounted.Text = "Files Analyzed: " + result.TotalFiles;
            labelTotalLines.Text = "Total Lines Of Code: " + result.TotalLines;
            labelTotalChars.Text = "Total Letters: " + result.TotalCharacters;
            labelAvgLines.Text = "Avg Lines / File: " + result.AverageLinesPerFile;
            labelAvgChars.Text = "Avg Letters / File: " + result.AverageCharactersPerLine;
        }
    }


    void panelMenuBar_MouseDown(object sender, MouseEventArgs e)
    {
        if(e.Button == MouseButtons.Left)
        {
            FormMainHelpers.ReleaseCapture();
            FormMainHelpers.SendMessage(Handle, FormMainHelpers.WM_NCLBUTTONDOWN, FormMainHelpers.HT_CAPTION, 0);
        }
    }


    void buttonQuit_Click(object sender, EventArgs e) => Environment.Exit(0);

    void buttonMinimize_Click(object sender, EventArgs e) => this.WindowState = FormWindowState.Minimized;

    void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) => dataGridColorHelper.DoRowBackColor(e);

    void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e) => dataGridColorHelper.DoRowHeaderColor(sender, e);

    void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e) => dataGridColorHelper.DoSelectAllColor(e);

    void dataGridView1_Paint(object sender, PaintEventArgs e) => dataGridColorHelper.DoColumnHeaderColor(e);
}
