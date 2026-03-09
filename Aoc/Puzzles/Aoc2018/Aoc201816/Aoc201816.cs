using Pzl.Common;
using Pzl.Tools.Computers.Operation;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201816;

[Name("Chronal Classification")]
public class Aoc201816 : AocPuzzle
{
    [Puzzle("4f397654d0fda9404b23756deb7529aa")]
    public int Part1(string input)
    {
        var inputs = input.Split(LineBreaks.Triple);
        return new OpComputer().InputsMatchingThreeOrMore(inputs.First());
    }

    [Puzzle("d1dc18eac2526ddd22d5eb33e4f04011")]
    public long Part2(string input)
    {
        var inputs = input.Split(LineBreaks.Triple);
        return new OpComputer().RunTestProgram(inputs.First(), inputs.Last());
    }
}