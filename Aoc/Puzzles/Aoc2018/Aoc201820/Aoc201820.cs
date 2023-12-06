using Pzl.Tools.Puzzles;

namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201820;

public class Aoc201820 : AocPuzzle
{
    public override string Name => "A Regular Map";

    protected override PuzzleResult RunPart1()
    {
        var navigator = new RegularMapNavigator(InputFile);
        return new PuzzleResult(navigator.MostDoors, "83076f3a8aaf1a87fab2dcf2ecc1d1ea");
    }

    protected override PuzzleResult RunPart2()
    {
        var navigator = new RegularMapNavigator(InputFile);
        return new PuzzleResult(navigator.RoomsMoreThat1000DoorsAway, "500a039b53fddc7bdd70781ce0f8df5a");
    }
}