using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202216;

[Name("Proboscidea Volcanium")]
public class Aoc202216 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var pipes = new VolcanicPipes(input);
        var result = pipes.Part1();

        return new PuzzleResult(result, "dd3e51c50edd114901226b469c51dd40");
    }

    public PuzzleResult RunPart2(string input)
    {
        var pipes = new VolcanicPipes(input);
        var result = pipes.Part2();

        return new PuzzleResult(result, "29db1cdba5fd2b052581c68854027ea8");
    }
}