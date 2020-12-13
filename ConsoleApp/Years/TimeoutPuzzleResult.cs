namespace ConsoleApp.Years
{
    public class TimeoutPuzzleResult : PuzzleResult
    {
        public TimeoutPuzzleResult(string message)
            : base(message, PuzzleResultStatus.Timeout)
        {
        }
    }
}