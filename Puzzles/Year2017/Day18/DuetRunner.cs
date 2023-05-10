using System.Collections.Generic;
using System.Linq;
using Aoc.Common.Strings;

namespace Aoc.Puzzles.Year2017.Day18;

public class DuetRunner
{
    private readonly IList<string> _operations;
    private readonly List<List<long>> _queues;

    public int Program1SendCount { get; private set; }

    public DuetRunner(string input)
    {
        _operations = PuzzleInputReader.ReadLines(input);
        _queues = new List<List<long>>
        {
            new List<long>(),
            new List<long>()
        };
    }

    public void Run()
    {
        var program0 = new DuetProgramPart2(0, AddToQueue, GetFromQueue, _operations);
        var program1 = new DuetProgramPart2(1, AddToQueue, GetFromQueue, _operations);
        while (program0.IsRunning || program1.IsRunning)
        {
            program0.ExecuteNextOperation();
            program1.ExecuteNextOperation();

            if (program0.IsWaiting && program1.IsWaiting && !_queues[0].Any() && !_queues[1].Any())
            {
                break;
            }
        }
    }

    private long? GetFromQueue(int id)
    {
        var otherId = id == 1 ? 0 : 1;
        var queue = _queues[otherId];
        if (queue.Any())
        {
            var value = queue.First();
            queue.RemoveAt(0);
            return value;
        }
        return null;
    }

    private void AddToQueue(int id, long value)
    {
        if (id == 1)
            Program1SendCount++;
        _queues[id].Add(value);
    }
}