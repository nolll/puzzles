namespace App.Platform
{
    public class PuzzleWrapper
    {
        public int Year { get; }
        public int Day { get; }
        public PuzzleDay Puzzle { get; }

        public PuzzleWrapper(int year, int day, PuzzleDay puzzle)
        {
            Year = year;
            Day = day;
            Puzzle = puzzle;
        }
    }
}