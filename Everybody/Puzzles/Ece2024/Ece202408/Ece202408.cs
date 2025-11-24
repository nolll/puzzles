using Pzl.Common;

namespace Pzl.Everybody.Puzzles.Ece2024.Ece202408;

[Name("A Shrine for Nullpointer")]
public class Ece202408 : EverybodyEventPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var availableBlocks = int.Parse(input);
        var level = 1;
        var cols = new List<int> { level };
        
        while (cols.Sum() < availableBlocks)
        {
            level += 2;
            cols.Add(level);
        }
        
        var result = (cols.Sum() - availableBlocks) * cols.Last();
        
        return new PuzzleResult(result, "5dbd06d4622464e1becf46096ff400a7");
    }

    public PuzzleResult RunPart2(string input) => new(RunPart2(input, 20240000, 1111), "afafe068673279bd495b7ccfc71a0064");
    public PuzzleResult RunPart3(string input) => new(RunPart3(input, 202400000, 10), "52ce3b750999eebc1512e2d801e327a4");

    public long RunPart2(string input, int availableBlocks, int acolyteCount)
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
    
    public long RunPart3(string input, int availableBlocks, int acolyteCount)
    {
        var priestCount = int.Parse(input);
        var thickness = 1L;
        var cols = new List<long> { thickness };
        var space = 0L;
        var totalSum = thickness;
        
        while (totalSum - space < availableBlocks)
        {
            thickness = thickness * priestCount % acolyteCount + acolyteCount;
            cols.Insert(0, 0);
            cols.Add(0);
            for (var i = 0; i < cols.Count; i++)
            {
                cols[i] += thickness;
                totalSum += thickness;
            }
            
            space = cols.Skip(1).SkipLast(1).Sum(col => col * priestCount * cols.Count % acolyteCount);
        }
        
        return totalSum - space - availableBlocks;
    }
}