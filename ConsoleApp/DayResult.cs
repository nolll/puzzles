using ConsoleApp.Years;

namespace ConsoleApp
{
    public class DayResult
    {
        public Day Day { get; }
        public TimedPuzzleResult Result1 { get; }
        public TimedPuzzleResult Result2 { get; }
        public string Comment { get; }

        public DayResult(Day day, TimedPuzzleResult result1, TimedPuzzleResult result2, string comment)
        {
            Day = day;
            Result1 = result1;
            Result2 = result2;
            Comment = comment ?? "";
        }
    }
}