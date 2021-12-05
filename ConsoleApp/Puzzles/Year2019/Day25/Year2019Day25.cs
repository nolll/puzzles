namespace ConsoleApp.Puzzles.Year2019.Day25
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