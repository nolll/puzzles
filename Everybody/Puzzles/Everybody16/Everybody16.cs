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

        var lcm = MathTools.Lcm(increments.Select(o => (long)o));
        Console.WriteLine($"lcm: {lcm}");

        var seen = new HashSet<string>();
        var count = 1;
        var score = 0L;
        while (true)
        {
            var cats = new List<string>();
            for (var i = 0; i < wheels.Count; i++)
            {
                var wheel = wheels[i];
                var cat = wheel[count * increments[i] % wheel.Count];
                cats.Add(cat);
            }
            
            var full = string.Join("", cats);
            if (seen.Contains(full))
                break;

            var stripped = string.Join("", cats.Select(o => $"{o[0]}{o[2]}"));
            score += Score(stripped);
            
            seen.Add(full);
            count++;
        }

        var result = 0;
        
        return new PuzzleResult(result);
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