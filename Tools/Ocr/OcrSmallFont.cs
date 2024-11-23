using Pzl.Tools.Strings;

namespace Pzl.Tools.Ocr;

public static class OcrSmallFont
{
    public static string ReadString(string crtImage)
    {
        const int charWidth = 5;
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
            "###.." when rows[5] == "###.." => 'B',
            "###.." when rows[5] == "#...." => 'P',
            "###.." => 'R',
            ".##.." when rows[5] == ".###." => 'G',
            ".##.." when rows[3] == "#...." => 'C',
            ".##.." when rows[5] == ".##.." => 'O',
            ".##.." => 'A',
            "####." when rows[5] == "#...." => 'F',
            "####." when rows[2] == "###.." => 'E',
            "####." => 'Z',
            "#..#." when rows[5] == ".##.." => 'U',
            "#..#." when rows[2] == "##..." => 'K',
            "#..#." => 'H',
            "#...." => 'L',
            "#...#" => 'Y',
            ".###." => 'I',
            "..##." => 'J',
            _ => ' '
        };
    }
}