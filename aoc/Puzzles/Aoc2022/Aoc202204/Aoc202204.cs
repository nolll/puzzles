using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2022.Aoc202204;

public class Aoc202204 : AocPuzzle
{
    public override string Name => "Camp Cleanup";

    protected override PuzzleResult RunPart1()
    {
        var cleaning = new Cleaning();
        var result = cleaning.Part1(InputFile);

        return new PuzzleResult(result, "9569cfbf59abc27202b8777006153703");
    }

    protected override PuzzleResult RunPart2()
    {
        var cleaning = new Cleaning();
        var result = cleaning.Part2(InputFile);

        return new PuzzleResult(result, "1cf622579ace09c8f182b5640835416f");
    }
}