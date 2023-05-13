using System.Data;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace LinesOfCodeCounter;
public static class DataGridViewFiller
{
    static DateTime startTime;
    public static void GenerateAndFillDataGridView(ref List<CodeFile> codeFiles, DataGridView dataGridView, string destFolder, HashSet<string> acceptedFileTypes, HashSet<string> excludedFolders)
    {
        startTime= DateTime.Now;
        string[] directories = System.IO.Directory.GetDirectories(destFolder,"*", System.IO.SearchOption.AllDirectories);

        DirectoryInfo root = new DirectoryInfo(destFolder);
        List<DirectoryInfo> allDirs = directories.Select(d => new DirectoryInfo(d)).ToList();
        allDirs.Add(root);

        ConcurrentBag<CodeFile> concurrentFiles = new();

        Parallel.ForEach(allDirs, dir =>
        {
            foreach(var file in dir.GetFiles())
            {
                if(excludedFolders.Any(folder => file.FullName.Contains(folder)))
                    continue;

                CodeFile newFile = new CodeFile(file);
                if(acceptedFileTypes.Contains(newFile.FileExtension))
                    concurrentFiles.Add(newFile);
            }
        });

        codeFiles = concurrentFiles.ToList();

        FillDataGridView(codeFiles, dataGridView);
        dataGridView.Columns[0].DefaultCellStyle.BackColor = Color.DarkSlateGray;
        dataGridView.Columns[2].DefaultCellStyle.BackColor = Color.DarkSlateGray;
        dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkSlateGray;

        MessageBox.Show((DateTime.Now - startTime).TotalSeconds.ToString());
    }

    static void FillDataGridView(List<CodeFile> codeFiles, DataGridView dataGridView)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("File name", typeof(string));
        dt.Columns.Add("Lines of code", typeof(long));
        dt.Columns.Add("Characters in file", typeof(long));
        dt.Columns.Add("Longest line", typeof(long));
        dt.Columns.Add("Extension", typeof(string));
        dt.Columns.Add("Location", typeof(string));

        foreach(var curFile in codeFiles.OrderByDescending(c => c.TotalLinesOfCode))
        {
            DataRow dr = dt.NewRow();
            dr[0] = curFile.FileName;
            dr[1] = curFile.TotalLinesOfCode;
            dr[2] = curFile.TotalCharacterCount;
            dr[3] = curFile.LongestLineOfCode;
            dr[4] = curFile.FileExtension;
            dr[5] = curFile.FileLocation;
            dt.Rows.Add(dr);
        }
        dataGridView.DataSource = dt;
    }
}
