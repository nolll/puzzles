using Pzl.Common;

namespace Pzl.FlipFlop.Puzzles.FlipFlop2025.FlipFlop202505;

[Name("Strange tunnels")]
public class FlipFlop202505 : FlipFlopPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var chars = input.ToCharArray();
        var distinct = chars.Distinct();
        var dictionary = new Dictionary<char, (int first, int last)>();
        foreach (var c in distinct)
        {
            var first = input.IndexOf(c);
            var last = input.LastIndexOf(c);
            dictionary.Add(c, (first, last));
        }

        var steps = 0;
        for (var i = 0; i < chars.Length; i++)
        {
            var (first, last) = dictionary[chars[i]];
            if (i == first)
            {
                i = last;
            }
            else if (i == last)
            {
                i = first;
            }

            steps += Math.Abs(first - last);
        }
        
        return new PuzzleResult(steps, "5abb4bbf3aabd7a9ebecda15d22947ca");
    }

    public PuzzleResult Part2(string input)
    {
        var chars = input.ToCharArray();
        var distinct = chars.Distinct().ToList();
        var dictionary = new Dictionary<char, (int first, int last)>();
        foreach (var c in distinct)
        {
            var first = input.IndexOf(c);
            var last = input.LastIndexOf(c);
            dictionary.Add(c, (first, last));
        }

        var steps = 0;
        var seen = new HashSet<char>();
        for (var i = 0; i < chars.Length; i++)
        {
            var c = chars[i];
            seen.Add(c);
            
            var (first, last) = dictionary[c];
            if (i == first)
            {
                i = last;
            }
            else if (i == last)
            {
                i = first;
            }

            steps += Math.Abs(first - last);
        }

        var notSeen = string.Join("", distinct.Where(o => !seen.Contains(o)));
        
        return new PuzzleResult(notSeen, "68e4f28e3a2dc0c8cc1c3eabf161d53e");
    }

    public PuzzleResult Part3(string input)
    {
        var chars = input.ToCharArray();
        var distinct = chars.Distinct();
        var dictionary = new Dictionary<char, (int first, int last)>();
        foreach (var c in distinct)
        {
            var first = input.IndexOf(c);
            var last = input.LastIndexOf(c);
            dictionary.Add(c, (first, last));
        }

        var steps = 0;
        for (var i = 0; i < chars.Length; i++)
        {
            var c = chars[i];
            var (first, last) = dictionary[c];
            var direction = char.IsUpper(c) ? -1 : 1;
            if (i == first)
            {
                i = last;
            }
            else if (i == last)
            {
                i = first;
            }

            steps += direction * Math.Abs(first - last);
        }
        
        return new PuzzleResult(steps, "36c49d43c6bb2d7a410d976dda77c3f2");
    }
}