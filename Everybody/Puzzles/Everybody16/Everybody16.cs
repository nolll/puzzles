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

            var key = string.Join("", indices);
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

    public PuzzleResult Part3(string input)
    {
        return new PuzzleResult(0);
    }
}