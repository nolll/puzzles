using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConsoleApp.Years;
using Core.Tools;

namespace ConsoleApp
{
    public class Program
    {
        private static DaySelector _daySelector;
        private const int PuzzleTimeout = 10;

        private const int Year = 2020;
        private const int Day = 13;

        static void Main(string[] args)
        {
            _daySelector = new DaySelector();
            var parameters = Parameters.Parse(args);

            if (parameters.ShowHelp)
            {
                ShowHelp();
                return;
            }

            if (parameters.RunAll)
            {
                RunAll();
                return;
            }

            if (parameters.Year != null && parameters.Day == null)
            {
                RunYear(parameters.Year.Value);
                return;
            }

            if (parameters.Year == null && parameters.Day == null)
            {
                parameters = new Parameters(day: Day, year: Year);
            }

            var day = _daySelector.GetDay(parameters.Year, parameters.Day);
            if (day == null)
            {
                throw new Exception("The specified day could not be found.");
            }

            var result = Run(day);
            PrintDay(result);
        }

        private static DayResult Run(Day day, int? timeout = null)
        {
            var p1 = RunPuzzleWithTimer(day.RunPart1, timeout);
            var p2 = RunPuzzleWithTimer(day.RunPart2, timeout);
            
            return new DayResult(day, p1, p2);
        }

        private static void PrintDay(DayResult dayResult)
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

        private static void PrintDayAsTableRow(DayResult dayResult)
        {
            var day = dayResult.Day.Id.ToString().PadLeft(2, '0');
            var dayAndYear = $"Day {day} {dayResult.Day.Year}";
            var p1 = GetTableResult(dayResult.Result1).PadRight(10, ' ');
            var p1Color = GetColor(dayResult.Result1);
            var p2 = GetTableResult(dayResult.Result2).PadRight(10, ' ');
            var p2Color = GetColor(dayResult.Result2);

            var defaultColor = Console.ForegroundColor;

            Console.Write("| ");
            Console.Write(dayAndYear);
            Console.Write(" | ");
            Console.ForegroundColor = p1Color;
            Console.Write(p1);
            Console.ForegroundColor = defaultColor;
            Console.Write(" | ");
            Console.ForegroundColor = p2Color;
            Console.Write(p2);
            Console.ForegroundColor = defaultColor;
            Console.Write(" | ");
            Console.WriteLine();
        }

        private static ConsoleColor GetColor(PuzzleResult result)
        {
            var status = result.Status;
            if(status == PuzzleResultStatus.Failed || status == PuzzleResultStatus.Missing || status == PuzzleResultStatus.Timeout)
                return ConsoleColor.Red;

            return status == PuzzleResultStatus.Correct 
                ? ConsoleColor.Green
                : ConsoleColor.Yellow;
        }

        private static string GetTableResult(TimedPuzzleResult result)
        {
            if (result.Status == PuzzleResultStatus.Empty)
                return "";

            if (result.Status == PuzzleResultStatus.Failed)
                return "failed";

            if (result.Status == PuzzleResultStatus.Missing)
                return "missing";

            var timeTaken = result.Status == PuzzleResultStatus.Timeout
                ? TimeSpan.FromSeconds(PuzzleTimeout)
                : result.TimeTaken;

            var formattedTime = Formatter.FormatTime(timeTaken);

            return result.Status == PuzzleResultStatus.Timeout
                ? $">{formattedTime}"
                : formattedTime;
        }

        private static TimedPuzzleResult RunPuzzleWithTimer(Func<PuzzleResult> func, int? timeout)
        {
            var timer = new Timer();
            var result = RunPuzzle(func, timeout);
            return new TimedPuzzleResult(result, timer.FromStart);
        }

        private static PuzzleResult RunPuzzle(Func<PuzzleResult> func, int? timeout)
        {
            PuzzleResult result = null;
            try
            {
                if (timeout != null)
                {
                    var task1 = Task.Run(() => result = func());
                    if (!task1.Wait(TimeSpan.FromSeconds(PuzzleTimeout)))
                        return new TimeoutPuzzleResult($"Puzzle failed to finish within {PuzzleTimeout} seconds");
                }
                else
                {
                    result = func();
                }
                
                return result ?? new MissingPuzzleResult("Puzzle returned null");
            }
            catch (Exception)
            {
                return new FailedPuzzleResult("Puzzle failed");
            }
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

        private static void RunYear(int year)
        {
            var e = _daySelector.GetEvent(year);
            if(e == null)
                throw new Exception("Event not found!");

            RunMany(e.Days);
        }

        private static void RunAll()
        {
            RunMany(_daySelector.GetAll());
        }

        private static void RunMany(IEnumerable<Day> days)
        {
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("| day         | part 1     | part 2     |");
            Console.WriteLine("-----------------------------------------");
            foreach (var day in days)
            {
                var result = Run(day, PuzzleTimeout);
                PrintDayAsTableRow(result);
            }
            Console.WriteLine("-----------------------------------------");
        }

        private static void ShowHelp()
        {
            var helpPrinter = new HelpPrinter();
            helpPrinter.Print();
        }
    }
}
