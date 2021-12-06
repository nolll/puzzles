namespace ConsoleApp.Puzzles.Year2016.Day15
{
    public class Year2016Day15 : Year2016Day
    {
        public override int Day => 15;

        public override PuzzleResult RunPart1()
        {
            var sculpture = new KineticSculpture(FileInput);
            return new PuzzleResult(sculpture.TimeToPressButton, 317_371);
        }

        public override PuzzleResult RunPart2()
        {
            var sculpture = new KineticSculpture(FileInput, true);
            return new PuzzleResult(sculpture.TimeToPressButton, 2_080_951);
        }
    }
}