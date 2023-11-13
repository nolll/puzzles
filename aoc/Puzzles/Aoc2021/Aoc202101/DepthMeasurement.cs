using Puzzles.common.Strings;

namespace Puzzles.aoc.Puzzles.Aoc2021.Aoc202101;

public class DepthMeasurement
{
    public int GetNumberOfIncreasingMeasurements(string input, bool useSlidingWindow)
    {
        var depths = PuzzleInputReader.ReadLines(input).Select(int.Parse).ToList();

        var count = 0;
        var prev = 0;
        var start = useSlidingWindow ? 3 : 1;
            
        for (var i = start; i < depths.Count; i++)
        {
            var current = useSlidingWindow
                ? depths[i - 2] + depths[i - 1] + depths[i]
                : depths[i];

            if (current > prev)
                count++;

            prev = current;
        }

        return count;
    }
}