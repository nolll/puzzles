namespace ConsoleApp.Puzzles.Year2021.Day04
{
    public class Year2021Day04 : Year2021Day
    {
        public override int Day => 4;

        public override PuzzleResult RunPart1()
        {
            var diagnostics = new BingoGame(FileInput);
            var result = diagnostics.Play(false);

            return new PuzzleResult(result, 45031);
        }

        public override PuzzleResult RunPart2()
        {
            var diagnostics = new BingoGame(FileInput);
            var result = diagnostics.Play(true);

            return new PuzzleResult(result, 2568);
        }
    }
}