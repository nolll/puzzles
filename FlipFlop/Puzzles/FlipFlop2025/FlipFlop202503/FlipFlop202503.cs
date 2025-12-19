using Pzl.Common;
using Pzl.Tools.Lists;
using Pzl.Tools.Strings;
using Pzl.Tools.Numbers;

namespace Pzl.FlipFlop.Puzzles.FlipFlop2025.FlipFlop202503;

[Name("Bush Salesman")]
public class FlipFlop202503 : FlipFlopPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var lines = input.Split(LineBreaks.Single);
        var counts = new Dictionary<string, int>();
        foreach (var line in lines)
        {
            if (!counts.TryAdd(line, 1)) 
                counts[line]++;
        }

        var best2 = counts.MaxBy(o => o.Value).Key;
        
        return new PuzzleResult(best2, "97a59e8e51b506fc2e1640cd479042d1");
    }

    public PuzzleResult Part2(string input)
    {
        var lines = input.Split(LineBreaks.Single);
        var colors = lines.Select(GetColor);
        var greenCount = colors.Count(o => o.Name == "green");
        
        return new PuzzleResult(greenCount, "f7c0b43b9ccea17bd677b165584ea494");
    }

    public PuzzleResult Part3(string input)
    {
        var lines = input.Split(LineBreaks.Single);
        var colors = lines.Select(GetColor);
        var price = colors.Sum(o => o.Price);
        
        return new PuzzleResult(price, "9b4c07da2c7aed1de44933ed08388508");
    }

    private static Color GetColor(string line)
    {
        var (r, g, b) = Numbers.IntsFromString(line);
        if(r == g || r == b || g == b)
            return new Color("special", 10);
        if(r > g && r > b)
            return new Color("red", 5);
        if(g > r && g > b)
            return new Color("green", 2);
        if(b > r && b > g)
            return new Color("blue", 4);
        return new Color("unknown", 0);
    }

    private record Color(string Name, int Price);
}