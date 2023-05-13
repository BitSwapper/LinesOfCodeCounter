namespace LinesOfCodeCounter;

public class CodeAnalysisService
{
    public CodeAnalysisResult AnalyzeCode(HashSet<CodeFile> codeFiles)
    {
        var totalFiles = codeFiles.Count;
        var totalLines = codeFiles.Sum(x => x.TotalLinesOfCode);
        var totalCharacters = codeFiles.Sum(x => x.TotalCharacterCount);

        var avgLinesPerFile = totalFiles > 0 ? totalLines / (float)totalFiles : 0;
        var avgCharsPerFile = totalFiles > 0 ? totalCharacters / (float)totalFiles : 0;
        var avgCharsPerLine = totalLines > 0 ? totalCharacters / (float)totalLines : 0;

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
