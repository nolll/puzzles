using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var parameters = new Parameters(args);

            if(!parameters.WasYearOrDaySpecified)
                parameters = new Parameters(day: 24, year: 2017);

            if (parameters.ShowHelp)
            {
                var helpPrinter = new HelpPrinter();
                helpPrinter.Print();
                return;
            }

            var daySelector = new DaySelector();
            var day = daySelector.GetDay(parameters.Year, parameters.Day);
            if (day == null)
            {
                Console.WriteLine("The specified day could not be found.");
                return;
            }

            day.Run();
        }
    }
}
