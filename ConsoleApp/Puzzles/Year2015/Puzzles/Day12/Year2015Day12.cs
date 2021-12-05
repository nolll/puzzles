namespace ConsoleApp.Puzzles.Year2015.Puzzles.Day12
{
    public class Year2015Day12 : Year2015Day
    {
        public override int Day => 12;

        public override PuzzleResult RunPart1()
        {
            var doc = new JsonDoc(FileInput, true);
            return new PuzzleResult(doc.Sum, 119_433);
        }

        public override PuzzleResult RunPart2()
        {
            var doc = new JsonDoc(FileInput, false);
            return new PuzzleResult(doc.Sum, 68_466);
        }
    }
}