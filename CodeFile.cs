namespace LinesOfCodeCounter;

public class CodeFile
{
    readonly FileInfo _fileInfo;
    public string FileLocation { get; }
    public string FileName { get; }
    public string FileExtension { get; }
    public long TotalLinesOfCode { get; set; }
    public long TotalCharacterCount { get; set; }
    public long LongestLineOfCode { get; set; }

    public CodeFile(FileInfo fileInfo)
    {
        _fileInfo = fileInfo ?? throw new ArgumentNullException(nameof(fileInfo));

        FileName = Path.GetFileNameWithoutExtension(fileInfo.Name);
        FileLocation = fileInfo.DirectoryName ?? "NULL";
        FileExtension = fileInfo.Extension ?? "UNKNOWN";

        ReadFile();
    }

    void ReadFile()
    {
        using(var reader = new StreamReader(_fileInfo.FullName))
        {
            string? line;
            while((line = reader.ReadLine()) != null)
            {
                TotalLinesOfCode++;
                TotalCharacterCount += line.Length;
                LongestLineOfCode = Math.Max(LongestLineOfCode, line.Length);
            }
        }
    }
}
