using Core.SantasShip;

namespace ConsoleApp.Years.Year2019.Puzzles
{
    public class Day25 : Day2019
    {
        public Day25() : base(25)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var investigationDroid = new InvestigationDroid(FileInput);
            var password = investigationDroid.Run();

            return new PuzzleResult($"Password: {password}");
        }

        public override PuzzleResult RunPart2()
        {
            return new EmptyPuzzleResult();
        }
    }
}