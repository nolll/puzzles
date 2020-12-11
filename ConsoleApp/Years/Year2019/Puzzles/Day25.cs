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
            investigationDroid.Run();

            return new MissingPuzzleResult("No output");
        }
    }
}