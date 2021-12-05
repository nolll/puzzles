namespace ConsoleApp.Puzzles
{
    public class MissingPuzzleResult : PuzzleResult
    {
        public MissingPuzzleResult(string message)
            : base(message, PuzzleResultStatus.Missing)
        {
        }
    }
}