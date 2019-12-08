using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var parameters = new Parameters(args);
            if (parameters.ShowHelp)
            {
                var helpPrinter = new HelpPrinter();
                helpPrinter.Print();
                return;
            }

            var daySelector = new DaySelector();
            var day = daySelector.GetDay(parameters.Day);
            if (day == null)
            {
                Console.WriteLine("The specified day could not be found.");
                return;
            }

            day.Run();
        }
    }
}
