using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202204;

[Name("Camp Cleanup")]
public class Aoc202204 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var cleaning = new Cleaning();
        var result = cleaning.Part1(input);

        return new PuzzleResult(result, "9569cfbf59abc27202b8777006153703");
    }

    public PuzzleResult RunPart2(string input)
    {
        var cleaning = new Cleaning();
        var result = cleaning.Part2(input);

        return new PuzzleResult(result, "1cf622579ace09c8f182b5640835416f");
    }
}