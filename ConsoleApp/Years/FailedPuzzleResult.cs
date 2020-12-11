namespace ConsoleApp.Years
{
    public class FailedPuzzleResult : PuzzleResult
    {
        public override PuzzleResultStatus Status => PuzzleResultStatus.Failed;

        public FailedPuzzleResult(string message)
            : base(message)
        {
        }
    }
}