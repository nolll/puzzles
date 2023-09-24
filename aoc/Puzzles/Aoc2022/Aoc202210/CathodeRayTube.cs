using System;
using System.Collections.Generic;
using System.Linq;
using Common.Ocr;
using Common.Strings;

namespace Aoc.Puzzles.Aoc2022.Aoc202210;

public class CathodeRayTube
{
    private const string NoopOperation = "noop";
    private const string AddXOperation = "addx";

    public (int sum, string letters, string image) Run(string input)
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

            if (commandCyclesLeft > 0) 
                commandCyclesLeft--;

            if ((cycle + 20) % 40 == 0 && cycle is > 0 and < 221)
                values.Add(x * cycle);

            var visualDrawPosition = drawPosition % 40;
            var isLit = x == visualDrawPosition || x == (visualDrawPosition + 1) || x == (visualDrawPosition - 1);
            var drawChar = isLit ? '#' : '.';
            if (drawPosition >= 0 && drawPosition < crt.Length)
                crt[drawPosition] = drawChar;

            if (command == "")
            {
                var line = lines[currentLine];
                var parts = line.Split(' ');
                command = parts[0];
                if (command == AddXOperation)
                {
                    value = int.Parse(parts[1]);
                    commandCyclesLeft = 1;
                }
            }

            if (commandCyclesLeft == 0)
            {
                if (command == AddXOperation)
                    x += value;
                
                if (command.Length > 0)
                    currentLine++;

                command = "";
            }
        }

        var sum = values.Sum();
        var image = CreateImage(crt);
        var letters = OcrSmallFont.ReadString(image);
        return (sum, letters, image);
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
}