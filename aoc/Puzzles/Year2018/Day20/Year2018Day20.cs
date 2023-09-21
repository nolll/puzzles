using Aoc.Platform;
using common.Puzzles;

namespace Aoc.Puzzles.Year2018.Day20;

public class Year2018Day20 : AocPuzzle
{
    public override string Title => "A Regular Map";

    public override PuzzleResult RunPart1()
    {
        var navigator = new RegularMapNavigator(FileInput);
        return new PuzzleResult(navigator.MostDoors, 4050);
    }

    public override PuzzleResult RunPart2()
    {
        var navigator = new RegularMapNavigator(FileInput);
        return new PuzzleResult(navigator.RoomsMoreThat1000DoorsAway, 8564);
    }
}