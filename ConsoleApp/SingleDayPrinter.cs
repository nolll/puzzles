using System;
using ConsoleApp.Years;

namespace ConsoleApp
{
    public class SingleDayPrinter
    {
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
            PrintDayEnd(totalTimeTaken);
        }

        private static void PrintPuzzle(int part, PuzzleResult puzzleResult)
        {
            Console.WriteLine($"Part {part}:");
            Console.WriteLine(puzzleResult.Message);
        }

        private static void PrintDayTitle(Day day)
        {
            Console.WriteLine();
            Console.WriteLine($"Day {day.Id} {day.Year}:");
            Printer.PrintDivider();
        }

        private static void PrintDayEnd(TimeSpan timeTaken)
        {
            Printer.PrintDivider();
            Printer.PrintTime(timeTaken);
        }
    }
}