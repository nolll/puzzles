using System.Linq;
using Common.Computers.Operation;
using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2018.Day16;

public class Year2018Day16 : AocPuzzle
{
    public override string Name => "Chronal Classification";

    protected override PuzzleResult RunPart1()
    {
        var inputs = InputFile.Split("\r\n\r\n\r\n");
        var input1 = inputs.First();
            
        var computer = new OpComputer();
        var count = computer.InputsMatchingThreeOrMore(input1);
        return new PuzzleResult(count, 567);
    }

    protected override PuzzleResult RunPart2()
    {
        var inputs = InputFile.Split("\r\n\r\n\r\n");
        var input1 = inputs.First();
        var input2 = inputs.Last();

        var computer = new OpComputer();
        var value = computer.RunTestProgram(input1, input2);
        return new PuzzleResult(value, 610);
    }
}