using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2017;

[Name("Duet")]
[IsFunToOptimize]
[Comment("Part 1 and 2 share a lot of code and can probably be combined")]
public class Aoc201718 : AocPuzzle
{
    [Puzzle("83f5054894620fa4e35d5a042e71f9a0")]
    public long Part1(string input) => RunPart1(input);

    [Puzzle("5bfcd9b6e8755474ab31f818b763418e")]
    public int Part2(string input) => RunPart2(input);

    public long RunPart1(string input)
    {
        var operations = input.Split(LineBreaks.Single);
        var program = new DuetProgramPart1(operations);
        return program.Run();
    }

    public int RunPart2(string input)
    {
        const int programCount = 2;
        var program1SendCount = 0;
        var operations = input.Split(LineBreaks.Single);
        var queues = CreateQueues(programCount).ToArray();
        var programs = CreatePrograms(programCount, AddToQueue, GetFromQueue, operations).ToArray();
        
        while (programs.Any(o => o.IsRunning))
        {
            foreach (var program in programs) 
                program.ExecuteNextOperation();

            if (programs.All(o => o.IsWaiting) && queues.All(o => o.Count == 0))
                break;
        }

        return program1SendCount;

        long? GetFromQueue(int id)
        {
            var otherId = id == 1 ? 0 : 1;
            var queue = queues[otherId];
            if (queue.Count == 0)
                return null;

            return queue.Dequeue();
        }

        void AddToQueue(int id, long value)
        {
            if (id == 1)
                program1SendCount++;
            queues[id].Enqueue(value);
        }
    }

    private static IEnumerable<Queue<long>> CreateQueues(int programCount) => 
        Enumerable.Range(0, programCount)
            .Select(_ => new Queue<long>());
    
    private static IEnumerable<DuetProgramPart2> CreatePrograms(
        int programCount, 
        Action<int, long> send, 
        Func<int, long?> receive, 
        string[] operations) =>
        Enumerable.Range(0, programCount)
            .Select(i => new DuetProgramPart2(i, send, receive, operations));

    private class DuetProgramPart1(IList<string> operations)
    {
        private readonly IDictionary<string, long> _registers = new Dictionary<string, long>();
        private long _playedSound;
        private long _currentOperation;

        private bool IsRunning => _currentOperation < operations.Count && _currentOperation >= 0;

        public long Run()
        {
            while (IsRunning)
            {
                var operation = operations[(int)_currentOperation];
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

    private class DuetProgramPart2(int id, Action<int, long> send, Func<int, long?> receive, string[] operations)
    {
        private readonly IDictionary<string, long> _registers = new Dictionary<string, long> { ["p"] = id };
        private long _currentOperation;

        public bool IsRunning => _currentOperation < operations.Length && _currentOperation >= 0;
        public bool IsWaiting { get; private set; }

        public void ExecuteNextOperation()
        {
            var operation = operations[(int)_currentOperation];
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
                send(id, val1);
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
                var value = receive(id);
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