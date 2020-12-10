using System.Collections.Generic;

namespace ConsoleApp
{
    public class Parameters
    {
        public int? Day { get; }
        public int? Year { get; }
        public bool ShowHelp { get; }
        public bool WasYearOrDaySpecified => Day != null || Year != null;

        public Parameters(IEnumerable<string> args)
        {
            var parser = new ParameterParser(args);
            Day = parser.GetIntValue("-d", "--day");
            Year = parser.GetIntValue("-y", "--year");
            ShowHelp = parser.GetBoolValue("-h", "--help") ?? false;
        }

        public Parameters(int? day = null, int? year = null, bool showHelp = false)
        {
            Day = day;
            Year = year;
            ShowHelp = showHelp;
        }
    }
}