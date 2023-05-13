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
        FillTextBoxDefaults();
        SetupDataGridView();

        void FillTextBoxDefaults()
        {
            UserInputConverter.FillTextFromList(acceptedFileTypes, richTextBoxAllowedFiles);
            UserInputConverter.FillTextFromList(excludedFileTypes, richTextBoxExcludedFiles);
        }

        void SetupDataGridView()
        {
            EnableDoubleBufferedDataGrid();
            dataGridColorHelper = new(dataGridView1, this.Font);
            dataGridView1.ForeColor = dataGridColorHelper.TextColor;
        }

        void EnableDoubleBufferedDataGrid() => typeof(DataGridView).InvokeMember(
            "DoubleBuffered",
            BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
            null,
            dataGridView1,
            new object[] { true });
    }


    void buttonSelectFolder_Click(object sender, EventArgs e)
    {
        using(var folderBrowser = new FolderBrowserDialog())
        {
            DialogResult result = folderBrowser.ShowDialog();

            if(result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowser.SelectedPath))
                FolderToExamine = folderBrowser.SelectedPath;
        }

        labelSelectedFolder.Text = "Examining Folder: " + FolderToExamine;
    }


    void buttonDoCaluclation_Click(object sender, EventArgs e)
    {
        if(string.IsNullOrEmpty(FolderToExamine)) return;

        UpdateSettings();

        if(TryGetResults(out CodeAnalysisResult? result))
            UpdateUILabels(result!);


        void UpdateSettings()
        {
            UserInputConverter.ConvertUserInputsToRealSettings(ref acceptedFileTypes, ref excludedFileTypes, richTextBoxAllowedFiles, richTextBoxExcludedFiles);
            DataGridViewFiller.GenerateAndFillDataGridView(ref codeFiles, dataGridView1, FolderToExamine, acceptedFileTypes, excludedFileTypes);
        }

        bool TryGetResults(out CodeAnalysisResult? result)
        {
            if(codeFiles?.Count <= 0)
            {
                MessageBox.Show("No matches found. Assure file extensions you want are inlcuded.");
                result = null;
                return false;
            }

            result = new CodeAnalysisService().AnalyzeCode(codeFiles!);
            return true;
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
            NativeImports.ReleaseCapture();
            NativeImports.SendMessage(Handle, NativeImports.WM_NCLBUTTONDOWN, NativeImports.HT_CAPTION, 0);
        }
    }


    void buttonQuit_Click(object sender, EventArgs e) => Environment.Exit(0);

    void buttonMinimize_Click(object sender, EventArgs e) => this.WindowState = FormWindowState.Minimized;

    void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) => dataGridColorHelper.DoRowBackColor(e);

    void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e) => dataGridColorHelper.DoRowHeaderColor(sender, e);

    void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e) => dataGridColorHelper.DoSelectAllColor(e);

    void dataGridView1_Paint(object sender, PaintEventArgs e) => dataGridColorHelper.DoColumnHeaderColor(e);
}
