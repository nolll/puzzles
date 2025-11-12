using Pzl.Common;

namespace Pzl.Everybody.Puzzles.Ece2025.Ece202506;

[Name("Mentorship Matrix")]
public class Ece202506 : EverybodyEventPuzzle
{
    private const int Repeats = 1000;
    private const int Limit = 1000;
    
    public PuzzleResult Part1(string input)
    {
        var pairCount = 0;
        var mentorCount = 0;
        foreach (var c in input)
        {
            if (c == 'A')
                mentorCount++;
            if (c == 'a')
                pairCount += mentorCount;
        }
        
        return new PuzzleResult(pairCount, "b25b0bb41622a516674c2bc66a9fa6cc");
    }

    public PuzzleResult Part2(string input)
    {
        var pairCounts = new Dictionary<char, int>();
        var mentorCounts = new Dictionary<char, int>();
        foreach (var c in input)
        {
            if (char.IsUpper(c))
            {
                mentorCounts.TryGetValue(c, out var count);
                mentorCounts[c] = count + 1;
                continue;
            }

            if (mentorCounts.TryGetValue(char.ToUpper(c), out var mentorCount))
            {
                pairCounts.TryGetValue(c, out var count);
                pairCounts[c] = count + mentorCount;
            }
        }
        
        return new PuzzleResult(pairCounts.Values.Sum(), "1ed970fa12bad936e8d2adb6440fc930");
    }

    public PuzzleResult Part3(string input)
    {
        var segmentLength = (int)Math.Ceiling((double)Limit / input.Length) * input.Length;
        var repeatsInSegment = segmentLength / input.Length;
        var tentCount = segmentLength * 2 + input.Length;

        var tents = "";
        while(tents.Length < tentCount) 
            tents += input;

        var indexes = new Dictionary<char, List<int>>();
        for (var i = 0; i < tents.Length; i++)
        {
            var c = tents[i];
            if (char.IsUpper(c) && !indexes.TryAdd(c, [i])) 
                indexes[c].Add(i);
        }

        var p1Count = MentorCountInRange(tents, indexes, 0, segmentLength);
        var p2Count = MentorCountInRange(tents, indexes, segmentLength, segmentLength + input.Length);
        var p3Count = MentorCountInRange(tents, indexes, segmentLength + input.Length, tents.Length);

        var pairCount = p1Count + p2Count * (Repeats - repeatsInSegment * 2) + p3Count;
        
        return new PuzzleResult(pairCount, "c8488eedc9facc7555706017e12be89a");
    }

    private static int MentorCountInRange(string tents, Dictionary<char, List<int>> indexes, int startIndex, int endIndex)
    {
        var count = 0;
        for (var i = startIndex; i < endIndex; i++)
        {
            var c = tents[i];
            if (char.IsLower(c)) 
                count += indexes[char.ToUpper(c)].Count(o => o >= i - Limit && o <= i + Limit);
        }

        return count;
    }
}