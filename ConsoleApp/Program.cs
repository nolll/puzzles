using System;

namespace ConsoleApp
{
    public class Program
    {
        private static DaySelector _daySelector;
        private const int PuzzleTimeout = 10;

        private const int Year = 2019;
        private const int Day = 2;

        static void Main(string[] args)
        {
            _daySelector = new DaySelector();
            var parameters = Parameters.Parse(args);

            if (parameters.ShowHelp)
            {
                var helpPrinter = new HelpPrinter();
                helpPrinter.Print();
                return;
            }

            if (parameters.RunAll)
            {
                var allDays = _daySelector.GetAll();
                var allRunner = new PuzzleRunner(timeout: PuzzleTimeout);
                allRunner.Run(allDays);
                return;
            }

            if (parameters.Year != null && parameters.Day == null)
            {
                var year = _daySelector.GetEvent(parameters.Year);
                if (year == null)
                    throw new Exception("Event not found!");

                var yearDays = year.Days;
                var yearRunner = new PuzzleRunner(timeout: PuzzleTimeout);
                yearRunner.Run(yearDays);
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

            var dayRunner = new PuzzleRunner(throwExceptions: true);
            dayRunner.Run(day);
        }
    }
}
