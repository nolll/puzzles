using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201820;

[Name("A Regular Map")]
public class Aoc201820 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var navigator = new RegularMapNavigator(input);
        return new PuzzleResult(navigator.MostDoors, "83076f3a8aaf1a87fab2dcf2ecc1d1ea");
    }

    public PuzzleResult RunPart2(string input)
    {
        var navigator = new RegularMapNavigator(input);
        return new PuzzleResult(navigator.RoomsMoreThat1000DoorsAway, "500a039b53fddc7bdd70781ce0f8df5a");
    }
}