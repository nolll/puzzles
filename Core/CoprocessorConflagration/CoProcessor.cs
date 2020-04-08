using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Core.Tools;

namespace Core.CoprocessorConflagration
{
    public class OptimizedCoProcessor
    {
        private int _h;

        public int RegisterH => _h;
        
        public void Run(int a = 0)
        {
            var b = 0;
            var c = 0;
            var d = 0;
            var e = 0;
            var f = 0;
            var g = 0;
            _h = 0;

            b = 67; // 0 set b 67
            c = b; // 1 set c b

            if (a != 0) // 2 jnz a 2
            {
                b = b * 100; // 4
                b = b - -100_000; // 5
                c = b; // 6
                c = c - -17_000; // 7
            }

            while (true)
            {
                while (g != 0) // 23 jnz g -13
                {
                    f = 1; // 8
                    d = 2; // 9
                    e = 2; // 10
                    while (g != 0) // 19
                    {
                        g = d; // 11
                        g = g * e; // 12
                        g = g - b; // 13
                        if (g != 0) // 14
                        {
                            f = 0; // 15
                        }

                        e = e - -1; // 16
                        g = e; // 17
                        g = g - b; // 18

                        Console.WriteLine(g);
                    }

                    d = d - -1; // 20
                    g = d; // 21
                    g = g - b; // 22
                }

                if (f != 0) // 24 jnz f 2
                {
                    _h = _h - -1;
                }

                g = b; // 26
                g = g - c; // 27

                if (g == 0)
                    break;

                b = b - -17;
            }
        }

        /*
 0 set b 67
 1 set c b
 2 jnz a 2
 3 jnz 1 5
 4 mul b 100
 5 sub b -100000
 6 set c b
 7 sub c -17000
 8 set f 1
 9 set d 2
10 set e 2
11 set g d
12 mul g e
13 sub g b
14 jnz g 2
15 set f 0
16 sub e -1
17 set g e
18 sub g b
19 jnz g -8
20 sub d -1
21 set g d
22 sub g b
23 jnz g -13
24 jnz f 2
25 sub h -1
26 set g b
27 sub g c
28 jnz g 2
29 jnz 1 3
30 sub b -17
31 jnz 1 -23
         */
    }

    public class CoProcessor
    {
        private readonly IList<string> _operations;
        private readonly IDictionary<string, long> _registers;
        private long _currentOperation;
        private bool _isPrinterEnabled;

        private bool IsRunning => _currentOperation < _operations.Count && _currentOperation >= 0;
        public int MulCount { get; private set; }
        public long RegisterH => _registers["h"];

        public CoProcessor(string input, long registerA = 0)
            : this(PuzzleInputReader.Read(input), registerA)
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