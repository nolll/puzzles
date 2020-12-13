namespace ConsoleApp.Years
{
    public class PuzzleResult
    {
        public string Message { get; }
        public virtual PuzzleResultStatus Status { get; }

        public PuzzleResult(string message)
            : this(message, PuzzleResultStatus.Completed)
        {
        }

        public PuzzleResult(string message, string computedAnswer, string correctAnswer)
            : this(message, VerifyResult(computedAnswer, correctAnswer))
        {
        }

        public PuzzleResult(string message, int? computedAnswer, int correctAnswer)
            : this(message, computedAnswer?.ToString(), correctAnswer.ToString())
        {
        }

        public PuzzleResult(string message, long? computedAnswer, long correctAnswer)
            : this(message, computedAnswer?.ToString(), correctAnswer.ToString())
        {
        }

        protected PuzzleResult(string message, PuzzleResultStatus status)
        {
            Message = message;
            Status = status;
        }

        private static PuzzleResultStatus VerifyResult(string a, string b)
        {
            return a == b
                ? PuzzleResultStatus.Correct
                : PuzzleResultStatus.Completed;
        }
    }
}