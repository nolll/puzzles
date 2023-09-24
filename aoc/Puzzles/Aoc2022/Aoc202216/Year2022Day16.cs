using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2022.Aoc202216;

public class Year2022Day16 : AocPuzzle
{
    public override string Name => "Proboscidea Volcanium";

    protected override PuzzleResult RunPart1()
    {
        var pipes = new VolcanicPipes(InputFile);
        var result = pipes.Part1();

        return new PuzzleResult(result, 2059);
    }

    protected override PuzzleResult RunPart2()
    {
        var pipes = new VolcanicPipes(InputFile);
        var result = pipes.Part2();

        return new PuzzleResult(result, 2790);
    }
}