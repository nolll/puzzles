using System;

namespace Core.PuzzleClasses
{
    public class TimedPuzzleResult : PuzzleResult
    {
        public TimeSpan TimeTaken { get; }

        public TimedPuzzleResult(PuzzleResult result, TimeSpan timeTaken)
            : base(result.Answer, result.CorrectAnswer, result.Status)
        {
            TimeTaken = timeTaken;
        }
    }
}