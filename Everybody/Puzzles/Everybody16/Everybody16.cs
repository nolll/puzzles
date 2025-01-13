using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Everybody.Puzzles.Everybody16;

[Name("Cat Grin of Fortune")]
public class Everybody16 : EverybodyPuzzle
{
    private readonly int[] _diffs = [-1, 0, 1];

    public PuzzleResult Part1(string input)
    {
        var (increments, wheels) = Parse(input);
        var cats = wheels.Select((wheel, i) => wheel[100 * increments[i] % wheel.Length]).ToList();
        var result = string.Join(" ", cats);
        
        return new PuzzleResult(result, "1a56d927da3da48fad02fb78b95a91cb");
    }

    public PuzzleResult Part2(string input)
    {
        var score = Part2(input, 202420242024);
        
        return new PuzzleResult(score, "8ba1d5c403e6bf5c0aad202e81e5e515");
    }
    
    public PuzzleResult Part3(string input)
    {
        var (min, max) = Part3(input, 256);
        
        return new PuzzleResult($"{max} {min}", "912149637877bbdd3f19be24133372ed");
    }
    
    public long Part2(string input, long target)
    {
        var (increments, wheels) = Parse(input);
        var seen = new HashSet<string>();
        var count = 0L;
        var score = 0L;
        var skipped = false;
        while (count < target)
        {
            count++;
            var cats = new List<string>();
            var indices = new List<int>();
            for (var i = 0; i < wheels.Length; i++)
            {
                var wheel = wheels[i];
                var index = (int)(count * increments[i] % wheel.Length);
                var cat = wheel[index];
                cats.Add(cat);
                indices.Add(index);
            }

            var key = GetCatId(indices);
            var currentScore = Score(cats); 
            
            if (!skipped && seen.Contains(key))
            {
                skipped = true;
                var loopLength = seen.Count;
                var skip = target / loopLength;
                score = skip * score - currentScore;
                count = skip * loopLength;
            }

            score += currentScore;
            
            seen.Add(key);
        }

        return score;
    }
    
    public (long min, long max) Part3(string input, int pullCount)
    {
        var (increments, wheels) = Parse(input);
        
        var counts = wheels.Select(o => o.Length).ToArray();
        var mincache = new Dictionary<(string, int), int>();
        var maxcache = new Dictionary<(string, int), int>();
        var pos = wheels.Select(_ => 0).ToArray();
        
        var min = FindBest(wheels, counts, increments, pos, pullCount, mincache, FindMode.Min);
        var max = FindBest(wheels, counts, increments, pos, pullCount, maxcache, FindMode.Max);

        return (min, max);
    }

    private string GetCatId(IEnumerable<int> a) => string.Join(",", a);

    private int FindBest(
        string[][] wheels,
        int[] counts,
        int[] increments,
        int[] state,
        int pullsLeft,
        Dictionary<(string, int), int> cache,
        FindMode findMode)
    {
        if (pullsLeft == 0)
            return 0;

        var key = (GetCatId(state), pullsLeft);
        if (cache.ContainsKey(key))
            return cache[key];

        var best = findMode == FindMode.Min ? int.MaxValue : int.MinValue;
        var newStates = GetNextPositions(counts, increments, state);
        foreach (var newState in newStates)
        {
            var cats = newState.Select((o, index) => wheels[index][o]);
            var score = Score(cats);
            var newScore = score + FindBest(wheels, counts, increments, newState, pullsLeft - 1, cache, findMode);
            best = findMode == FindMode.Min ? Math.Min(best, newScore) : Math.Max(best, newScore);
        }

        cache[key] = best;
        
        return best;
    }

    public List<int[]> GetNextPositions(int[] counts, int[] increments, int[] positions)
    {
        var nextPositions = new List<int[]>();
        foreach (var diff in _diffs)
        {
            var np = new int[counts.Length];
            for (var i = 0; i < counts.Length; i++)
            {
                np[i] = (positions[i] + diff + increments[i] + counts[i]) % counts[i];
            }
            
            nextPositions.Add(np);
        }

        return nextPositions;
    }

    private static (int[] increments, string[][] wheels) Parse(string input)
    {
        var parts = input.Split(LineBreaks.Double);
        var increments = ParseIncrements(parts[0]);
        var wheels = ParseWheels(parts[1], increments);

        return (increments, wheels);
    }

    private static int[] ParseIncrements(string input) => input.Split(',').Select(int.Parse).ToArray();

    private static string[][] ParseWheels(string input, int[] increments)
    {
        var wheels = new List<List<string>>();
        
        for (var i = 0; i < increments.Length; i++)
        {
            var s = i * 4;
            var wheel = new List<string>();
                
            foreach (var line in input.Split(LineBreaks.Single))
            {
                if (line.Length <= s)
                    break;

                var cat = line.Substring(s, 3);
                if (cat == "   ")
                    break;
                
                wheel.Add(cat);
            }
            
            wheels.Add(wheel);
        }

        return wheels.Select(o => o.ToArray()).ToArray();
    }

    private static int Score(IEnumerable<string> cats) => Score(string.Join("", cats.Select(o => $"{o[0]}{o[2]}")));
    public static int Score(string s) => s.GroupBy(o => o).Select(o => o.Count() - 2).Where(o => o > 0).Sum();

    private enum FindMode
    {
        Min,
        Max
    }
}