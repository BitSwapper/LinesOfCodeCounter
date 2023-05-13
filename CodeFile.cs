using System;
using System.IO;
using System.Linq;

namespace LinesOfCodeCounter
{
    public class CodeFile
    {
        private readonly FileInfo _fileInfo;
        public string FileLocation { get; }
        public string FileName { get; }
        public string FileExtension { get; }
        public long TotalLinesOfCode { get; private set; }
        public long TotalCharacterCount { get; private set; }
        public long LongestLineOfCode { get; private set; }

        public CodeFile(FileInfo fileInfo)
        {
            _fileInfo = fileInfo ?? throw new ArgumentNullException(nameof(fileInfo));

            FileName = Path.GetFileNameWithoutExtension(fileInfo.Name);
            FileLocation = fileInfo.DirectoryName;
            FileExtension = fileInfo.Extension;

            ReadFile();
        }

        private void ReadFile()
        {
            var lines = File.ReadAllLines(_fileInfo.FullName);

            TotalLinesOfCode = lines.Length;
            TotalCharacterCount = lines.Sum(line => line.Length);
            LongestLineOfCode = lines.Any() ? lines.Max(line => line.Length) : 0;
        }
    }
}
