using Puzzles.Common.Strings;

namespace Puzzles.Common.Ocr;

public static class OcrSmallFont
{
    public static string ReadString(string crtImage)
    {
        const int charWidth = 5;
        var rows = InputReader.ReadLines(crtImage).Select(o => o.Trim()).ToList();
        var stringLength = (int)Math.Ceiling((double)rows.First().Length / charWidth);
        rows = rows.Select(o => o.PadRight(stringLength * charWidth, '.')).ToList();
        var s = "";

        for (var i = 0; i < stringLength; i++)
        {
            var start = i * charWidth;
            var letter = string.Join(Environment.NewLine, rows.Select(o => o.Substring(start, charWidth)));
            s += ReadLetter(letter);
        }

        return s;
    }

    public static char ReadLetter(string crtLetter)
    {
        var rows = InputReader.ReadLines(crtLetter).Select(o => o.Trim().Replace(" ", ".")).ToList();
        switch (rows[0])
        {
            case "###.." when rows[5] == "###..":
                return 'B';
            case "###.." when rows[5] == "#....":
                return 'P';
            case "###..":
                return 'R';
            case ".##.." when rows[5] == ".###.":
                return 'G';
            case ".##.." when rows[3] == "#....":
                return 'C';
            case ".##.." when rows[5] == ".##..":
                return 'O';
            case ".##..":
                return 'A';
            case "####." when rows[5] == "#....":
                return 'F';
            case "####." when rows[2] == "###..":
                return 'E';
            case "####.":
                return 'Z';
            case "#..#." when rows[5] == ".##..":
                return 'U';
            case "#..#." when rows[2] == "##...":
                return 'K';
            case "#..#.":
                return 'H';
            case "#....":
                return 'L';
            case "#...#":
                return 'Y';
            case ".###.":
                return 'I';
            case "..##.":
                return 'J';
            default:
                return ' ';
        }
    }
}