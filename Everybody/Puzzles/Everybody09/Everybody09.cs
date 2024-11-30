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
        var result = Part2(inputs[1]);
        return new PuzzleResult(result, "6032109447891782512325cb9251f9e2");
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

    private class ShortestCombination
    {
        public int Length { get; set; } = int.MaxValue;

        public void Report(List<int> combination)
        {
            var count = combination.Count;
            if (count < Length)
                Length = count;
        }
    }
    
    public static int Part2(string input)
    {
        var balls = input.Split(LineBreaks.Single).Select(int.Parse).ToArray();
        int[] stamps = [1, 3, 5, 10, 15, 16, 20, 24, 25, 30];
        var orderedStamps = stamps.OrderDescending().ToList();
        var stampSum = stamps.Sum();
        var results = new List<(int, List<int>)>();
        var largestStamp = orderedStamps.First();
        
        foreach (var ball in balls)
        {
            List<int> combinations = [];
            var b = ball;
            while (b > stampSum)
            {
                b -= largestStamp;
                combinations.Add(largestStamp);
            }
            var shortestCombination = new ShortestCombination();
            var solutions = GetCombinations(orderedStamps, b, combinations, shortestCombination).OrderBy(o => o.Count);
            var shortestSolution = solutions.First();
            results.Add((ball, shortestSolution));
        }
        
        return results.Sum(o => o.Item2.Count);
    }

    
    private static List<List<int>> GetCombinations(
        IReadOnlyCollection<int> denominations, 
        int target, 
        List<int> combination,
        ShortestCombination shortestCombination)
    {
        if (target < 0 || !denominations.Any())
            return [];

        if (target == 0)
        {
            shortestCombination.Report(combination);
            return [combination];
        }

        if (combination.Count > shortestCombination.Length)
            return [];

        var denomination = denominations.First();
        var remainingDenominations = denominations.Skip(1).ToList();

        var returnedCombinations = new List<List<int>>();
        var nextCombination = combination.ToList();
        nextCombination.Add(denomination);
        returnedCombinations.AddRange(GetCombinations(denominations, target - denomination, nextCombination, shortestCombination));
        returnedCombinations.AddRange(GetCombinations(remainingDenominations, target, combination.ToList(), shortestCombination));

        return returnedCombinations;
    }
}