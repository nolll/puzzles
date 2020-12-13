namespace ConsoleApp.Years
{
    public class PuzzleResult
    {
        public string Answer { get; }
        public virtual PuzzleResultStatus Status { get; }

        public PuzzleResult(string answer)
            : this(answer, PuzzleResultStatus.Completed)
        {
        }

        public PuzzleResult(string answer, string correctAnswer)
            : this(answer, VerifyResult(answer, correctAnswer))
        {
        }

        public PuzzleResult(int? computedAnswer, int correctAnswer)
            : this(computedAnswer?.ToString(), correctAnswer.ToString())
        {
        }

        public PuzzleResult(long? computedAnswer, long correctAnswer)
            : this(computedAnswer?.ToString(), correctAnswer.ToString())
        {
        }

        protected PuzzleResult(string answer, PuzzleResultStatus status)
        {
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