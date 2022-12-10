using System;
using System.Linq;

namespace Core.Common.Ocr;

public static class OcrReader
{
    public static string ReadString(string crtImage)
    {
        const int charWidth = 5;
        var rows = crtImage.Replace(" ", ".").Split("\n").Select(o => o.Trim()).ToList();
        var stringLength = rows.First().Length / charWidth;
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
        var rows = crtLetter.Split("\n").Select(o => o.Trim().Replace(" ", ".")).ToList();
        if (rows[0] == "###..")
        {
            if (rows[5] == "###..")
                return 'B'; 

            return 'R';
        }

        if (rows[0] == ".##..")
        {
            if (rows[5] == ".###.")
                return 'G';

            if (rows[3] == "#....")
                return 'C';

            if (rows[5] == ".##..")
                return 'O';

            return 'A';
        }
        
        if (rows[0] == "####.")
        {
            if (rows[2] == "###..")
                return 'E';

            return 'Z';
        }

        if (rows[0] == "#..#.")
        {
            if (rows[5] == ".##..")
                return 'U';

            return 'K';
        }

        if (rows[0] == "#....")
        {
            return 'L';
        }

        if (rows[0] == ".###.")
        {
            return 'I';
        }

        return ' ';
    }
}