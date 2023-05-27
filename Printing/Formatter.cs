using System;
using System.Globalization;

namespace Aoc.Printing;

public static class Formatter
{
    public static string FormatTime(TimeSpan timeTaken, int decimals = 3)
    {
        var seconds = timeTaken.TotalMilliseconds / 1000;
        var decimalSeconds = Convert.ToDecimal(seconds);
        var roundedSeconds = Math.Round(decimalSeconds, decimals);
        var secondsString = roundedSeconds.ToString(CultureInfo.InvariantCulture);
        return $"{secondsString}s";
    }
}