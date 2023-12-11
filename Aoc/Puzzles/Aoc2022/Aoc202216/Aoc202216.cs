using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202216;

[Name("Proboscidea Volcanium")]
public class Aoc202216(string input) : AocPuzzle(input)
{
    protected override PuzzleResult RunPart1()
    {
        var pipes = new VolcanicPipes(Input);
        var result = pipes.Part1();

        return new PuzzleResult(result, "dd3e51c50edd114901226b469c51dd40");
    }

    protected override PuzzleResult RunPart2()
    {
        var pipes = new VolcanicPipes(Input);
        var result = pipes.Part2();

        return new PuzzleResult(result, "29db1cdba5fd2b052581c68854027ea8");
    }
}