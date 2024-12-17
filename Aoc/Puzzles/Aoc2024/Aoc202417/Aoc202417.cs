using Pzl.Common;
using Pzl.Tools.Numbers;

namespace Pzl.Aoc.Puzzles.Aoc2024.Aoc202417;

[Name("Chronospatial Computer")]
public class Aoc202417 : AocPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var nums = Numbers.IntsFromString(input);
        var mem = new Dictionary<char, long>
        {
            ['a'] = nums[0],
            ['b'] = nums[1],
            ['c'] = nums[2]
        };
        var program = nums.Skip(3).ToArray();
        var output = new List<long>();

        var i = 0;
        while (i >= 0 && i < program.Length)
        {
            var instr = program[i];
            var op = program[i + 1];

            if (instr == 0) // adv
            {
                var comb = GetComboValue(mem, op);
                mem['a'] = (long)Math.Floor(mem['a'] / Math.Pow(2, comb));
            }
            else if (instr == 1) // bxl
            {
                mem['b'] ^= op;
            }
            else if (instr == 2) // bst
            {
                var comb = GetComboValue(mem, op);
                mem['b'] = comb % 8;
            }
            else if (instr == 3) // jnz
            {
                if (mem['a'] != 0)
                {
                    i = op;
                    continue;
                }
            }
            else if (instr == 4) // bxc
            {
                mem['b'] ^= mem['c'];
            }
            else if (instr == 5) // out
            {
                var comb = GetComboValue(mem, op);
                output.Add(comb % 8);
            }
            if (instr == 6) // bdv
            {
                var comb = GetComboValue(mem, op);
                mem['b'] = (long)Math.Floor(mem['a'] / Math.Pow(2, comb));
            }
            if (instr == 7) // cdv
            {
                var comb = GetComboValue(mem, op);
                mem['c'] = (long)Math.Floor(mem['a'] / Math.Pow(2, comb));
            }
            
            i += 2;
        }

        var res = string.Join(",", output);
        
        return new PuzzleResult(res);
    }

    private long GetComboValue(Dictionary<char, long> mem, long op) =>
        op switch
        {
            < 4 => op,
            4 => mem['a'],
            5 => mem['b'],
            6 => mem['c'],
            _ => throw new Exception("Invalid combo operator")
        };

    public PuzzleResult Part2(string input)
    {
        return new PuzzleResult(0);
    }
}