using System.Threading;
using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2017;

[Name("Coprocessor Conflagration")]
public class Aoc201723 : AocPuzzle
{
    [Puzzle("971baa2f7382241fa0fb324cff9c6dd6")]
    public int Part1(string input) => new CoProcessor().Run(input);

    [Puzzle("06b5b0f0cbb8360d70ca859b120e402e")]
    public int Part2(string input) => new OptimizedCoProcessor().Run();

    private class CoProcessor
    {
        public int Run(string input)
        {
            var mulCount = 0;
            long currentOperation = 0;
            var operations = input.Split(LineBreaks.Single);
            var registers = new Dictionary<string, long>
            {
                ["a"] = 0
            };
            while (currentOperation < operations.Length && currentOperation >= 0)
            {
                var operation = operations[(int)currentOperation];
                var parts = operation.Split(' ');
                var command = parts[0];
                var part1 = parts[1];
                var val1IsNumeric = long.TryParse(part1, out var val1);
                val1 = !val1IsNumeric && registers.TryGetValue(part1, out var part1Value) ? part1Value : val1;
                long operationIncrement = 1;

                var part2 = parts.Length > 2 ? parts[2] : null;
                long val2 = 0;
                var val2IsNumeric = part2 != null && long.TryParse(part2, out val2);
                val2 = !val2IsNumeric && part2 != null && registers.TryGetValue(part2, out var part2Value) ? part2Value : val2;

                if (command == "set")
                {
                    registers[part1] = val2;
                }
                else if (command == "add")
                {
                    registers.TryGetValue(part1, out var oldVal);
                    registers[part1] = oldVal + val2;
                }
                else if (command == "sub")
                {
                    registers.TryGetValue(part1, out var oldVal);
                    registers[part1] = oldVal - val2;
                }
                else if (command == "mul")
                {
                    mulCount++;
                    registers.TryGetValue(part1, out var oldVal);
                    registers[part1] = oldVal * val2;
                }
                else if (command == "mod")
                {
                    registers.TryGetValue(part1, out var oldVal);
                    registers[part1] = oldVal % val2;
                }
                else if (command == "jgz")
                {
                    if (val1 > 0)
                    {
                        operationIncrement = val2;
                    }
                }
                else if (command == "jnz")
                {
                    if (val1 != 0)
                    {
                        operationIncrement = val2;
                    }
                }

                currentOperation += operationIncrement;
            }

            return mulCount;
        }
    }

    private class OptimizedCoProcessor
    {
        private int _b;
        private int _c;
        private int _d;
        private int _f;

        public int Run()
        {
            var h = 0;
            _b = _c = 67 * 100 + 100000;
            _c = _b + 17000;

            while (true)
            {
                _f = 1;
                _d = 2;
                do
                {
                    if (_b % _d == 0)
                        _f = 0;
                    _d++;
                } while (_d != _b);
                if(_f == 0)
                    h++;
                if (_b == _c)
                    break;
                _b += 17;
            }

            return h;
        }
    }
}