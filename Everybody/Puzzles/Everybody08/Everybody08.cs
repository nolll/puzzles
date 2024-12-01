using Pzl.Common;

namespace Pzl.Everybody.Puzzles.Everybody08;

[Name("A Shrine for Nullpointer")]
public class Everybody08 : EverybodyPuzzle
{
    protected override PuzzleResult RunPart1(string input)
    {
        var result = Part1(input);
        return new PuzzleResult(result, "5dbd06d4622464e1becf46096ff400a7");
    }

    protected override PuzzleResult RunPart2(string input)
    {
        var result = Part2(input);
        return new PuzzleResult(result, "afafe068673279bd495b7ccfc71a0064");
    }

    protected override PuzzleResult RunPart3(string input)
    {
        var result = Part3(input);
        return new PuzzleResult(result);
    }

    public static int Part1(string input)
    {
        var availableBlocks = int.Parse(input);
        var level = 1;
        var cols = new List<int> { level };
        
        while (cols.Sum() < availableBlocks)
        {
            level += 2;
            cols.Add(level);
        }
        
        return (cols.Sum() - availableBlocks) * cols.Last();
    }

    public static long Part2(string input, int availableBlocks = 20240000, int acolyteCount = 1111)
    {
        var priestCount = int.Parse(input);
        var thickness = 1;
        var cols = new List<long> { thickness };
        
        while (cols.Sum() < availableBlocks)
        {
            thickness = thickness * priestCount % acolyteCount;
            cols.Insert(0, 0);
            cols.Add(0);
            for (var i = 0; i < cols.Count; i++)
            {
                cols[i] += thickness;
            }
        }

        var sum = cols.Sum();
        return (sum - availableBlocks) * cols.Count;
    }
    
    public static long Part3(string input, int availableBlocks = 202400000, int acolyteCount = 10)
    {
        var priestCount = int.Parse(input);
        var thickness = 1;
        var cols = new List<long> { thickness };
        var space = 0L;
        var sum = cols.Sum();
        
        while (sum - space < availableBlocks)
        {
            thickness = thickness * priestCount % acolyteCount + acolyteCount;
            cols.Insert(0, 0);
            cols.Add(0);
            for (var i = 0; i < cols.Count; i++)
            {
                cols[i] += thickness;
            }
            
            sum = cols.Sum();
            space = 0;
            for (var i = 1; i < cols.Count - 1; i++)
            {
                var prevHeight = cols[i - 1];
                var nextHeight = cols[i + 1];
                var maxSpace = Math.Min(prevHeight, nextHeight);
                var thisSpace = priestCount * cols.Count * cols[i] % acolyteCount;
                space += Math.Min(maxSpace, thisSpace);
            }
            //space = cols.Skip(1).SkipLast(1).Sum(col => priestCount * cols.Count * col % acolyteCount);
        }
        
        return sum - space - availableBlocks;
    }
}