using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202012;

[Name("Rain Risk")]
public class Aoc202012 : AocPuzzle
{
    [Puzzle("c78da9d22889e3d4313249117e3752f4")]
    public int Part1(string input)
    {
        var system = new SimpleFerryNavigationSystem(input);
        system.Run();
        return system.DistanceTravelled;
    }

    [Puzzle("c0c5befc741f65a1030078ab200ffe10")]
    public int Part2(string input)
    {
        var system = new WaypointFerryNavigationSystem(input);
        system.Run();
        return system.DistanceTravelled;
    }
}