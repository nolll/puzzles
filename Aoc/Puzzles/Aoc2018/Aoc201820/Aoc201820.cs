using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201820;

[Name("A Regular Map")]
public class Aoc201820 : AocPuzzle
{
    [Puzzle("83076f3a8aaf1a87fab2dcf2ecc1d1ea")]
    public int Part1(string input) => new RegularMapNavigator(input).MostDoors;

    [Puzzle("500a039b53fddc7bdd70781ce0f8df5a")]
    public int Part2(string input) => new RegularMapNavigator(input).RoomsMoreThat1000DoorsAway;
}