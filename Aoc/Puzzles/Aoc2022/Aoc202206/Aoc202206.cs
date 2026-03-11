using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202206;

[Name("Tuning Trouble")]
public class Aoc202206 : AocPuzzle
{
    [Puzzle("df3123551cc80e1f0ce2d1ce2c900f7d")]
    public int Part1(string input) => Find(input, 4);

    [Puzzle("7b7d3c62d59d828eb3c5f0b8985d39e8")]
    public int Part2(string input) => Find(input, 14);
    
    private static int Find(string input, int searchLength)
    {
        for (var i = searchLength; i < input.Length; i++)
        {
            if (IsAllUnique(input[(i - searchLength)..i]))
                return i;
        }

        return 0;
    }

    private static bool IsAllUnique(string s) => new HashSet<char>(s.ToCharArray()).Count == s.Length;
}