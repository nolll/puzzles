using Pzl.Common;
using Pzl.Tools.Computers.Operation;

namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201821;

[IsSlow] // 69s for part 2
[Name("Chronal Conversion")]
[Comment("OpComputer")]
public class Aoc201821 : AocPuzzle
{
    [Puzzle("cbaac5c05e7a649e9d578813a7d96c60")]
    public long Part1(string input) => new OpComputer().RunSpecialForDay21(input, 0, true);

    [Puzzle("ea87eb4b91f7e0c9373c7ce75f369320")]
    public long Part2(string input) => new OpComputer().RunSpecialForDay21(input, 0, false);
}