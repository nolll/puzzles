using System;
using System.Collections.Generic;
using System.Linq;
using Core.Common.Strings;

namespace Core.Puzzles.Year2020.Day14;

public class BitmaskSystem2
{
    public long Run(string input)
    {
        var bitmask = "";
        var mem = new Dictionary<long, long>();
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

                var memPositions = ApplyBitmask(bitmask, memPos);

                foreach (var pos in memPositions)
                {
                    mem[pos] = val;
                }
            }
        }

        return mem.Values.Sum();
    }

    private static List<long> ApplyBitmask(string bitmask, in long address)
    {
        var addresses = new List<string> {""};
        var binary = Convert.ToString(address, 2).PadLeft(36, '0').ToCharArray();
        var mask = bitmask.ToCharArray();
        for (var i = 0; i < bitmask.Length; i++)
        {
            var maskChar = mask[i];

            if (maskChar == '1')
            {
                for (var j = 0; j < addresses.Count; j++)
                {
                    addresses[j] += "1";
                }
            }

            else if (maskChar == '0')
            {
                for (var j = 0; j < addresses.Count; j++)
                {
                    addresses[j] += binary[i];
                }
            }

            else if (maskChar == 'X')
            {
                var newAddresses = new List<string>();
                for (var j = 0; j < addresses.Count; j++)
                {
                    newAddresses.Add(addresses[j] + "1");
                    addresses[j] += "0";
                }

                addresses = addresses.Concat(newAddresses).ToList();
            }
        }

        return addresses.Select(o => Convert.ToInt64(o, 2)).ToList();
    }
}