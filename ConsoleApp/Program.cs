using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Program
    {
        private static DaySelector _daySelector;
        private const int DayTimeout = 1;

        static void Main(string[] args)
        {
            _daySelector = new DaySelector();
            var parameters = Parameters.Parse(args);

            if (parameters.ShowHelp)
            {
                ShowHelp();
            }
            else if (parameters.RunAll)
            {
                RunAll();
            }
            else
            {
                if (!parameters.WasYearOrDaySpecified)
                    parameters = new Parameters(day: 24, year: 2018);

                RunDay(parameters);
            }
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

        private static void RunAll()
        {
            var days = _daySelector.GetAll();
            foreach (var day in days)
            {
                var task = Task.Run(() => day.Run());
                if (!task.Wait(TimeSpan.FromSeconds(DayTimeout)))
                    Console.WriteLine("This day was too slow");
            }
        }

        private static void ShowHelp()
        {
            var helpPrinter = new HelpPrinter();
            helpPrinter.Print();
        }
    }
}
