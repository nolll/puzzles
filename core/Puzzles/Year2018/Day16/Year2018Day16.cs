using System.Linq;
using App.Common.Computers.Operation;
using App.Platform;

namespace App.Puzzles.Year2018.Day16;

public class Year2018Day16 : Puzzle
{
    public override PuzzleResult RunPart1()
    {
        var inputs = FileInput.Split("\r\n\r\n\r\n");
        var input1 = inputs.First();
            
        var computer = new OpComputer();
        var count = computer.InputsMatchingThreeOrMore(input1);
        return new PuzzleResult(count, 567);
    }

    public override PuzzleResult RunPart2()
    {
        var inputs = FileInput.Split("\r\n\r\n\r\n");
        var input1 = inputs.First();
        var input2 = inputs.Last();

        var computer = new OpComputer();
        var value = computer.RunTestProgram(input1, input2);
        return new PuzzleResult(value, 610);
    }
}