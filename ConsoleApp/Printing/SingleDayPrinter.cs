using System;
using ConsoleApp.Puzzles;
using Core.PuzzleClasses;

namespace ConsoleApp.Printing
{
    public class SingleDayPrinter : DayPrinter
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
            //if (puzzleResult.Status == PuzzleResultStatus.Wrong)
            //{
            //    Console.WriteLine();
            //    SetColor(ConsoleColor.DarkRed);
            //    Console.Write(puzzleResult.CorrectAnswer);
            //}
            ResetColor();
            Console.WriteLine();
        }

        private static void PrintDayTitle(PuzzleDay day)
        {
            Console.WriteLine();
            Console.WriteLine($"Day {day.Id} {day.Year}:");
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