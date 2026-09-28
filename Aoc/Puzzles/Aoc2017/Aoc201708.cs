using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2017;

[Name("I Heard You Like Registers")]
public class Aoc201708 : AocPuzzle
{
    [Puzzle("3c0ff36b6914cd6851601f65f68e9637")]
    public int Part1(string input) => new CpuInstructionCalculator(input).LargestValueAtEnd;

    [Puzzle("e2ede6d54359a751cf2c2bdae941840b")]
    public int Part2(string input) => new CpuInstructionCalculator(input).LargestValueEver;
    
    public class CpuInstructionCalculator
    {
        private readonly Dictionary<string, int> _registers;
        public int LargestValueAtEnd { get; }
        public int LargestValueEver { get; }

        public CpuInstructionCalculator(string input)
        {
            _registers = new Dictionary<string, int>();
            var instructions = input.Split(LineBreaks.Single);
            
            foreach (var instruction in instructions)
            {
                var parts = instruction.Split(' ');
                var targetRegister = parts[0];
                var change = parts[1] == "inc" ? 1 : -1;
                var value = int.Parse(parts[2]);
                var readRegister = parts[4];
                var condition = parts[5];
                var compareValue = int.Parse(parts[6]);
                
                var currentValue = ReadValue(targetRegister);
                var targetValue = currentValue + change * value;
                
                if(IsConditionTrue(ReadValue(readRegister), condition, compareValue))
                    _registers[targetRegister] = targetValue;

                var largestValue = _registers.Values.Max();
                if (largestValue > LargestValueEver)
                    LargestValueEver = largestValue;
            }

            LargestValueAtEnd = _registers.Values.Max();
        }

        private int ReadValue(string key)
        {
            _registers.TryAdd(key, 0);
            return _registers[key];
        }

        private static bool IsConditionTrue(int a, string condition, int b) => condition switch
        {
            ">" => a > b,
            "<" => a < b,
            ">=" => a >= b,
            "<=" => a <= b,
            "==" => a == b,
            "!=" => a != b,
            _ => false
        };
    }
}