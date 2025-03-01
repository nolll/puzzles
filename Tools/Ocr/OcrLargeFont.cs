using Pzl.Tools.Strings;

namespace Pzl.Tools.Ocr;

public static class OcrLargeFont
{
    public static string ReadString(string crtImage)
    {
        const int charWidth = 8;
        var rows = StringReader.ReadLines(crtImage).Select(o => o.Trim()).ToList();
        var stringLength = (int)Math.Ceiling((double)rows.First().Length / charWidth);
        rows = rows.Select(o => o.PadRight(stringLength * charWidth, '.')).ToList();
        var s = "";

        for (var i = 0; i < stringLength; i++)
        {
            var start = i * charWidth;
            var letter = string.Join(LineBreaks.Single, rows.Select(o => o.Substring(start, charWidth)));
            s += ReadLetter(letter);
        }

        return s;
    }

    public static char ReadLetter(string crtLetter)
    {
        var rows = StringReader.ReadLines(crtLetter).Select(o => o.Trim().Replace(" ", ".")).ToList();
        return rows[0] switch
        {
            "#....#.." when rows[1] == "#...#..." => 'K',
            "#....#.." => 'H',
            "#####..." when rows[9] == "#......." => 'P',
            "#####..." when rows[9] == "#####..." => 'B',
            "#####..." => 'R',
            ".####..." => 'G',
            _ => ' '
        };
    }
}