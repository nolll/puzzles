using System;
using System.Globalization;

namespace ConsoleApp.Printing
{
    public static class Formatter
    {
        public static string FormatTime(TimeSpan timeTaken)
        {
            var seconds = timeTaken.TotalMilliseconds / 1000;
            var decimalSeconds = Convert.ToDecimal(seconds);
            var roundedSeconds = Math.Round(decimalSeconds, 2);
            var secondsString = roundedSeconds.ToString(CultureInfo.InvariantCulture);
            return $"{secondsString}s";
        }
    }
}