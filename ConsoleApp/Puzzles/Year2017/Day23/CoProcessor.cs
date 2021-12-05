using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Core.Tools;

namespace ConsoleApp.Puzzles.Year2017.Day23
{
    public class CoProcessor
    {
        private readonly IList<string> _operations;
        private readonly IDictionary<string, long> _registers;
        private long _currentOperation;
        private readonly bool _isPrinterEnabled;

        private bool IsRunning => _currentOperation < _operations.Count && _currentOperation >= 0;
        public int MulCount { get; private set; }
        public long RegisterH => _registers["h"];

        public CoProcessor(string input, long registerA = 0)
            : this(PuzzleInputReader.ReadLines(input), registerA)
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
                val1 = !val1IsNumeric && _registers.ContainsKey(part1) ? _registers[part1] : val1;
                long operationIncrement = 1;

                var part2 = parts.Length > 2 ? parts[2] : null;
                long val2 = 0;
                var val2IsNumeric = part2 != null && long.TryParse(part2, out val2);
                val2 = !val2IsNumeric && part2 != null && _registers.ContainsKey(part2) ? _registers[part2] : val2;

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
}