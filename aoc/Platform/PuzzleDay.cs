namespace Aoc.Platform;

public class PuzzleDay
{
    public int Year { get; }
    public int Day { get; }
    public AocPuzzle Puzzle { get; }

    public PuzzleDay(int year, int day, AocPuzzle puzzle)
    {
        Year = year;
        Day = day;
        Puzzle = puzzle;
    }
}