using System.Data;
using System.Windows.Forms;

namespace LinesOfCodeCounter;
public static class DataGridViewFiller
{
    public static void GenerateAndFillDataGridView(ref List<CodeFile> codeFiles, DataGridView dataGridView, string destFolder, List<string> acceptedFileTypes, List<string> excludedFolders)
    {
        codeFiles = new();

        string[] directories = System.IO.Directory.GetDirectories(destFolder,"*", System.IO.SearchOption.AllDirectories);
        FileInfo[] files = GetFileInfo(directories);
        FileInfo[] folderFiles = new DirectoryInfo(destFolder).GetFiles();
        files = AddTwoFileInfoArrays(files, folderFiles);

        foreach(var file in files)
        {
            CodeFile newFile = new(file);
            if(acceptedFileTypes.Contains(newFile.fileExtension) && !IsInExcludedFolder(file.FullName, excludedFolders))
            {
                codeFiles.Add(newFile);
            }
        }

        FillDataGridView(codeFiles, dataGridView);
        dataGridView.Columns[0].DefaultCellStyle.BackColor = Color.DarkSlateGray;
        dataGridView.Columns[2].DefaultCellStyle.BackColor = Color.DarkSlateGray;
        dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkSlateGray;
    }

    static bool IsInExcludedFolder(string filePath, List<string> excludedFolders)
    {
        foreach(string folder in excludedFolders)
        {
            if(filePath.Contains(folder))
            {
                return true;
            }
        }
        return false;
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

        codeFiles = codeFiles.OrderBy(c => c.totalLinesOfCode).ToList();
        for(int i = codeFiles.Count - 1; i >= 0; i--)
        {
            var curFile = codeFiles[i];

            DataRow dr = dt.NewRow();
            dr[0] = curFile.fileName;
            dr[1] = curFile.totalLinesOfCode;
            dr[2] = curFile.totalCharacterCount;
            dr[3] = curFile.longestLineOfCode;
            dr[4] = curFile.fileExtension;
            dr[5] = curFile.fileLocation;
            dt.Rows.Add(dr);
        }
        dataGridView.DataSource = dt;
    }

    static FileInfo[] GetFileInfo(string[] directories)
    {
        List<FileInfo> fileList = new List<FileInfo>();

        foreach(var d in directories)
        {
            DirectoryInfo directoryLocation = new DirectoryInfo(d);
            fileList.AddRange(directoryLocation.GetFiles());
        }
        return fileList.ToArray();
    }


    static FileInfo[] AddTwoFileInfoArrays(FileInfo[] files, FileInfo[] folderFiles)
    {
        Array.Resize(ref files, files.Length + folderFiles.Length);
        Array.Copy(folderFiles, 0, files, files.Length - folderFiles.Length, folderFiles.Length);
        return files;
    }
}
