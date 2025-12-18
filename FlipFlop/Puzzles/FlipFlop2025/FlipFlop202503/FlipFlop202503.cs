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
        var labels = new List<string>();
        foreach (var line in lines)
        {
            var (r, g, b) = Numbers.IntsFromString(line);
            if(r == g || r == b || g == b)
                labels.Add("special");
            else if(r > g && r > b)
                labels.Add("red");
            else if(g > r && g > b)
                labels.Add("green");
            else if(b > r && b > g)
                labels.Add("blue");
            else
                labels.Add("");
        }

        var greenCount = labels.Count(o => o == "green");
        
        return new PuzzleResult(greenCount, "f7c0b43b9ccea17bd677b165584ea494");
    }

    public PuzzleResult Part3(string input)
    {
        var lines = input.Split(LineBreaks.Single);
        var price = 0; 
        foreach (var line in lines)
        {
            var (r, g, b) = Numbers.IntsFromString(line);
            if (r == g || r == b || g == b)
                price += 10;
            else if (r > g && r > b)
                price += 5;
            else if (g > r && g > b)
                price += 2;
            else if (b > r && b > g)
                price += 4;
        }
        
        return new PuzzleResult(price, "9b4c07da2c7aed1de44933ed08388508");
    }
}