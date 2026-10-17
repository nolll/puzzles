using Pzl.Common;
using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2020;

[Name("Docking Data")]
public class Aoc202014 : AocPuzzle
{
    [Puzzle("df6ceb0c5b8153992f5246f19ad4d827")]
    public long Part1(string input)
    {
        var bitmask = "";
        var mem = new Dictionary<int, long>();
        var rows = input.Split(LineBreaks.Single);
        foreach (var row in rows)
        {
            if (row.StartsWith("mask"))
            {
                bitmask = ParseMask(row);
            }
            else
            {
                var (mempos, val) = ParseMem(row);
                var valAfterBitmask = ApplyBitmaskPart1(bitmask, val);
                mem[mempos] = valAfterBitmask;
            }
        }

        return mem.Values.Sum();
    }

    [Puzzle("578a4ca2408035c16e799f4662a58823")]
    public long Part2(string input)
    {
        var bitmask = "";
        var mem = new Dictionary<long, long>();
        var rows = input.Split(LineBreaks.Single);
        foreach (var row in rows)
        {
            if (row.StartsWith("mask"))
            {
                bitmask = ParseMask(row);
            }
            else
            {
                var (mempos, val) =  ParseMem(row);
                var memPositions = ApplyBitmaskPart2(bitmask, mempos);

                foreach (var pos in memPositions)
                {
                    mem[pos] = val;
                }
            }
        }

        return mem.Values.Sum();
    }

    private static long ApplyBitmaskPart1(string bitmask, long val)
    {
        var binary = ToBinary(val).ToCharArray();
        var mask = bitmask.ToCharArray();
        for (var i = 0; i < binary.Length; i++)
        {
            var maskChar = mask[i];

            if (maskChar != 'X')
                binary[i] = maskChar;
        }

        return Convert.ToInt64(new string(binary.ToArray()), 2);
    }

    private static List<long> ApplyBitmaskPart2(string bitmask, long address)
    {
        var addresses = new List<string> { "" };
        var binary = ToBinary(address);
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

                addresses = [.. addresses, .. newAddresses];
            }
        }

        return [.. addresses.Select(o => Convert.ToInt64(o, 2))];
    }
    
    private static string ParseMask(string row) => row.Split(" = ")[1];

    private static (int, long) ParseMem(string row)
    {
        var (pos, val) = Numbers.DigitsFromString(row);
        return (int.Parse(pos), long.Parse(val));
    }
    
    private static string ToBinary(long address, int minLength = 36) => Conversion.ToBinary(address).PadLeft(minLength, '0');
}