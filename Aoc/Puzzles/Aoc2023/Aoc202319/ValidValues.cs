namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202319;

public class ValidValues
{
    private const int RangeStart = 1;
    private const int RangeEnd = 4000;

    public Dictionary<string, List<int>> Ranges { get; }

    public ValidValues()
    {
        Ranges = new Dictionary<string, List<int>>
        {
            { "x", FillRange() },
            { "m", FillRange() },
            { "a", FillRange() },
            { "s", FillRange() }
        };
    }

    public ValidValues(ValidValues validValues)
    {
        Ranges = new Dictionary<string, List<int>>
        {
            { "x", validValues.Ranges["x"].ToList() },
            { "m", validValues.Ranges["m"].ToList() },
            { "a", validValues.Ranges["a"].ToList() },
            { "s", validValues.Ranges["s"].ToList() }
        };
    }

    public long Count => Ranges.Values.Select(o => o.Count).Aggregate(1L, (a, b) => a * b);

    private static List<int> FillRange() => Enumerable.Range(RangeStart, RangeEnd).ToList();
}