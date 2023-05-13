namespace LinesOfCodeCounter;
public static class UserInputConverter
{
    public static void ConvertUserInputsToRealSettings(ref HashSet<string> acceptedFileTypes, ref HashSet<string> excludedFileTypes, RichTextBox richTextBoxAllowedFiles, RichTextBox richTextBoxExcludedFiles)
    {
        FillListFromText(ref acceptedFileTypes, richTextBoxAllowedFiles);
        FillListFromText(ref excludedFileTypes, richTextBoxExcludedFiles);
    }

    public static void FillTextFromList(HashSet<string> list, RichTextBox textBox)
    {
        textBox.Text = "";
        foreach(var line in list)
            if(line != string.Empty)
                textBox.Text += line + Environment.NewLine;
    }

    static void FillListFromText(ref HashSet<string> list, RichTextBox textBox)
    {
        list = new();

        foreach(var line in textBox.Lines)
            if(line != string.Empty)
                list.Add(line);
    }
}
