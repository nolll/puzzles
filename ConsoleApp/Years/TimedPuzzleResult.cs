using System;

namespace ConsoleApp.Years
{
    public class TimedPuzzleResult : PuzzleResult
    {
        public TimeSpan TimeTaken { get; }

        public TimedPuzzleResult(PuzzleResult result, TimeSpan timeTaken)
            : base(result.Answer, result.Status)
        {
            TimeTaken = timeTaken;
        }
    }
}