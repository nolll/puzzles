using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Everybody.Puzzles.Everybody09;

[Name("")]
public class Everybody09 : EverybodyPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var balls = ParseBalls(input);
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

        var result = beetleCounts.Sum();
        
        return new PuzzleResult(result, "dffa64bee7ea0c0ad66724de7afe7c08");
    }

    public PuzzleResult RunPart2(string input)
    {
        var balls = ParseBalls(input);
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
        
        var result = results.Sum(o => o.Item2.Count);
        
        return new PuzzleResult(result, "6032109447891782512325cb9251f9e2");
    }
    
    public PuzzleResult RunPart3(string input)
    {
        var seen = new Dictionary<int, List<int>>();
        List<int> stamps = [1, 3, 5, 10, 15, 16, 20, 24, 25, 30, 37, 38, 49, 50, 74, 75, 100, 101];
        var orderedStamps = stamps.OrderDescending().ToList();
        var combinedSums = input.Split(LineBreaks.Single).Select(int.Parse);
        var total = 0;
        foreach (var sum in combinedSums)
        {
            var mid = sum / 2;
            var min = mid - 100;
            var max = mid + 100;
            var minCount = int.MaxValue;
            for (var i = min; i <= max; i++)
            {
                var a = i;
                var b = sum - i;
                if (!seen.TryGetValue(a, out var s1))
                {
                    s1 = SolveBall(a, orderedStamps);
                    seen.Add(a, s1);
                }
                
                if (!seen.TryGetValue(b, out var s2))
                {
                    s2 = SolveBall(b, orderedStamps);
                    seen.Add(b, s2);
                }
                
                if (Math.Abs(s1.Sum() - s2.Sum()) <= 100)
                {
                    var count = s1.Count + s2.Count;
                    minCount = Math.Min(minCount, count);
                }
            }
            
            Console.WriteLine(minCount);

            total += minCount;
        }

        return new PuzzleResult(total);
    }
    
    private static List<int> SolveBall(int ball, List<int> stamps)
    {
        List<int> combinations = [];
        var stampSum = stamps.Sum();
        var largestStamp = stamps.First();

        while (ball > stampSum)
        {
            ball -= largestStamp;
            combinations.Add(largestStamp);
        }
        
        var shortestCombination = new ShortestCombination();
        var solutions = GetCombinations(stamps, ball, combinations, shortestCombination).OrderBy(o => o.Count);
        return solutions.First();
    }

    private static int[] ParseBalls(string input) => 
        input.Split(LineBreaks.Single).Select(int.Parse).ToArray();

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