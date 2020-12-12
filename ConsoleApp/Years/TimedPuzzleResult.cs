using System;

namespace ConsoleApp.Years
{
    public class TimedPuzzleResult : PuzzleResult
    {
        public TimeSpan TimeTaken { get; }
        public override PuzzleResultStatus Status { get; }

        public TimedPuzzleResult(PuzzleResult result, TimeSpan timeTaken)
            : base(result.Message)
        {
            TimeTaken = timeTaken;
            Status = result.Status;
        }
    }
}