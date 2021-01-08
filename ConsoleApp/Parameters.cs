using System.Collections.Generic;

namespace ConsoleApp
{
    public class Parameters
    {
        public int? Day { get; }
        public int? Year { get; }
        public bool RunSlowOnly { get; }
        public bool ShowHelp { get; }

        public Parameters(int? day = null, int? year = null, bool runSlowOnly = false, bool showHelp = false)
        {
            Day = day;
            Year = year;
            RunSlowOnly = runSlowOnly;
            ShowHelp = showHelp;
        }

        public static Parameters Parse(IEnumerable<string> args)
        {
            var parser = new ParameterParser(args);
            var day = parser.GetIntValue("-d", "--day");
            var year = parser.GetIntValue("-y", "--year");
            var runAll = parser.GetBoolValue("-s", "--slow") ?? false;
            var showHelp = parser.GetBoolValue("-h", "--help") ?? false;

            return new Parameters(day, year, runAll, showHelp);
        }
    }
}