using Pzl.Common;
using Pzl.Tools.Computers.Operation;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201816;

[Name("Chronal Classification")]
public class Aoc201816 : AocPuzzle
{
    protected override PuzzleResult RunPart1(string input)
    {
        var inputs = input.Split(LineBreaks.Triple);
        var input1 = inputs.First();
            
        var computer = new OpComputer();
        var count = computer.InputsMatchingThreeOrMore(input1);
        return new PuzzleResult(count, "4f397654d0fda9404b23756deb7529aa");
    }

    protected override PuzzleResult RunPart2(string input)
    {
        var inputs = input.Split(LineBreaks.Triple);
        var input1 = inputs.First();
        var input2 = inputs.Last();

        var computer = new OpComputer();
        var value = computer.RunTestProgram(input1, input2);
        return new PuzzleResult(value, "d1dc18eac2526ddd22d5eb33e4f04011");
    }
}