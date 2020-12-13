namespace ConsoleApp.Years
{
    public class EmptyPuzzleResult : PuzzleResult
    {
        public EmptyPuzzleResult()
            : base("No puzzle here", PuzzleResultStatus.Empty)
        {
        }
    }
}