namespace ConsoleApp.Puzzles
{
    public class EmptyPuzzleResult : PuzzleResult
    {
        public EmptyPuzzleResult()
            : base("No puzzle here", PuzzleResultStatus.Empty)
        {
        }
    }
}