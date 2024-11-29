using Pzl.Common;
using Pzl.Tools.CoordinateSystems.CoordinateSystem2D;

namespace Pzl.Everybody.Puzzles.Everybody08;

[Name("A Shrine for Nullpointer\n")]
public class Everybody08(string[] inputs) : EverybodyPuzzle
{
    protected override PuzzleResult RunPart1()
    {
        var result = Part1(inputs[0]);
        return new PuzzleResult(result, "5dbd06d4622464e1becf46096ff400a7");
    }

    protected override PuzzleResult RunPart2()
    {
        var result = Part2(inputs[1]);
        return new PuzzleResult(result, "afafe068673279bd495b7ccfc71a0064");
    }

    protected override PuzzleResult RunPart3()
    {
        return PuzzleResult.Empty;
    }

    public static int Part1(string input)
    {
        var availableBlocks = int.Parse(input);
        var level = 1;
        var levels = new List<int> { level };
        
        while (levels.Sum() < availableBlocks)
        {
            level += 2;
            levels.Add(level);
        }
        
        return (levels.Sum() - availableBlocks) * levels.Last();
    }

    public static long Part2(string input, int availableBlocks = 20240000, int acolyteCount = 1111)
    {
        var priestCount = int.Parse(input);
        var thickness = 1;
        var levels = new List<long> { thickness };
        
        while (levels.Sum() < availableBlocks)
        {
            thickness = thickness * priestCount % acolyteCount;
            levels.Insert(0, 0);
            levels.Add(0);
            for (var i = 0; i < levels.Count; i++)
            {
                levels[i] += thickness;
            }
        }

        var sum = levels.Sum();
        return (sum - availableBlocks) * levels.Count;
    }
}