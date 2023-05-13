namespace LinesOfCodeCounter;

public class CodeAnalysisResult
{
    public int TotalFiles { get; set; }
    public long TotalLines { get; set; }
    public long TotalCharacters { get; set; }
    public float AverageLinesPerFile { get; set; }
    public float AverageCharactersPerFile { get; set; }
    public float AverageCharactersPerLine { get; set; }
    public HashSet<CodeFile> CodeFiles { get; set; }
}
