using System;
using System.Collections.Generic;
using System.Linq;
using Common.Strings;

namespace Aoc.Puzzles.Year2020.Day14;

public class BitmaskSystem1
{
    public long Run(string input)
    {
        var bitmask = "";
        var mem = new Dictionary<int, long>();
        var rows = PuzzleInputReader.ReadLines(input);
        foreach (var row in rows)
        {
            if (row.StartsWith("mask"))
            {
                bitmask = row.Split("=")[1].Trim();
            }
            else
            {
                var parts = row.Split("=");
                var val = long.Parse(parts[1].Trim());
                var memPos = int.Parse(parts[0][4..].Replace("]", ""));

                var valAfterBitmask = ApplyBitmask(bitmask, val);

                mem[memPos] = valAfterBitmask;
            }
        }

        return mem.Values.Sum();
    }

    private static long ApplyBitmask(string bitmask, in long val)
    {
        var binary = Convert.ToString(val, 2).PadLeft(36, '0').ToCharArray();
        var mask = bitmask.ToCharArray();
        for (var i = 0; i < binary.Length; i++)
        {
            var maskChar = mask[i];

            if (maskChar != 'X')
                binary[i] = maskChar;
        }

        return Convert.ToInt64(new string(binary.ToArray()), 2);
    }
}