using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202225;

[Name("Full of Hot Air")]
public class Aoc202225 : AocPuzzle
{
    [Puzzle("")]
    public PuzzleResult Part1(string input)
    {
        var result = SolvePart1(input);

        return new PuzzleResult(result, "793d1443281edc7d7e628e25d8aa07a4");
    }

    public string SolvePart1(string input) => 
        SnafuConverter.ToSnafu(input.Split(LineBreaks.Single).Select(SnafuConverter.ToNumber).Sum());
}