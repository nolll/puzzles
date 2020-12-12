namespace ConsoleApp.Years
{
    public class PuzzleResult
    {
        public string Message { get; }
        public virtual PuzzleResultStatus Status => PuzzleResultStatus.Success;

        public PuzzleResult(string message)
        {
            Message = message;
        }
    }
}