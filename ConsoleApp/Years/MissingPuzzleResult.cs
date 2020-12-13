namespace ConsoleApp.Years
{
    public class MissingPuzzleResult : PuzzleResult
    {
        public MissingPuzzleResult(string message)
            : base(message, PuzzleResultStatus.Missing)
        {
        }
    }
}