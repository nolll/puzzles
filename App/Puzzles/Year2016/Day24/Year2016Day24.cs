using App.Platform;

namespace App.Puzzles.Year2016.Day24
{
    public class Year2016Day24 : PuzzleDay
    {
        private AirDuctNavigator Navigator => new(FileInput);

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