using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Everybody.Puzzles.Everybody09;

[Name("")]
public class Everybody09(string[] inputs) : EverybodyPuzzle
{
    protected override PuzzleResult RunPart1()
    {
        var result = Part1(inputs[0]);
        return new PuzzleResult(result, "dffa64bee7ea0c0ad66724de7afe7c08");
    }

    protected override PuzzleResult RunPart2()
    {
        return PuzzleResult.Empty;
    }

    protected override PuzzleResult RunPart3()
    {
        return PuzzleResult.Empty;
    }
    
    public static int Part1(string input)
    {
        var balls = input.Split(LineBreaks.Single).Select(int.Parse).ToArray();
        int[] stamps = [1, 3, 5, 10];
        var beetleCounts = new List<int>();
        
        foreach (var ball in balls)
        {
            var sum = 0;
            var i = stamps.Length - 1;
            var beetleCount = 0;
            while (sum < ball)
            {
                var test = sum + stamps[i];
                if (test == ball)
                {
                    beetleCount++;
                    sum += stamps[i];
                    break;
                }

                if (test > ball)
                {
                    i--;
                    continue;
                }

                beetleCount++;
                sum += stamps[i];
            }
            
            beetleCounts.Add(beetleCount);
        }

        return beetleCounts.Sum();
    }
}