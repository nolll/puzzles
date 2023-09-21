using System;
using System.Collections.Generic;

namespace Aoc.Puzzles.Year2017.Day18;

public class DuetProgramPart2
{
    private readonly int _id;
    private readonly Action<int, long> _send;
    private readonly Func<int, long?> _receive;
    private readonly IList<string> _operations;
    private readonly IDictionary<string, long> _registers;
    private long _currentOperation;

    public bool IsRunning => _currentOperation < _operations.Count && _currentOperation >= 0;
    public bool IsWaiting { get; private set; }

    public DuetProgramPart2(int id, Action<int, long> send, Func<int, long?> receive, IList<string> operations)
    {
        _id = id;
        _send = send;
        _receive = receive;
        _operations = operations;
        _registers = new Dictionary<string, long> {["p"] = id};
    }

    public void ExecuteNextOperation()
    {
        var operation = _operations[(int)_currentOperation];
        var parts = operation.Split(' ');
        var command = parts[0];
        var part1 = parts[1];
        var val1IsNumeric = long.TryParse(part1, out var val1);
        val1 = !val1IsNumeric && _registers.ContainsKey(part1) ? _registers[part1] : val1;

        var part2 = parts.Length > 2 ? parts[2] : null;
        long val2 = 0;
        var val2IsNumeric = part2 != null && long.TryParse(part2, out val2);
        val2 = !val2IsNumeric && part2 != null && _registers.ContainsKey(part2) ? _registers[part2] : val2;

        if (command == "snd")
        {
            _send(_id, val1);
        }
        else if (command == "set")
        {
            _registers[part1] = val2;
        }
        else if (command == "add")
        {
            _registers.TryGetValue(part1, out var oldVal);
            _registers[part1] = oldVal + val2;
        }
        else if (command == "mul")
        {
            _registers.TryGetValue(part1, out var oldVal);
            _registers[part1] = oldVal * val2;
        }
        else if (command == "mod")
        {
            _registers.TryGetValue(part1, out var oldVal);
            _registers[part1] = oldVal % val2;
        }
        else if (command == "rcv")
        {
            var value = _receive(_id);
            if (value == null)
            {
                IsWaiting = true;
                return;
            }

            IsWaiting = false;
            _registers[part1] = value.Value;
        }
        else if (command == "jgz")
        {
            if (val1 > 0)
            {
                _currentOperation += val2;
                return;
            }
        }

        _currentOperation++;
    }
}