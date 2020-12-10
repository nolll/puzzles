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

        private const int Year = 2018;
        private const int Day = 24;

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

        private static void RunDay(Day day)
        {
            var timer = new Timer();
            var part1Result = day.RunPart1();
            if (part1Result != null)
            {
                PrintDayTitle(day);
                PrintPuzzleTitle(1);
                Console.WriteLine(part1Result.Message);
                var part2Result = day.RunPart2();
                if (part2Result != null)
                {
                    PrintPuzzleTitle(2);
                    Console.WriteLine(part2Result.Message);
                }
                PrintDayEnd(timer);
            }
            else
            {
                day.Run();
            }
        }

        private static void RunWithTimeout(Day day)
        {
            var timer = new Timer();
            PuzzleResult part1Result = null;
            var task1 = Task.Run(() => part1Result = day.RunPart1());
            if (task1.Wait(TimeSpan.FromSeconds(PuzzleTimeout)))
            {
                if (part1Result != null)
                {
                    PrintDayTitle(day);
                    PrintPuzzleTitle(1);
                    Console.WriteLine(part1Result.Message);
                    PuzzleResult part2Result = null;
                    var task2 = Task.Run(() => part2Result = day.RunPart2());
                    if (task2.Wait(TimeSpan.FromSeconds(PuzzleTimeout)))
                    {
                        if (part2Result != null)
                        {
                            PrintPuzzleTitle(2);
                            Console.WriteLine(part2Result.Message);
                        }
                        PrintDayEnd(timer);
                    }
                    else
                    {
                        PrintPuzzleError(day, 2);
                    }
                }
                else
                {
                    var taskFullDay = Task.Run(day.Run);
                    if (!taskFullDay.Wait(TimeSpan.FromSeconds(PuzzleTimeout)))
                    {
                        PrintDayError(day);
                    }
                }
            }
            else
            {
                PrintPuzzleError(day, 1);
            }
        }

        private static void PrintDayError(Day day)
        {
            Console.WriteLine($"Day {day.Id} {day.Year} failed to finish within {DayTimeout} seconds");
        }

        private static void PrintPuzzleError(Day day, int puzzle)
        {
            Console.WriteLine($"Day {day.Id} {day.Year} part {puzzle} failed to finish within {PuzzleTimeout} seconds");
        }

        private static void PrintPuzzleTitle(int part)
        {
            Console.WriteLine();
            Console.WriteLine($"Part {part}:");
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
