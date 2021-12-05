using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApp.Years;

namespace ConsoleApp
{
    public class Program
    {
        private static DaySelector _daySelector;
        private const int PuzzleTimeout = 10;

        private const int DebugYear = 2019;
        private const int DebugDay = 22;

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

            if (parameters.Year != null && parameters.Day == null)
            {
                var @event = _daySelector.GetEvent(parameters.Year);
                if (@event == null)
                    throw new Exception("Event not found!");

                var eventDays = @event.Days;
                var filteredDays = FilterDays(eventDays, parameters);
                var runner = new PuzzleRunner(timeout: PuzzleTimeout);
                runner.Run(filteredDays);
                return;
            }

            if (parameters.Year == null && parameters.Day == null)
            {
#if SINGLE
                parameters = new Parameters(day: DebugDay, year: DebugYear);
#else
                var allDays = _daySelector.GetAll();
                var filteredDays = FilterDays(allDays, parameters);
                var allRunner = new PuzzleRunner(timeout: PuzzleTimeout);
                allRunner.Run(filteredDays);
                return;
#endif
            }

            var day = _daySelector.GetDay(parameters.Year, parameters.Day);
            if (day == null)
            {
                throw new Exception("The specified day could not be found.");
            }

            var dayRunner = new PuzzleRunner(throwExceptions: true);
            dayRunner.Run(day);
        }

        private static IList<Day> FilterDays(IList<Day> days, Parameters parameters)
        {
            if (parameters.RunSlowOnly)
                return days.Where(o => o.IsSlow).ToList();

            if (parameters.RunCommentedOnly)
                return days.Where(o => !string.IsNullOrEmpty(o.Comment)).ToList();

            return days;
        }
    }
}
