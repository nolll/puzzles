namespace Puzzles.aoc.Puzzles.Aoc2016.Aoc201610;

public class Bot
{
    public int Id { get; }
    public IGiver? LowGiver { get; set; }
    public IGiver? HighGiver { get; set; }
    private readonly IList<int> _values;
    public int Low { get; private set; }
    public int High { get; private set; }

    public bool IsReadyToGive => _values.Count == 2;

    public Bot(int id)
    {
        Id = id;
        _values = new List<int>();
    }

    public void Give()
    {
        Low = _values.Min();
        LowGiver?.Give(Low);
        High = _values.Max();
        HighGiver?.Give(High);
        _values.Clear();
    }

    public void AddValue(int v)
    {
        _values.Add(v);
    }
}