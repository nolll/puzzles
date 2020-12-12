namespace ConsoleApp.Years
{
    public class TimeoutPuzzleResult : PuzzleResult
    {
        public override PuzzleResultStatus Status => PuzzleResultStatus.Timeout;

        public TimeoutPuzzleResult(string message)
            : base(message)
        {
        }
    }
}