using System;
using System.Collections.Generic;
using System.Linq;
using Core.Common.Strings;

namespace Core.Puzzles.Year2022.Day10;

public class CathodeRayTube
{
    public int Part1(string input)
    {
        var values = new List<int>();
        var lines = PuzzleInputReader.ReadLines(input, false);
        var cycle = 0;
        var x = 1;
        var command = "";
        var value = 0;
        var commandCyclesLeft = 0;
        var currentLine = 0;

        while (currentLine < lines.Count)
        {
            cycle++;
            var line = lines[currentLine];
            if (commandCyclesLeft > 0)
            {
                commandCyclesLeft--;
            }

            if ((cycle + 20) % 40 == 0 && cycle is > 0 and < 221)
                values.Add(x * cycle);

            if (command == "")
            {
                var parts = line.Split(' ');
                command = parts[0];
                if (command == "noop")
                {
                    commandCyclesLeft = 0;
                }
                else if (command == "addx")
                {
                    value = int.Parse(parts[1]);
                    commandCyclesLeft = 1;
                }
            }

            if (commandCyclesLeft == 0)
            {
                if (command == "noop")
                {
                    currentLine++;
                }
                else if (command == "addx")
                {
                    x += value;
                    currentLine++;
                }

                command = "";
            }
        }

        return values.Sum();
    }

    public string Part2Image(string input)
    {
        var values = new List<int>();
        var lines = PuzzleInputReader.ReadLines(input, false);
        var cycle = 0;
        var x = 1;
        var command = "";
        var value = 0;
        var commandCyclesLeft = 0;
        var currentLine = 0;
        var crt = new char[240];

        while (currentLine < lines.Count)
        {
            cycle++;
            var drawPosition = cycle - 1;

            var line = lines[currentLine];
            if (commandCyclesLeft > 0)
            {
                commandCyclesLeft--;
            }

            if ((cycle + 20) % 40 == 0 && cycle is > 0 and < 221)
                values.Add(x * cycle);

            var visualDrawPosition = drawPosition % 40;
            var isLit = x == visualDrawPosition || x == (visualDrawPosition + 1) || x == (visualDrawPosition - 1);
            var drawChar = isLit ? '#' : '.';
            if (drawPosition >= 0 && drawPosition < crt.Length)
                crt[drawPosition] = drawChar;

            if (command == "")
            {
                var parts = line.Split(' ');
                command = parts[0];
                if (command == "noop")
                {
                    commandCyclesLeft = 0;
                }
                else if (command == "addx")
                {
                    value = int.Parse(parts[1]);
                    commandCyclesLeft = 1;
                }
            }

            if (commandCyclesLeft == 0)
            {
                if (command == "noop")
                {
                    currentLine++;
                }
                else if (command == "addx")
                {
                    x += value;
                    currentLine++;
                }

                command = "";
            }
        }

        return CreateImage(crt);
    }

    public string Part2(string input)
    {
        var image = Part2Image(input);
        return ReadCrtImage(image);
    }

    private string CreateImage(char[] chars)
    {
        var i = 0;
        var s = "";
        foreach (var c in chars)
        {
            s += c;
            i++;

            if (i > 0 && i % 40 == 0)
                s += Environment.NewLine;
        }

        return s.Trim();
    }

    private string ReadCrtImage(string crtImage)
    {
        const int charWidth = 5;
        var rows = crtImage.Split("\n").Select(o => o.Trim()).ToList();
        var stringLength = rows.First().Length / charWidth;
        var s = "";

        for (var i = 0; i < stringLength; i++)
        {
            var start = i * charWidth;
            var letter = string.Join(Environment.NewLine, rows.Select(o => o.Substring(start, charWidth)));
            s += ReadCrtLetter(letter);
        }

        return s;
    }

    private char ReadCrtLetter(string crtLetter)
    {
        var rows = crtLetter.Split("\n").Select(o => o.Trim()).ToList();
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

            return 'A';
        }

        if (rows[0] == "####.")
        {
            if (rows[2] == "###..")
                return 'E';

            return 'Z';
        }

        if (rows[0] == "#..#.")
            return 'K';

        return ' ';
    }
}