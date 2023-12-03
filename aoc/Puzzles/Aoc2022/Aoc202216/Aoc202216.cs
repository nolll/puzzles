using Puzzles.Common.Puzzles;

namespace Puzzles.Aoc.Puzzles.Aoc2022.Aoc202216;

public class Aoc202216 : AocPuzzle
{
    public override string Name => "Proboscidea Volcanium";

    protected override PuzzleResult RunPart1()
    {
        var pipes = new VolcanicPipes(InputFile);
        var result = pipes.Part1();

        return new PuzzleResult(result, "dd3e51c50edd114901226b469c51dd40");
    }

    protected override PuzzleResult RunPart2()
    {
        var pipes = new VolcanicPipes(InputFile);
        var result = pipes.Part2();

        return new PuzzleResult(result, "29db1cdba5fd2b052581c68854027ea8");
    }
}