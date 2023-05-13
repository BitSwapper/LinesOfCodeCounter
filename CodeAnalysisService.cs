namespace LinesOfCodeCounter;

public class CodeAnalysisService
{
    public CodeAnalysisResult AnalyzeCode(ref HashSet<CodeFile> codeFiles, string folderToExamine, HashSet<string> acceptedFileTypes, HashSet<string> excludedFileTypes)
    {
        if(string.IsNullOrEmpty(folderToExamine))
            throw new ArgumentException("folderToExamine cannot be null or empty.");


        var totalFiles = codeFiles.Count;
        var totalLines = codeFiles.Sum(x => x.TotalLinesOfCode);
        var totalCharacters = codeFiles.Sum(x => x.TotalCharacterCount);

        var avgLinesPerFile = totalLines / (float)totalFiles;
        var avgCharsPerFile = totalCharacters / (float)totalFiles;
        var avgCharsPerLine = totalCharacters / (float)totalLines;

        return new CodeAnalysisResult
        {
            TotalFiles = totalFiles,
            TotalLines = totalLines,
            TotalCharacters = totalCharacters,
            AverageLinesPerFile = avgLinesPerFile,
            AverageCharactersPerFile = avgCharsPerFile,
            AverageCharactersPerLine = avgCharsPerLine,
            CodeFiles = codeFiles
        };
    }
}
