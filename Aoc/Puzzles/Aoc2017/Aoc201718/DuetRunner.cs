using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201718;

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