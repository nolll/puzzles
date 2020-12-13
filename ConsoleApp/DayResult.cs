using ConsoleApp.Years;

namespace ConsoleApp
{
    public class DayResult
    {
        public Day Day { get; }
        public TimedPuzzleResult Result1 { get; }
        public TimedPuzzleResult Result2 { get; }

        public DayResult(Day day, TimedPuzzleResult result1, TimedPuzzleResult result2)
        {
            Day = day;
            Result1 = result1;
            Result2 = result2;
        }
    }
}