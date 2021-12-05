namespace ConsoleApp.Puzzles
{
    public class FailedPuzzleResult : PuzzleResult
    {
        public FailedPuzzleResult(string message)
            : base(message, PuzzleResultStatus.Failed)
        {
        }
    }
}