using System;
using App.Platform;

namespace Cli.Printing
{
    public class SingleDayPrinter : DayPrinter, ISingleDayPrinter
    {
        private const string Divider = "--------------------------------------------------";

        public void PrintDay(DayResult dayResult)
        {
            PrintDayTitle(dayResult.Day);
            PrintPuzzle(1, dayResult.Result1);
            if (dayResult.Result2.Status != PuzzleResultStatus.Empty)
            {
                Console.WriteLine();
                PrintPuzzle(2, dayResult.Result2);
            }

            var totalTimeTaken = dayResult.Result1.TimeTaken + dayResult.Result2.TimeTaken;
            PrintDayEnd(dayResult, totalTimeTaken);
        }

        private void PrintPuzzle(int part, TimedPuzzleResult puzzleResult)
        {
            var time = Formatter.FormatTime(puzzleResult.TimeTaken);
            Console.WriteLine($"Part {part}: {time}");
            var color = GetColor(puzzleResult);
            SetColor(color);
            Console.Write(puzzleResult.Answer);
            ResetColor();
            Console.WriteLine();
        }

        private static void PrintDayTitle(PuzzleDay day)
        {
            Console.WriteLine();
            Console.WriteLine($"Day {day.Day} {day.Year}:");
            if(day.Puzzle.Title != null)
                Console.WriteLine(day.Puzzle.Title);
            PrintDivider();
        }

        private void PrintDayEnd(DayResult dayResult, TimeSpan timeTaken)
        {
            PrintDivider();
            if (!string.IsNullOrEmpty(dayResult.Comment))
            {
                SetColor(ConsoleColor.Yellow);
                Console.WriteLine(dayResult.Comment);
                ResetColor();
                PrintDivider();
            }
            var time = Formatter.FormatTime(timeTaken);
            Console.WriteLine(time.PadLeft(Divider.Length));
        }

        private static void PrintDivider()
        {
            Console.WriteLine(Divider);
        }
    }
}