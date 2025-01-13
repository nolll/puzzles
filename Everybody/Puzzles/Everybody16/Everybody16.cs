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
        return new PuzzleResult($"{max} {min}");
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
        
        var count = 0L;
        var counts = wheels.Select(o => o.Count).ToArray();
        var scorecache = new Dictionary<string, int>();
        var nextcache = new Dictionary<string, string[]>();
        var mincache = new Dictionary<(string, int), long>();
        var maxcache = new Dictionary<(string, int), long>();
        var pos = wheels.Select(_ => 0).ToArray();
        while (true)
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

            var key = GetKey(indices);
            var stripped = string.Join("", cats.Select(o => $"{o[0]}{o[2]}"));
            var currentScore = Score(stripped);
            var next = GetNextPositions(counts, increments, indices.ToArray());
            nextcache.TryAdd(key, next.Select(GetKey).ToArray());
            
            if (!scorecache.TryAdd(key, currentScore))
            {
                break;
            }
        }

        var poskey = GetKey(pos);
        var min = FindMin(mincache, scorecache, nextcache, poskey, pullCount, 0);
        var max = FindMax(maxcache, scorecache, nextcache, poskey, pullCount, 0);

        return (min, max);
    }

    private string GetKey(IEnumerable<int> a) => string.Join(",", a);

    private long FindMin(
        Dictionary<(string, int), long> cache, 
        Dictionary<string, int> scorecache,
        Dictionary<string, string[]> nextcache,
        string poskey,
        int pullCountsLeft,
        int score)
    {
        if (pullCountsLeft == 0)
            return score;

        var cachekey = (poskey, pullCountsLeft);
        if (cache.TryGetValue(cachekey, out var cached))
        {
            if (cached <= score)
                return cached;
        }
        
        var nextkeys = nextcache[poskey];
        
        var list = new List<long>();
        var npc = pullCountsLeft - 1;
        foreach (var newkey in nextkeys)
        {
            var v = FindMin(cache, scorecache, nextcache, newkey, npc, score + scorecache[newkey]);
            cache.TryAdd((newkey, npc), v);
            list.Add(v);
        }

        var result = list.Min();
        return result;
    }
    
    private long FindMax(
        Dictionary<(string, int), long> cache, 
        Dictionary<string, int> scorecache,
        Dictionary<string, string[]> nextcache,
        string poskey,
        int pullCountsLeft,
        int score)
    {
        if (pullCountsLeft == 0)
            return score;
        
        var cachekey = (poskey, pullCountsLeft);
        if (cache.TryGetValue(cachekey, out var cached))
        {
            if (cached >= score)
                return cached;
        }
        
        var nextkeys = nextcache[poskey];
        
        var list = new List<long>();
        var npc = pullCountsLeft - 1;
        foreach (var newkey in nextkeys)
        {
            var v = FindMax(cache, scorecache, nextcache, newkey, pullCountsLeft - 1, score + scorecache[newkey]);
            cache.TryAdd((newkey, npc), v);
            list.Add(v);
        }

        var result = list.Max();
        return result;
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
                var pos = positions[i];
                var n = pos + diff + increments[i];
                while (n < 0)
                    n += counts[i];
                while (n > counts[i] - 1)
                    n -= counts[i];

                np[i] = n;
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