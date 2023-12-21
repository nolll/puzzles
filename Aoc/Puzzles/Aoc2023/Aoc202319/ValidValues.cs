namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202319;

public class ValidValues
{
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

    private static List<int> FillRange() => Enumerable.Range(1, 4000 - 1).ToList();
}