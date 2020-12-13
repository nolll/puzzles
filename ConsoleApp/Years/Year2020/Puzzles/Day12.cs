using Core.FerryNavigation;

namespace ConsoleApp.Years.Year2020.Puzzles
{
    public class Day12 : Day2020
    {
        public Day12() : base(12)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var system = new SimpleFerryNavigationSystem(FileInput);
            system.Run();
            return new PuzzleResult(system.DistanceTravelled, 1424);
        }

        public override PuzzleResult RunPart2()
        {
            var system = new WaypointFerryNavigationSystem(FileInput);
            system.Run();
            return new PuzzleResult(system.DistanceTravelled, 63447);
        }
    }
}