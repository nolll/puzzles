using System;
using System.Linq;

namespace Core.Common.Ocr;

public static class OcrLargeFont
{
    public static string ReadString(string crtImage)
    {
        const int charWidth = 8;
        var rows = crtImage.Split(Environment.NewLine).Select(o => o.Trim()).ToList();
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
        var rows = crtLetter.Split(Environment.NewLine).Select(o => o.Trim().Replace(" ", ".")).ToList();
        if (rows[0] == "#....#..")
        {
            if (rows[1] == "#...#...")
                return 'K';

            return 'H';
        }

        if (rows[0] == "#####...")
        {
            if (rows[9] == "#.......")
                return 'P';

            if (rows[9] == "#####...")
                return 'B';

            return 'R';
        }

        if (rows[0] == ".####...")
        {
            return 'G';
        }

        return ' ';
    }
}