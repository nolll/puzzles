using Core.Platform;

namespace Core.Puzzles.Year2022.Day24;

public class Year2022Day24 : Puzzle
{
    public override string Title => "Blizzard Basin";
    
    public override PuzzleResult RunPart1()
    {
        var blizzardNavigation = new BlizzardNavigation(FileInput);
        var result = blizzardNavigation.Part1();

        return new PuzzleResult(result, 249);
    }

    public override PuzzleResult RunPart2()
    {
        var blizzardNavigation = new BlizzardNavigation(FileInput);
        var result = blizzardNavigation.Part2();

        return new PuzzleResult(result, 735);
    }
}