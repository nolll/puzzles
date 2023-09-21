namespace common.Ocr;

public static class OcrSmallFont
{
    public static string ReadString(string crtImage)
    {
        const int charWidth = 5;
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
        if (rows[0] == "###..")
        {
            if (rows[5] == "###..")
                return 'B';

            if (rows[5] == "#....")
                return 'P';

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
            if (rows[5] == "#....")
                return 'F';

            if (rows[2] == "###..")
                return 'E';

            return 'Z';
        }

        if (rows[0] == "#..#.")
        {
            if (rows[5] == ".##..")
                return 'U';

            if (rows[2] == "##...")
                return 'K';

            return 'H';
        }

        if (rows[0] == "#....")
            return 'L';

        if (rows[0] == "#...#")
            return 'Y';

        if (rows[0] == ".###.")
            return 'I';

        if (rows[0] == "..##.")
            return 'J';

        return ' ';
    }
}