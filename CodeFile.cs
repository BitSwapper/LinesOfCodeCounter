namespace LinesOfCodeCounter
{
    public record CodeFile
    {
        public FileInfo FileInfo { get; init; }
        public string FileLocation { get; init; }
        public string FileName { get; init; }
        public string FileExtension { get; init; }
        public long TotalLinesOfCode { get; set; }
        public long TotalCharacterCount { get; set; }
        public long LongestLineOfCode { get; set; }

        public CodeFile(FileInfo fileInfo)
        {
            FileInfo = fileInfo ?? throw new ArgumentNullException(nameof(fileInfo));
            FileName = Path.GetFileNameWithoutExtension(fileInfo.Name);
            FileLocation = fileInfo.DirectoryName ?? "NULL";
            FileExtension = fileInfo.Extension ?? "UNKNOWN";
            ReadFile();
        }

        void ReadFile()
        {
            using(var reader = new StreamReader(FileInfo.FullName))
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
}
