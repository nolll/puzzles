using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202212;

[Name("Hill Climbing Algorithm")]
public class Aoc202212 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var hillClimbing = new HillClimbing();
        var result = hillClimbing.Part1(input);

        return new PuzzleResult(result, "48b865d6e753e7b8f1cd6f83d797bd43");
    }

    public PuzzleResult RunPart2(string input)
    {
        var hillClimbing = new HillClimbing();
        var result = hillClimbing.Part2(input);

        return new PuzzleResult(result, "222a9519ff249ce48bdd88917bbcc312");
    }
}