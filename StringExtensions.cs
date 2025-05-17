namespace LinesOfCodeCounter;

public static class StringExtensions
{
    public static string RemoveStartingMask(this string source, string mask)
    {
        if(string.IsNullOrEmpty(source) || string.IsNullOrEmpty(mask))
            return source;

        if(!mask.EndsWith(@"\"))
            mask += @"\";

        int index = source.IndexOf(mask);
        if(index != -1)
            return source.Substring(index + mask.Length);

        return source;
    }
}
