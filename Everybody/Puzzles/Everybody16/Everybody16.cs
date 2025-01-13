using Newtonsoft.Json;
using Pzl.Common;
using Pzl.Tools.Maths;
using Pzl.Tools.Strings;

namespace Pzl.Everybody.Puzzles.Everybody16;

[Name("Cat Grin of Fortune")]
public class Everybody16 : EverybodyPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var parts = input.Split(LineBreaks.Double);
        var increments = parts[0].Split(',').Select(int.Parse).ToArray();
        var wheels = new List<List<string>>();
        
        for (var i = 0; i < increments.Length; i++)
        {
            var s = i * 4;
            var wheel = new List<string>();
                
            foreach (var line in parts[1].Split(LineBreaks.Single))
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

        var cats = new List<string>();
        for (var i = 0; i < wheels.Count; i++)
        {
            var wheel = wheels[i];
            var cat = wheel[100 * increments[i] % wheel.Count];
            cats.Add(cat);
        }

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
        var parts = input.Split(LineBreaks.Double);
        var increments = parts[0].Split(',').Select(int.Parse).ToArray();
        var wheels = new List<List<string>>();
        
        for (var i = 0; i < increments.Length; i++)
        {
            var s = i * 4;
            var wheel = new List<string>();
                
            foreach (var line in parts[1].Split(LineBreaks.Single))
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

        var seen = new HashSet<string>();
        var count = 0L;
        var score = 0L;
        var skipped = false;
        while (count < target)
        {
            count++;
            var cats = new List<string>();
            var indices = new List<int>();
            for (var i = 0; i < wheels.Count; i++)
            {
                var wheel = wheels[i];
                var index = (int)(count * increments[i] % wheel.Count);
                var cat = wheel[index];
                cats.Add(cat);
                indices.Add(index);
            }

            var key = string.Join(",", indices);
            var stripped = string.Join("", cats.Select(o => $"{o[0]}{o[2]}"));
            var currentScore = Score(stripped); 
            
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
        var parts = input.Split(LineBreaks.Double);
        var increments = parts[0].Split(',').Select(int.Parse).ToArray();
        var wheels = new List<List<string>>();
        
        for (var i = 0; i < increments.Length; i++)
        {
            var s = i * 4;
            var wheel = new List<string>();
                
            foreach (var line in parts[1].Split(LineBreaks.Single))
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
        
        var counts = wheels.Select(o => o.Count).ToArray();
        var mincache = new Dictionary<(string, int), int>();
        var maxcache = new Dictionary<(string, int), int>();
        var pos = wheels.Select(_ => 0).ToArray();
        
        var min = FindMin(wheels, counts, increments, pos, pullCount, mincache);
        var max = FindMax(wheels, counts, increments, pos, pullCount, maxcache);

        return (min, max);
    }

    private string GetKey(IEnumerable<int> a) => string.Join(",", a);

    private int FindMin(
        List<List<string>> wheels,
        int[] counts,
        int[] increments,
        int[] state,
        int pullsLeft,
        Dictionary<(string, int), int> cache)
    {
        if (pullsLeft == 0)
            return 0;

        var key = (GetKey(state), pullsLeft);
        if (cache.ContainsKey(key))
            return cache[key];

        var ans = int.MaxValue;
        var newStates = GetNextPositions(counts, increments, state);
        foreach (var newState in newStates)
        {
            var cats = newState.Select((o, index) => wheels[index][o]);
            var stripped = string.Join("", cats.Select(o => $"{o[0]}{o[2]}"));
            var score = Score(stripped);
            var newScore = score + FindMin(wheels, counts, increments, newState, pullsLeft - 1, cache);
            ans = Math.Min(ans, newScore);
        }

        cache[key] = ans;
        
        return ans;
    }
    
    private int FindMax(
        List<List<string>> wheels,
        int[] counts,
        int[] increments,
        int[] state,
        int pullsLeft,
        Dictionary<(string, int), int> cache)
    {
        if (pullsLeft == 0)
            return 0;

        var key = (GetKey(state), pullsLeft);
        if (cache.ContainsKey(key))
            return cache[key];

        var ans = 0;
        var newStates = GetNextPositions(counts, increments, state);
        foreach (var newState in newStates)
        {
            var cats = newState.Select((o, index) => wheels[index][o]);
            var stripped = string.Join("", cats.Select(o => $"{o[0]}{o[2]}"));
            var score = Score(stripped);
            var newScore = score + FindMax(wheels, counts, increments, newState, pullsLeft - 1, cache);
            ans = Math.Max(ans, newScore);
        }

        cache[key] = ans;
        
        return ans;
    }

    public List<int[]> GetNextPositions(int[] counts, int[] increments, int[] positions)
    {
        var nextPositions = new List<int[]>();
        int[] diffs = [-1, 0, 1];
        foreach (var diff in diffs)
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

    public int Score(string s)
    {
        var counts = new Dictionary<char, int>();
        foreach (var c in s)
        {
            if (!counts.TryAdd(c, 1))
                counts[c]++;
        }

        var score = 0;
        foreach (var kv in counts)
        {
            if (kv.Value >= 3)
                score += kv.Value - 2;
        }
        
        return score;
    }
}