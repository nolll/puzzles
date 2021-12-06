using Core.PuzzleClasses;

namespace ConsoleApp.Puzzles.Year2020.Day12
{
    public class Year2020Day12 : Year2020Day
    {
        public override int Day => 12;

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