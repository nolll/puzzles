namespace ConsoleApp.Years
{
    public class PuzzleResult
    {
        public string Answer { get; }
        public PuzzleResultStatus Status { get; }

        public PuzzleResult(string answer, string correctAnswer = null)
            : this(answer, VerifyResult(answer, correctAnswer))
        {
        }

        public PuzzleResult(int? answer, int? correctAnswer = null)
            : this(answer?.ToString(), correctAnswer?.ToString())
        {
        }

        public PuzzleResult(long? answer, long? correctAnswer = null)
            : this(answer?.ToString(), correctAnswer?.ToString())
        {
        }

        protected PuzzleResult(string answer, PuzzleResultStatus status)
        {
            Answer = answer;
            Status = status;
        }

        private static PuzzleResultStatus VerifyResult(string answer, string correctAnswer)
        {
            if (answer == null)
                return PuzzleResultStatus.Wrong;

            if (correctAnswer == null)
                return PuzzleResultStatus.Completed;

            return answer == correctAnswer
                ? PuzzleResultStatus.Correct
                : PuzzleResultStatus.Wrong;
        }
    }
}