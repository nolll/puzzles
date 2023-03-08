using Core.Common.Computers.IntCode;
using Core.Platform;

namespace Core.Puzzles.Year2019.Day05;

public class Year2019Day05 : Puzzle
{
    private long _output;

    public override string Title => "Sunny with a Chance of Asteroids";

    public override PuzzleResult RunPart1()
    {
        var ci1 = new IntCodeComputer(FileInput, ReadInputPart1, WriteOutput);
        ci1.Start();

        return new PuzzleResult(_output, 5_346_030);
    }

    public override PuzzleResult RunPart2()
    {
        var ci2 = new IntCodeComputer(FileInput, ReadInputPart2, WriteOutput);
        ci2.Start();

        return new PuzzleResult(_output, 513_116);
    }

    private long ReadInputPart1() => 1;
    private long ReadInputPart2() => 5;

    private void WriteOutput(long output)
    {
        _output = output;
    }
}