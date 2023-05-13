namespace LinesOfCodeCounter;

public static class UserInputConverter
{
    public static void ConvertUserInputsToRealSettings(ref HashSet<string> acceptedFileTypes, ref HashSet<string> excludedFileTypes, RichTextBox richTextBoxAllowedFiles, RichTextBox richTextBoxExcludedFiles)
    {
        acceptedFileTypes = FillHashSetFromText(richTextBoxAllowedFiles);
        excludedFileTypes = FillHashSetFromText(richTextBoxExcludedFiles);
    }

    public static void FillTextBoxesWithSettings(HashSet<string> acceptedFileTypes, HashSet<string> excludedFileTypes, RichTextBox richTextBoxAllowedFiles, RichTextBox richTextBoxExcludedFiles)
    {
        FillTextBoxFromHashSet(acceptedFileTypes, richTextBoxAllowedFiles);
        FillTextBoxFromHashSet(excludedFileTypes, richTextBoxExcludedFiles);
    }

    private static void FillTextBoxFromHashSet(HashSet<string> hashSet, RichTextBox textBox) => textBox.Text = string.Join(Environment.NewLine, hashSet.Where(line => !string.IsNullOrEmpty(line)));

    private static HashSet<string> FillHashSetFromText(RichTextBox textBox) => new HashSet<string>(textBox.Lines.Where(line => !string.IsNullOrEmpty(line)));
}
