namespace Pzl.Tools.Strings;

public static class LineBreaks
{
    public static string Single => Environment.NewLine;
    public static string Double => $"{Environment.NewLine}{Environment.NewLine}";
    public static string Triple => $"{Environment.NewLine}{Environment.NewLine}{Environment.NewLine}";
}