using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2017;

[Name("Duet")]
public class Aoc201718 : AocPuzzle
{
    [Puzzle("83f5054894620fa4e35d5a042e71f9a0")]
    public long Part1(string input)
    {
        var single = new SingleRunner(input);
        single.Run();
        return single.RecoveredFrequency;
    }

    [Puzzle("5bfcd9b6e8755474ab31f818b763418e")]
    public int Part2(string input)
    {
        var duet = new DuetRunner(input);
        duet.Run();
        return duet.Program1SendCount;
    }
    
    public class SingleRunner(string input)
    {
        private readonly IList<string> _operations = input.Split(LineBreaks.Single);

        public long RecoveredFrequency { get; private set; }

        public void Run()
        {
            var program = new DuetProgramPart1(_operations);
            RecoveredFrequency = program.FindFrequency();
        }
    }
    
    public class DuetRunner(string input)
    {
        private readonly IList<string> _operations = input.Split(LineBreaks.Single);
        private readonly List<List<long>> _queues =
        [
            [],
            []
        ];

        public int Program1SendCount { get; private set; }

        public void Run()
        {
            var program0 = new DuetProgramPart2(0, AddToQueue, GetFromQueue, _operations);
            var program1 = new DuetProgramPart2(1, AddToQueue, GetFromQueue, _operations);
            while (program0.IsRunning || program1.IsRunning)
            {
                program0.ExecuteNextOperation();
                program1.ExecuteNextOperation();

                if (program0.IsWaiting && program1.IsWaiting && _queues[0].Count == 0 && _queues[1].Count == 0)
                {
                    break;
                }
            }
        }

        private long? GetFromQueue(int id)
        {
            var otherId = id == 1 ? 0 : 1;
            var queue = _queues[otherId];
            if (queue.Count == 0)
                return null;
        
            var value = queue.First();
            queue.RemoveAt(0);
            return value;
        }

        private void AddToQueue(int id, long value)
        {
            if (id == 1)
                Program1SendCount++;
            _queues[id].Add(value);
        }
    }

    public class DuetProgramPart1
    {
        private readonly IList<string> _operations;
        private readonly IDictionary<string, long> _registers;
        private long _playedSound;
        private long _currentOperation;

        private bool IsRunning => _currentOperation < _operations.Count && _currentOperation >= 0;

        public DuetProgramPart1(IList<string> operations)
        {
            _operations = operations;
            _registers = new Dictionary<string, long>();
        }

        public long FindFrequency()
        {
            while (IsRunning)
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
                    _playedSound = val1;
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
                    if (val1 != 0)
                        return _playedSound;
                }
                else if (command == "jgz")
                {
                    if (val1 > 0)
                    {
                        _currentOperation += val2;
                        continue;
                    }
                }

                _currentOperation++;
            }

            return 0;
        }
    }

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
            _registers = new Dictionary<string, long> { ["p"] = id };
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
}