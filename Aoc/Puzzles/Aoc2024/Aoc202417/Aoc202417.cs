using Pzl.Common;
using Pzl.Tools.Numbers;

namespace Pzl.Aoc.Puzzles.Aoc2024.Aoc202417;

[Name("Chronospatial Computer")]
public class Aoc202417 : AocPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var nums = Numbers.IntsFromString(input);
        var program = nums.Skip(3).ToArray();
        var output = RunProgram(program, nums[0], nums[1], nums[2]);
        var res = string.Join(",", output);
        
        return new PuzzleResult(res, "8ecd8cdd2990f11eb9ae9f0793770018");
    }

    private long[] RunProgram(int[] program, long a, long b, long c)
    {
        var output = new List<long>();

        var i = 0;
        while (i >= 0 && i < program.Length)
        {
            var instr = program[i];
            var op = program[i + 1];

            if (instr == 0) // adv
            {
                a = (long)Math.Floor(a / Math.Pow(2, Combo(a, b, c, op)));
            }
            else if (instr == 1) // bxl
            {
                b ^= op;
            }
            else if (instr == 2) // bst
            {
                b = Combo(a, b, c, op) % 8;
            }
            else if (instr == 3 && a != 0) // jnz
            { 
                i = op;
                continue;
            }
            else if (instr == 4) // bxc
            {
                b ^= c;
            }
            else if (instr == 5) // out
            {
                output.Add(Combo(a, b, c, op) % 8);
            }
            else if (instr == 6) // bdv
            {
                b = (long)Math.Floor(a / Math.Pow(2, Combo(a, b, c, op)));
            }
            else if (instr == 7) // cdv
            {
                c = (long)Math.Floor(a / Math.Pow(2, Combo(a, b, c, op)));
            }
            
            i += 2;
        }

        return output.ToArray();
    }

    private static long Combo(long a, long b, long c, long op) => op switch
    {
        < 4 => op,
        4 => a,
        5 => b,
        6 => c,
        _ => throw new Exception($"Invalid combo operator {op}")
    };
    
    public PuzzleResult Part2(string input)
    {
        var nums = Numbers.IntsFromString(input);
        var program = nums.Skip(3).ToArray();

        var res = Find(program);

        return new PuzzleResult(res, "a8156e51eb5968f253630b3ceb297916");
    }

    private static long? Find(int[] program) => Find(program, program, 0);

    // Thanks HyperNeutrino!
    private static long? Find(int[]program, int[] target, long ans)
    {
        if (target.Length == 0)
            return ans;

        for (uint t = 0; t < 8; t++)
        {
            var a = ans << 3 | t; // don't really understand why we do this here instead of in adv (instr = 0)
            long b = 0;
            long c = 0;
            long? output = null;
            
            for (var i = 0; i < program.Length - 2; i += 2)
            {
                var instr = program[i];
                var op = program[i + 1];

                if (instr == 1) // bxl
                    b ^= op;
                else if (instr == 2) // bst
                    b = Combo(a, b, c, op) % 8;
                else if (instr == 4) // bxc
                    b ^= c;
                else if (instr == 5) // out
                    output = Combo(a, b, c, op) % 8;
                else if (instr == 6) // bdv
                    b = (long)Math.Floor(a / Math.Pow(2, Combo(a, b, c, op)));
                else if (instr == 7) // cdv
                    c = (long)Math.Floor(a / Math.Pow(2, Combo(a, b, c, op)));

                if (output != target.Last())
                    continue;
                
                var sub = Find(program, target.SkipLast(1).ToArray(), a);
                if(sub is null)
                    continue;

                return sub;
            }
        }

        return null;
    }
}
