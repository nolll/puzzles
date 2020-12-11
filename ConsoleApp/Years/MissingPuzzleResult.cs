namespace ConsoleApp.Years
{
    public class MissingPuzzleResult : PuzzleResult
    {
        public override PuzzleResultStatus Status => PuzzleResultStatus.Missing;

        public MissingPuzzleResult(string message)
            : base(message)
        {
        }
    }
}