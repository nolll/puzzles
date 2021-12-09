namespace App.Platform
{
    public class DayResult
    {
        public PuzzleDay Day { get; }
        public TimedPuzzleResult Result1 { get; }
        public TimedPuzzleResult Result2 { get; }
        public string Comment { get; }

        public DayResult(PuzzleDay day, TimedPuzzleResult result1, TimedPuzzleResult result2)
        {
            Day = day;
            Result1 = result1;
            Result2 = result2;
            Comment = day.Puzzle.Comment ?? "";
        }
    }
}