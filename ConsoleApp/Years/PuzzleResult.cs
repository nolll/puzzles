namespace ConsoleApp.Years
{
    public class PuzzleResult
    {
        public string Message { get; }
        public string Answer { get; }
        public virtual PuzzleResultStatus Status { get; }

        public PuzzleResult(string message)
            : this(message, null, PuzzleResultStatus.Completed)
        {
        }

        public PuzzleResult(string message, string answer)
            : this(message, answer, PuzzleResultStatus.Completed)
        {
        }

        public PuzzleResult(string message, string answer, string correctAnswer)
            : this(message, answer, VerifyResult(answer, correctAnswer))
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

        protected PuzzleResult(string message, string answer, PuzzleResultStatus status)
        {
            Message = message;
            Answer = answer;
            Status = status;
        }

        private static PuzzleResultStatus VerifyResult(string a, string b)
        {
            return a != null && b != null && a == b
                ? PuzzleResultStatus.Correct
                : PuzzleResultStatus.Completed;
        }
    }
}