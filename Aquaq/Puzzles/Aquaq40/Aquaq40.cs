using Pzl.Common;

namespace Pzl.Aquaq.Puzzles.Aquaq40;

public class Aquaq40 : AquaqPuzzle
{
    public override string Name => "Prominence promenade";

    protected override PuzzleResult Run()
    {
        var sum = GetSum(InputFile);

        return new PuzzleResult(sum, "d0882d4e6f6cf4f90adcda93e5d420bc");
    }

    public static int GetSum(string input)
    {
        var heights = input.Split(' ').Select(int.Parse).ToArray();
        var peakIndices = FindPeakIndices(heights);
        var prominences = new List<int>();

        foreach (var peakIndex in peakIndices)
        {
            var peakHeight = heights[peakIndex];
            var droppedRight = FindProminenceRight(heights, peakIndex, peakHeight);
            var droppedLeft = FindProminenceLeft(heights, peakIndex, peakHeight);
            var foundHigherGround = droppedLeft is not null || droppedRight is not null;

            var prominence = foundHigherGround
                ? Math.Min(droppedRight ?? int.MaxValue, droppedLeft ?? int.MaxValue)
                : heights[peakIndex];

            prominences.Add(prominence);;
        }

        return prominences.Sum();
    }

    private static int? FindProminenceRight(int[] heights, int peakIndex, int peakHeight) 
        => FindProminence(GetRightHeights(heights, peakIndex), peakIndex, peakHeight);

    private static IEnumerable<int> GetRightHeights(IReadOnlyList<int> heights, int peakIndex)
    {
        for (var i = peakIndex + 1; i < heights.Count; i++)
            yield return heights[i];
    }

    private static int? FindProminenceLeft(int[] heights, int peakIndex, int peakHeight)
        => FindProminence(GetLeftHeights(heights, peakIndex), peakIndex, peakHeight);
    
    private static IEnumerable<int> GetLeftHeights(IReadOnlyList<int> heights, int peakIndex)
    {
        for (var i = peakIndex - 1; i >= 0; i--)
            yield return heights[i];
    }

    private static int? FindProminence(IEnumerable<int> heights, int peakIndex, int peakHeight)
    {
        var dropped = 0;
        foreach (var height in heights)
        {
            dropped = Math.Max(dropped, peakHeight - height);
            if (height >= peakHeight)
                return dropped;
        }

        return null;
    }

    public static int[] FindPeakIndices(string input)
    {
        return FindPeakIndices(input.Split(' ').Select(int.Parse).ToArray());
    }

    private static int[] FindPeakIndices(int[] input)
    {
        var result = new List<int>();
        for (var i = 1; i < input.Length - 1; i++)
        {
            var isPeak = input[i] > input[i - 1] && input[i] > input[i + 1];
            if(isPeak)
                result.Add(i);;
        }

        return result.ToArray();
    }
}