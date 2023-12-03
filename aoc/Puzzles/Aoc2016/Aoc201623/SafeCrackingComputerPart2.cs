using Puzzles.Common.Strings;

namespace Puzzles.Aoc.Puzzles.Aoc2016.Aoc201623;

public class SafeCrackingComputerPart2
{
    private readonly Dictionary<char, int> _registers;
    private int _index;
    private readonly AssembunnyInstruction[] _instructions;

    public int ValueA => _registers['a'];

    public SafeCrackingComputerPart2(string input, int a, int c)
    {
        _instructions = StringReader.ReadLines(input).Select(o => new AssembunnyInstruction(o)).ToArray();
        _registers = new Dictionary<char, int>
        {
            ['a'] = a,
            ['b'] = 0,
            ['c'] = c,
            ['d'] = 0
        };
        _index = 0;

        while (_index < _instructions.Length)
        {
            var s = _instructions[_index];
            var command = s.Name;
            try
            {
                if (command == "cpy")
                {
                    var value = s.Args[0];
                    var target = s.Args[1].First();
                    if (int.TryParse(value, out var num))
                    {
                        _registers[target] = num;
                    }
                    else
                    {
                        var v = value.First();
                        // Never got this optimization right, so the solution took 10 minutes
                        //if (target == 'd' && v == 'a')
                        //{
                        //    while (_registers['b'] > 0)
                        //    {
                        //        var r = _registers['a'] * _registers['b'];
                        //        _registers['b']--;
                        //        _registers['a'] = r;
                        //        _registers['d'] = r;
                        //    }
                        //}
                        //else
                        //{
                        _registers[target] = _registers[value.First()];
                        //}
                    }

                    IncrementIndex();
                }

                else if (command == "inc")
                {
                    var target = s.Args[0].First();
                    _registers[target]++;
                    IncrementIndex();
                }

                else if (command == "dec")
                {
                    var target = s.Args[0].First();
                    _registers[target]--;
                    IncrementIndex();
                }

                else if (command == "jnz")
                {
                    var value = s.Args[0];
                    var isInt = int.TryParse(s.Args[1], out var steps);
                    steps = isInt ? steps : _registers[s.Args[1].First()];

                    if (int.TryParse(value, out var num))
                    {
                        IncrementIndex(num != 0 ? steps : 1);
                    }
                    else
                    {
                        IncrementIndex(_registers[value.First()] != 0 ? steps : 1);
                    }
                }

                else if (command == "tgl")
                {
                    var target = s.Args[0].First();
                    var val = _registers[target];
                    var indexToToggle = _index + val;
                    if (indexToToggle >= 0 && indexToToggle < _instructions.Length)
                    {
                        var instructionToToggle = _instructions[indexToToggle];
                        var name = instructionToToggle.Name;
                        if (instructionToToggle.Args.Count == 1)
                        {
                            if (name == "inc")
                                instructionToToggle.Name = "dec";
                            else
                                instructionToToggle.Name = "inc";
                        }
                        else
                        {
                            if (name == "jnz")
                                instructionToToggle.Name = "cpy";
                            else
                                instructionToToggle.Name = "jnz";
                        }
                    }

                    IncrementIndex();
                }

                //Console.WriteLine($"a: {_registers['a']}, b: {_registers['b']}, c: {_registers['c']}, d: {_registers['d']}");
                //if (_index == 3)
                //{
                //    Console.WriteLine($"{_index}. {s}");
                //    Console.WriteLine($"a: {_registers['a']}, b: {_registers['b']}, c: {_registers['c']}, d: {_registers['d']}");
                //    Console.WriteLine();
                //    Thread.Sleep(500);
                //}
            }
            catch
            {
                IncrementIndex();
            }
        }
    }

    private void IncrementIndex(int steps = 1)
    {
        _index += steps;
    }
}