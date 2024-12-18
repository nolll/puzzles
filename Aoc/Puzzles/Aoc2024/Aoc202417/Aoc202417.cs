using Pzl.Common;
using Pzl.Tools.Maths;
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
        var mem = new Dictionary<char, long>
        {
            ['a'] = a,
            ['b'] = b,
            ['c'] = c
        };
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
            else if (instr == 6) // bdv
            {
                var comb = GetComboValue(mem, op);
                mem['b'] = (long)Math.Floor(mem['a'] / Math.Pow(2, comb));
            }
            else if (instr == 7) // cdv
            {
                var comb = GetComboValue(mem, op);
                mem['c'] = (long)Math.Floor(mem['a'] / Math.Pow(2, comb));
            }
            
            i += 2;
        }

        return output.ToArray();
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
    
    private long GetComboValue(long a, long b, long c, long op) =>
        op switch
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

    private long? Find(int[] program) => Find(program, program, 0);

    // Thanks HyperNeutrino!
    private long? Find(int[]program, int[] target, long ans)
    {
        if (target.Length == 0)
            return ans;

        for (uint t = 0; t < 8; t++)
        {
            var a = ans << 3 | t; // don't really understand why we do this here instead of in adv (instr = 0)
            long b = 0;
            long c = 0;
            long? output = null;
            var adv3 = false;
            
            for (var i = 0; i < program.Length - 2; i += 2)
            {
                var instr = program[i];
                var op = program[i + 1];

                if (instr == 0) // adv
                {
                    if (adv3)
                        throw new Exception("Multiple adv3");
                    if (op != 3)
                        throw new Exception("Program has adv with op other than 3");
                    adv3 = true;
                }
                else if (instr == 1) // bxl
                {
                    b ^= op;
                }
                else if (instr == 2) // bst
                {
                    var comb = GetComboValue(a, b, c, op);
                    b = comb % 8;
                }
                else if (instr == 3) // jnz
                {
                    throw new Exception("Program has jump in loop");
                }
                else if (instr == 4) // bxc
                {
                    b ^= c;
                }
                else if (instr == 5) // out
                {
                    if (output is not null)
                        throw new Exception("Multiple outputs in program");
                    var comb = GetComboValue(a, b, c, op);
                    output = comb % 8;
                }
                else if (instr == 6) // bdv
                {
                    var comb = GetComboValue(a, b, c, op);
                    b = (long)Math.Floor(a / Math.Pow(2, comb));
                }
                else if (instr == 7) // cdv
                {
                    var comb = GetComboValue(a, b, c, op);
                    c = (long)Math.Floor(a / Math.Pow(2, comb));
                }

                if (output == target.Last())
                {
                    var sub = Find(program, target.SkipLast(1).ToArray(), a);
                    if(sub is null)
                        continue;

                    return sub;
                }
            }
        }

        return null;
    }
}
