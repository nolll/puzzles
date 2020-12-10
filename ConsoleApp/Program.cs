using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleApp.Years;
using Core.Tools;

namespace ConsoleApp
{
    public class Program
    {
        private static DaySelector _daySelector;
        private const int DayTimeout = 10;

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

            day.Run();
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
            var failedDays = new List<Day>();
            var timer = new Timer();

            foreach (var day in days)
            {
                var task = Task.Run(() => day.Run());
                if (!task.Wait(TimeSpan.FromSeconds(DayTimeout)))
                {
                    failedDays.Add(day);
                    Console.WriteLine($"Day {day.Id} {day.Year} failed to finish within {DayTimeout} seconds");
                }
            }

            Printer.PrintDivider();
            var time = Formatter.FormatTimer(timer); 
            Console.WriteLine($"Finished in {time}.");
            Printer.PrintDivider();

            if (failedDays.Any())
            {
                Console.WriteLine("Failed days");
                foreach (var day in failedDays)
                {
                    Console.WriteLine($"Day {day.Id} {day.Year}");
                }
            }
        }

        private static void ShowHelp()
        {
            var helpPrinter = new HelpPrinter();
            helpPrinter.Print();
        }
    }
}
