using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2018;

[Name("Chocolate Charts")]
public class Aoc201814 : AocPuzzle
{
    [Puzzle("0d4f97136a1cd3a6231512be77e5a06d")]
    public string Part1(string input)
    {
        var i = 0;
        var elf1Pos = 0;
        var elf2Pos = 1;
        var scores = InitialScores;
        var skip = int.Parse(input);
        var target = skip + 10;
        while (i < target)
        {
            var val1 = scores.ElementAt(elf1Pos);
            var val2 = scores.ElementAt(elf2Pos);
            var score = val1 + val2;
            var hasTwoDigits = score >= 10;
            scores.Add(hasTwoDigits ? 1 : score);
            if (hasTwoDigits)
                scores.Add(score - 10);
            elf1Pos = GetElfPos(scores, elf1Pos, val1);
            elf2Pos = GetElfPos(scores, elf2Pos, val2);
            i++;
        }

        var result = scores.Skip(skip).Take(10);
        return string.Concat(result.Select(o => o.ToString()));
    }

    [Puzzle("e266a7be3c46a5ed35b66710ecd16496")]
    public int Part2(string input)
    {
        var lastEleven = "";
        var elf1Pos = 0;
        var elf2Pos = 1;
        var scores = InitialScores;
        while (!lastEleven.Contains(input))
        {
            var val1 = scores.ElementAt(elf1Pos);
            var val2 = scores.ElementAt(elf2Pos);
            var score = val1 + val2;
            var hasTwoDigits = score >= 10;
            scores.Add(hasTwoDigits ? 1 : score);
            if (hasTwoDigits)
                scores.Add(score - 10);

            lastEleven = string.Concat(scores.TakeLast(11));
            elf1Pos = GetElfPos(scores, elf1Pos, val1);
            elf2Pos = GetElfPos(scores, elf2Pos, val2);
        }

        return string.Concat(scores).IndexOf(input, StringComparison.InvariantCulture);
    }

    private static int GetElfPos(List<int> scores, int currentPos, int steps)
    {
        var newPos = currentPos + steps + 1;
        var maxPos = scores.Count - 1;
        while (newPos > maxPos) 
            newPos -= scores.Count;

        return newPos;
    }

    private static List<int> InitialScores => [3, 7];
}