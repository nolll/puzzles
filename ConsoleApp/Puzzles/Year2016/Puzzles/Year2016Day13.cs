using Core.CubicleMaze;

namespace ConsoleApp.Puzzles.Year2016.Puzzles
{
    public class Year2016Day13 : Year2016Day
    {
        public override int Day => 13;

        public override PuzzleResult RunPart1()
        {
            var maze = new Maze(50, 50, Input);
            var stepCount = maze.StepCountToTarget(31, 39);
            return new PuzzleResult(stepCount, 82);
        }

        public override PuzzleResult RunPart2()
        {
            var maze = new Maze(75, 75, Input);
            var locationCount = maze.LocationCountAfter(50);
            return new PuzzleResult(locationCount, 138);
        }

        private const int Input = 1362;
    }
}