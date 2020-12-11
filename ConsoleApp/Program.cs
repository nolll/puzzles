using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ConsoleApp.Years;
using Core.Tools;

namespace ConsoleApp
{
    public class Program
    {
        private static DaySelector _daySelector;
        private const int PuzzleTimeout = 10;
        private const int DayTimeout = PuzzleTimeout * 2;

        private const int Year = 2020;
        private const int Day = 11;

        static void Main(string[] args)
        {
            _daySelector = new DaySelector();
            var parameters = Parameters.Parse(args);

            if (parameters.ShowHelp)
            {
                ShowHelp();
                return;
            }
            
            if (parameters.Year != null && parameters.Day != null)
            {
                RunDay(parameters);
                return;
            }
            
            if (parameters.Year != null)
            {
                RunYear(parameters.Year.Value);
                return;
            }
            
            if (parameters.RunAll)
            {
                RunAll();
                return;
            }

            if (!parameters.WasYearOrDaySpecified)
            {
                parameters = new Parameters(day: Day, year: Year);
            }

            RunDay(parameters);
        }

        private static void RunDay(Parameters parameters)
        {
            var day = _daySelector.GetDay(parameters.Year, parameters.Day);
            if (day == null)
            {
                Console.WriteLine("The specified day could not be found.");
                return;
            }

            RunWithTimeout(day);
        }

        private static void RunWithTimeout(Day day)
        {
            var timer = new Timer();
            PuzzleResult part1Result = null;
            var task1 = Task.Run(() => part1Result = day.RunPart1());
            if (!task1.Wait(TimeSpan.FromSeconds(PuzzleTimeout)))
                part1Result = new PuzzleResult($"Puzzle failed to finish within {PuzzleTimeout} seconds");

            if (part1Result == null)
            {
                RunLegacyDay(day, timer);
                return;
            }

            PrintDayTitle(day);
            PrintPuzzle(1, part1Result);

            PuzzleResult part2Result = null;
            var task2 = Task.Run(() => part2Result = day.RunPart2());
            if (!task2.Wait(TimeSpan.FromSeconds(PuzzleTimeout)))
            {
                part2Result = new PuzzleResult($"Puzzle failed to finish within {PuzzleTimeout} seconds");
            }

            if(part2Result != null)
                PrintPuzzle(2, part2Result);
            
            PrintDayEnd(timer);
        }

        private static void RunLegacyDay(Day day, Timer timer)
        {
            PrintDayTitle(day);
            var taskFullDay = Task.Run(day.Run);
            if (!taskFullDay.Wait(TimeSpan.FromSeconds(PuzzleTimeout)))
                PrintDayError(day);

            PrintDayEnd(timer);
        }

        private static void PrintDayError(Day day)
        {
            Console.WriteLine($"Day {day.Id} {day.Year} failed to finish within {DayTimeout} seconds");
        }

        private static void PrintPuzzle(int part, PuzzleResult puzzleResult)
        {
            Console.WriteLine();
            Console.WriteLine($"Part {part}:");
            Console.WriteLine(puzzleResult.Message);
        }

        private static void PrintDayTitle(Day day)
        {
            Console.WriteLine();
            Console.WriteLine($"Day {day.Id} {day.Year}:");
            Printer.PrintDivider();
        }

        private static void PrintDayEnd(Timer timer)
        {
            Printer.PrintDivider();
            Printer.PrintTime(timer);
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
            var timer = new Timer();

            foreach (var day in days)
            {
                RunWithTimeout(day);
            }

            Printer.PrintDivider();
            var time = Formatter.FormatTimer(timer); 
            Console.WriteLine($"Finished in {time}.");
            Printer.PrintDivider();

            //if (failedDays.Any())
            //{
            //    Console.WriteLine("Failed days");
            //    foreach (var day in failedDays)
            //    {
            //        Console.WriteLine($"Day {day.Id} {day.Year}");
            //    }
            //}
        }

        private static void ShowHelp()
        {
            var helpPrinter = new HelpPrinter();
            helpPrinter.Print();
        }
    }
}
