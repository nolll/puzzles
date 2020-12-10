using System;
using System.Globalization;
using Core.Tools;

namespace ConsoleApp.Years
{
    public static class Formatter
    {
        public static string FormatTimer(Timer timer)
        {
            var timeTaken = timer.FromStart;
            var seconds = timeTaken.TotalMilliseconds / 1000;
            var decimalSeconds = Convert.ToDecimal(seconds);
            var roundedSeconds = Math.Round(decimalSeconds, 2);
            var secondsString = roundedSeconds.ToString(CultureInfo.InvariantCulture);
            return $"{secondsString}s";
        }
    }
}