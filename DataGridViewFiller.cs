using System.Collections.Concurrent;
using System.Data;

namespace LinesOfCodeCounter;

public static class DataGridViewFiller
{
    public static void GenerateAndFillDataGridView(ref HashSet<CodeFile> codeFiles, DataGridView dataGridView, string destFolder, HashSet<string> acceptedFileTypes, HashSet<string> excludedFolders)
    {
        var startTime = DateTime.Now;
        var directories = Directory.GetDirectories(destFolder, "*", SearchOption.AllDirectories)
                               .Select(d => new DirectoryInfo(d))
                               .Where(d => !excludedFolders.Any(e => d.FullName.Contains(e))).ToList();

        directories.Add(new DirectoryInfo(destFolder));

        var concurrentFiles = new ConcurrentBag<CodeFile>();

        directories.AsParallel().ForAll(dir => {
            foreach(var file in dir.GetFiles().Where(file => acceptedFileTypes.Contains(file.Extension)))
                concurrentFiles.Add(new CodeFile(file)); });

        codeFiles = concurrentFiles.ToHashSet();

        FillDataGridView(codeFiles, dataGridView);
        SetColumnStyles(dataGridView);
        MessageBox.Show((DateTime.Now - startTime).TotalSeconds.ToString());
    }


    static void FillDataGridView(HashSet<CodeFile> codeFiles, DataGridView dataGridView)
    {
        var dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[]
        {
            new DataColumn("File name", typeof(string)),
            new DataColumn("Lines of code", typeof(long)),
            new DataColumn("Characters in file", typeof(long)),
            new DataColumn("Longest line", typeof(long)),
            new DataColumn("Extension", typeof(string)),
            new DataColumn("Location", typeof(string))
        });

        codeFiles.OrderByDescending(c => c.TotalLinesOfCode).ToList().ForEach(curFile => {
            dt.Rows.Add(curFile.FileName, curFile.TotalLinesOfCode, curFile.TotalCharacterCount, curFile.LongestLineOfCode, curFile.FileExtension, curFile.FileLocation); });

        dataGridView.DataSource = dt;
    }


    static void SetColumnStyles(DataGridView dataGridView)
    {
        foreach(DataGridViewColumn column in dataGridView.Columns)
            column.DefaultCellStyle.BackColor = Color.DarkSlateGray;

        dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkSlateGray;
    }
}
