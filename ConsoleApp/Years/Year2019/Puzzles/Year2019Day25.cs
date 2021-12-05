using Core.SantasShip;

namespace ConsoleApp.Years.Year2019.Puzzles
{
    public class Year2019Day25 : Year2019Day
    {
        public override int Day => 25;

        public override PuzzleResult RunPart1()
        {
            var investigationDroid = new InvestigationDroid(FileInput);
            var password = investigationDroid.Run();

            return new PuzzleResult(password, "285213704");
        }

        public override PuzzleResult RunPart2()
        {
            return new EmptyPuzzleResult();
        }
    }
}