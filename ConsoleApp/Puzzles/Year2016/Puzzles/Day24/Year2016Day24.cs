using Core.AirDuct;

namespace ConsoleApp.Puzzles.Year2016.Puzzles.Day24
{
    public class Year2016Day24 : Year2016Day
    {
        private AirDuctNavigator Navigator => new(FileInput);

        public override int Day => 24;

        public override PuzzleResult RunPart1()
        {
            var shortestPath = Navigator.Run(false);
            return new PuzzleResult(shortestPath, 502);
        }

        public override PuzzleResult RunPart2()
        {
            var shortestPath = Navigator.Run(true);
            return new PuzzleResult(shortestPath, 724);
        }
    }
}