namespace ConsoleApp.Years
{
    public class EmptyPuzzleResult : PuzzleResult
    {
        public override PuzzleResultStatus Status => PuzzleResultStatus.Empty;

        public EmptyPuzzleResult()
            : base("No puzzle here")
        {
        }
    }
}