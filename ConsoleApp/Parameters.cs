using System.Collections.Generic;

namespace ConsoleApp
{
    public class Parameters
    {
        public int? Day { get; }
        public int? Year { get; }
        public bool RunAll { get; }
        public bool ShowHelp { get; }
        public bool WasYearOrDaySpecified => Day != null || Year != null;

        public Parameters(int? day = null, int? year = null, bool runAll = false, bool showHelp = false)
        {
            Day = day;
            Year = year;
            RunAll = runAll;
            ShowHelp = showHelp;
        }

        public static Parameters Parse(IEnumerable<string> args)
        {
            var parser = new ParameterParser(args);
            var day = parser.GetIntValue("-d", "--day");
            var year = parser.GetIntValue("-y", "--year");
            var runAll = parser.GetBoolValue("-a", "--all") ?? false;
            var showHelp = parser.GetBoolValue("-h", "--help") ?? false;

            return new Parameters(day, year, runAll, showHelp);
        }
    }
}