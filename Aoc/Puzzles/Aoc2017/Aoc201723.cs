using System.Threading;
using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2017;

[Name("Coprocessor Conflagration")]
public class Aoc201723 : AocPuzzle
{
    [Puzzle("971baa2f7382241fa0fb324cff9c6dd6")]
    public int Part1(string input)
    {
        var processor = new CoProcessor(input);
        processor.Run();
        return processor.MulCount;
    }

    [Puzzle("06b5b0f0cbb8360d70ca859b120e402e")]
    public int Part2(string input)
    {
        var processor = new OptimizedCoProcessor();
        processor.Run();
        return processor.H;
    }

    public class CoProcessor
    {
        private readonly IList<string> _operations;
        private readonly IDictionary<string, long> _registers;
        private long _currentOperation;
        private readonly bool _isPrinterEnabled;

        private bool IsRunning => _currentOperation < _operations.Count && _currentOperation >= 0;
        public int MulCount { get; private set; }

        public CoProcessor(string input, long registerA = 0)
            : this(input.Split(LineBreaks.Single), registerA)
        {
        }

        private CoProcessor(IList<string> operations, long registerA = 0)
        {
            _operations = operations;
            _registers = new Dictionary<string, long>();
            _registers["a"] = registerA;
            _isPrinterEnabled = registerA != 0;
        }

        public void Run()
        {
            while (IsRunning)
            {
                var operation = _operations[(int)_currentOperation];
                var parts = operation.Split(' ');
                var command = parts[0];
                var part1 = parts[1];
                var val1IsNumeric = long.TryParse(part1, out var val1);
                val1 = !val1IsNumeric && _registers.TryGetValue(part1, out var part1Value) ? part1Value : val1;
                long operationIncrement = 1;

                var part2 = parts.Length > 2 ? parts[2] : null;
                long val2 = 0;
                var val2IsNumeric = part2 != null && long.TryParse(part2, out val2);
                val2 = !val2IsNumeric && part2 != null && _registers.TryGetValue(part2, out var part2Value) ? part2Value : val2;

                if (command == "set")
                {
                    _registers[part1] = val2;
                }
                else if (command == "add")
                {
                    _registers.TryGetValue(part1, out var oldVal);
                    _registers[part1] = oldVal + val2;
                }
                else if (command == "sub")
                {
                    _registers.TryGetValue(part1, out var oldVal);
                    _registers[part1] = oldVal - val2;
                }
                else if (command == "mul")
                {
                    MulCount++;
                    _registers.TryGetValue(part1, out var oldVal);
                    _registers[part1] = oldVal * val2;
                }
                else if (command == "mod")
                {
                    _registers.TryGetValue(part1, out var oldVal);
                    _registers[part1] = oldVal % val2;
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

                if (_isPrinterEnabled)
                {
                    Console.WriteLine(operation);
                    PrintRegisters();
                    Console.WriteLine();
                    Thread.Sleep(500);
                }

                _currentOperation += operationIncrement;
            }
        }

        private void PrintRegisters()
        {
            var r = string.Join(", ", _registers.Keys.Select(key => $"{key}: {_registers[key]}"));
            Console.WriteLine($"{_currentOperation}. {r}");
        }
    }
    
    public class OptimizedCoProcessor
    {
        private int _b;
        private int _c;
        private int _d;
        private int _f;

        public int H { get; private set; }

        public void Run()
        {
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
                    H++;
                if (_b == _c)
                    break;
                _b += 17;
            }
        }
    }
}