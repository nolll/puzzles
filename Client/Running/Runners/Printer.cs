using Spectre.Console;

namespace Pzl.Client.Running.Runners;

public static class Printer
{
    public static void CarriageReturn() => Console.Write("\r");
    public static void WriteLine() => AnsiConsole.WriteLine();
    public static void WriteLine(string s) => AnsiConsole.WriteLine(s);
    public static void Markup(string s) => AnsiConsole.Markup(s);
    public static void MarkupLine(string s) => AnsiConsole.MarkupLine(s);
    public static void HideCursor() => AnsiConsole.Cursor.Show(false);
    public static void ShowCursor() => AnsiConsole.Cursor.Show(true);
}