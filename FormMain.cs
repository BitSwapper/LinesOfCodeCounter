using System.Reflection;

namespace LinesOfCodeCounter;

public partial class FormMain : Form
{
    string FolderToExamine { get; set; }
    DataGridColorHelper dataGridColorHelper;
    HashSet<string> acceptedFileTypes = new() {".cs", ".py", ".shader", ".cpp", ".h"};
    HashSet<string> excludedFilePaths = new() {@"\bin", @"\obj", @"\Properties", @"\Debug", @"\Release", @"\Plugins", @"\LeanTween", @"\ThirdParty", @"\Third Party", @"\TextMesh Pro" };
    HashSet<CodeFile> codeFiles = new();


    public FormMain() => InitializeComponent();

    void Form1_Load(object sender, EventArgs e) => SetupUI();

    void SetupUI()
    {
        labelFilezCounted.Text = labelTotalLines.Text = labelTotalChars.Text = labelAvgLines.Text = labelAvgChars.Text = string.Empty;
        UserInputConverter.FillTextBoxesWithSettings(acceptedFileTypes, excludedFilePaths, richTextBoxAllowedFiles, richTextBoxExcludedFiles);
        SetupDataGridView();

        void SetupDataGridView()
        {
            EnableDoubleBufferedDataGrid();
            dataGridColorHelper = new(dataGridView1, this.Font);
            dataGridView1.ForeColor = dataGridColorHelper.TextColor;

            void EnableDoubleBufferedDataGrid() => typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, dataGridView1, new object[] { true });
        }
    }


    void buttonSelectFolder_Click(object sender, EventArgs e)
    {
        using(var folderBrowser = new FolderBrowserDialog())
        {
            DialogResult result = folderBrowser.ShowDialog();
            if(result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowser.SelectedPath))
            {
                FolderToExamine = folderBrowser.SelectedPath;
                labelTimeTaken.Text = "";
            }
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
            UserInputConverter.ConvertUserInputsToRealSettings(ref acceptedFileTypes, ref excludedFilePaths, richTextBoxAllowedFiles, richTextBoxExcludedFiles);
            var timeTaken = DataGridViewFiller.GenerateAndFillDataGridView(ref codeFiles, dataGridView1, FolderToExamine, acceptedFileTypes, excludedFilePaths);
            labelTimeTaken.Text = $"Analysis finished in {timeTaken.TotalSeconds.ToString("F2")} seconds.";
        }

        bool TryGetResults(out CodeAnalysisResult? result)
        {
            if(codeFiles?.Count <= 0)
            {
                MessageBox.Show("No matches found. Assure file extensions you want are inlcuded.");
                result = null;
                return false;
            }

            result = new CodeAnalysisResult(codeFiles!);
            return true;
        }

        void UpdateUILabels(CodeAnalysisResult result)
        {
            if(result == null) return;
            labelFilezCounted.Text = result.TotalFiles.ToString("#,0");
            labelTotalLines.Text = result.TotalLines.ToString("#,0");
            labelTotalChars.Text = result.TotalCharacters.ToString("#,0");
            labelAvgLines.Text = result.AverageLinesPerFile.ToString("#,0.##");
            labelAvgChars.Text = result.AverageCharactersPerLine.ToString("#,0.##");
        }
    }


    void panelMenuBar_MouseDown(object sender, MouseEventArgs e)
    {
        if(e.Button == MouseButtons.Left)
        {
            Native.ReleaseCapture();
            Native.SendMessage(Handle, Native.WM_NCLBUTTONDOWN, Native.HT_CAPTION, 0);
        }
    }

    void buttonQuit_Click(object sender, EventArgs e) => Environment.Exit(0);

    void buttonMinimize_Click(object sender, EventArgs e) => this.WindowState = FormWindowState.Minimized;

    void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) => dataGridColorHelper.DoRowBackColor(e);

    void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e) => dataGridColorHelper.DoRowHeaderColor(sender, e);

    void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e) => dataGridColorHelper.DoSelectAllColor(e);

    void dataGridView1_Paint(object sender, PaintEventArgs e) => dataGridColorHelper.DoColumnHeaderColor(e);
}
