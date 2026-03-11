using Pzl.Common;
using Pzl.Tools.Lists;
using Pzl.Tools.Strings;
using Pzl.Tools.Numbers;

namespace Pzl.FlipFlop.Puzzles.FlipFlop2025.FlipFlop202503;

[Name("Bush Salesman")]
public class FlipFlop202503 : FlipFlopPuzzle
{
    [Puzzle("97a59e8e51b506fc2e1640cd479042d1")]
    public string Part1(string input)
    {
        var counts = new Dictionary<string, int>();
        foreach (var line in input.Split(LineBreaks.Single))
        {
            if (!counts.TryAdd(line, 1)) 
                counts[line]++;
        }

        return counts.MaxBy(o => o.Value).Key;
    }

    [Puzzle("f7c0b43b9ccea17bd677b165584ea494")]
    public int Part2(string input) => input.Split(LineBreaks.Single).Select(GetColor).Count(o => o.Name == "green");

    [Puzzle("9b4c07da2c7aed1de44933ed08388508")]
    public int Part3(string input) => input.Split(LineBreaks.Single).Select(GetColor).Sum(o => o.Price);

    private static Color GetColor(string line)
    {
        var (r, g, b) = Numbers.IntsFromString(line);
        if (r == g || r == b || g == b)
            return new Color("special", 10);
        if (r > g && r > b)
            return new Color("red", 5);
        if (g > r && g > b)
            return new Color("green", 2);
        if (b > r && b > g)
            return new Color("blue", 4);
        return new Color("unknown", 0);
    }

    private record Color(string Name, int Price);
}