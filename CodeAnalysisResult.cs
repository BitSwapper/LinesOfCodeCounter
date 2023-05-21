namespace LinesOfCodeCounter;

public record CodeAnalysisResult
{
    public int TotalFiles { get; set; }
    public long TotalLines { get; set; }
    public long TotalCharacters { get; set; }
    public float AverageLinesPerFile { get; set; }
    public float AverageCharactersPerFile { get; set; }
    public float AverageCharactersPerLine { get; set; }
    public HashSet<CodeFile> CodeFiles { get; set; }

    public CodeAnalysisResult(HashSet<CodeFile> codeFiles)
    {
        TotalFiles = codeFiles.Count;
        TotalLines = codeFiles.Sum(x => x.TotalLinesOfCode);
        TotalCharacters = codeFiles.Sum(x => x.TotalCharacterCount);
        AverageLinesPerFile = TotalFiles > 0 ? TotalLines / (float)TotalFiles : 0;
        AverageCharactersPerFile = TotalFiles > 0 ? TotalCharacters / (float)TotalFiles : 0;
        AverageCharactersPerLine = TotalLines > 0 ? TotalCharacters / (float)TotalLines : 0;

        CodeFiles= codeFiles;
    }
}
