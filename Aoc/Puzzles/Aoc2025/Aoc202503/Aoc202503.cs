using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2025.Aoc202503;

[Name("Lobby")]
public class Aoc202503 : AocPuzzle
{
    public PuzzleResult Part1(string input) => new(Solve(input, 2), "ce9af8880b553c9cab99abd575d740d4");
    public PuzzleResult Part2(string input) => new(Solve(input, 12), "36d07bc1885b57661b710706722959fa");
    private static long Solve(string input, int batteryCount) => input.Split(LineBreaks.Single).Sum(o => GetJoltage(o, batteryCount));
    private static long GetJoltage(string s, int batteryCount) => long.Parse(string.Join("", GetJoltageDigits(s, batteryCount)));

    private static IEnumerable<char> GetJoltageDigits(string s, int batteryCount)
    { 
        var startAt = 0;

        for (var j = 0; j < batteryCount; j++)
        {
            var pos = startAt;
            var digit = '0';
            var endAt = s.Length - batteryCount + j + 1;
            for (var i = startAt; i < endAt; i++)
            {
                if (s[i] <= digit) continue;
                digit = s[i];
                pos = i;
            }

            yield return digit;
            startAt = pos + 1;
        }
    }
}