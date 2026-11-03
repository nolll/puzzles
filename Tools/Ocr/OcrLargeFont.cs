using System.Text;
using Pzl.Tools.Strings;

namespace Pzl.Tools.Ocr;

public static class OcrLargeFont
{
    public static string ReadString(string crtImage)
    {
        const int charWidth = 8;
        var rows = crtImage.Split(LineBreaks.Single).Select(o => o.Trim()).ToList();
        var stringLength = (int)Math.Ceiling((double)rows.First().Length / charWidth);
        rows = rows.Select(o => o.PadRight(stringLength * charWidth, '.')).ToList();
        var sb = new StringBuilder();

        for (var i = 0; i < stringLength; i++)
        {
            var start = i * charWidth;
            var letter = string.Join(LineBreaks.Single, rows.Select(o => o.Substring(start, charWidth)));
            sb.Append(ReadLetter(letter));
        }

        return sb.ToString();
    }

    public static char ReadLetter(string crtLetter) => ReadLetter(GetRows(crtLetter));

    private static char ReadLetter(string[] rows) => rows[0] switch
    {
        "#....#.." when rows[1] == "#...#..." => 'K',
        "#....#.." => 'H',
        "#####..." when rows[9] == "#......." => 'P',
        "#####..." when rows[9] == "#####..." => 'B',
        "#####..." => 'R',
        ".####..." => 'G',
        _ => ' '
    };
    
    private static string[] GetRows(string crtLetter) => [.. crtLetter.Split(LineBreaks.Single).Select(o => o.Trim().Replace(" ", "."))];
}