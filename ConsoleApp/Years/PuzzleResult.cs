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

        public PuzzleResult(int? answer, int correctAnswer)
            : this(answer?.ToString(), correctAnswer.ToString())
        {
        }

        public PuzzleResult(long? answer, long correctAnswer)
            : this(answer?.ToString(), correctAnswer.ToString())
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