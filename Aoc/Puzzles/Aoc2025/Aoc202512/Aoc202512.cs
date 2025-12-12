using Printmaster;
using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2025.Aoc202512;

[Name("Christmas Tree Farm")]
public class Aoc202512 : AocPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var parts = input.Split(LineBreaks.Double);
        var presentsStrings = parts.SkipLast(1);
        var presents = new List<int>();
        foreach (var s in presentsStrings)
        {
            presents.Add(s.Count(o => o == '#'));
        }
        
        var regions = parts.Last().Split(LineBreaks.Single);
        var possible = 0;
        var impossible = 0;
        var uncertain = 0;
        foreach (var region in regions)
        {
            var regionParts = region.Split();
            var (width, height) = regionParts.First().TrimEnd(':').Split('x').Select(int.Parse).ToArray();
            var numh = width / 3;
            var numv = height / 3;
            var availableSlots = numh * numv;
            var availableSize = width * height;
            var counts = regionParts.Skip(1).Select(int.Parse).ToArray();
            var requiredSize = 0;
            var presentCount = 0;
            for (var i = 0; i < counts.Length; i++)
            {
                requiredSize += counts[i] * presents[i];
                presentCount += counts[i];
            }

            if (availableSlots >= presentCount)
                possible++;
            
            if (requiredSize > availableSize)
                impossible++;

            uncertain = regions.Length - impossible - possible;
        }

        return uncertain == 0 
            ? new PuzzleResult(possible, "18ccf03875ad98259b4de347203fb45a") 
            : throw new Exception("Can't be solved the easy way");
    }
}