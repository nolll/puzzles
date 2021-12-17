namespace App.Platform;

public class PuzzleDay
{
    public int Year { get; }
    public int Day { get; }
    public Puzzle Puzzle { get; }

    public PuzzleDay(int year, int day, Puzzle puzzle)
    {
        Year = year;
        Day = day;
        Puzzle = puzzle;
    }
}