using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2017;

[Name("High-Entropy Passphrases")]
public class Aoc201704 : AocPuzzle
{
    [Puzzle("b3e7e2fe95c58aa22d1f35b7cd9c041a")]
    public int Part1(string input) => Solve(input, IsLineValid1);

    [Puzzle("960adf2fc72eac4faf8f3f5de0d2e01a")]
    public int Part2(string input) => Solve(input, IsLineValid2);

    public int Solve(string input, Func<string, bool> isLineValid) => 
        input.Split(LineBreaks.Single).Count(isLineValid);

    public bool IsLineValid1(string line) => IsLineValid(line, ParseLine1);
    public bool IsLineValid2(string line) => IsLineValid(line, ParseLine2);

    private static IEnumerable<string> ParseLine1(string input) =>
        input.Split(" ");

    private static IEnumerable<string> ParseLine2(string input) =>
        ParseLine1(input).Select(o => string.Concat(o.OrderBy(c => c)));

    private static bool IsLineValid(string line, Func<string, IEnumerable<string>> parseLine)
    {
        var words = parseLine(line).ToList();
        var set = words.ToHashSet();
        return words.Count == set.Count;
    }
}