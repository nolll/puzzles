using System;

namespace ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var parameters = new Parameters(args);

            if(!parameters.WasYearOrDaySpecified)
                parameters = new Parameters(day: 24, year: 2018);

            if (parameters.ShowHelp)
            {
                ShowHelp();
            }
            else
            {
                RunDay(parameters);
            }
        }

        private static void RunDay(Parameters parameters)
        {
            var daySelector = new DaySelector();
            var day = daySelector.GetDay(parameters.Year, parameters.Day);
            if (day == null)
            {
                Console.WriteLine("The specified day could not be found.");
                return;
            }

            day.Run();
        }

        private static void ShowHelp()
        {
            var helpPrinter = new HelpPrinter();
            helpPrinter.Print();
        }
    }
}
