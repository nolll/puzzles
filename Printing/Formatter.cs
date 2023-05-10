using System;
using System.Globalization;

namespace Aoc.Printing;

public static class Formatter
{
    public static string FormatTime(TimeSpan timeTaken)
    {
        var seconds = timeTaken.TotalMilliseconds / 1000;
        var decimalSeconds = Convert.ToDecimal(seconds);
        var roundedSeconds = Math.Round(decimalSeconds, 3);
        var secondsString = roundedSeconds.ToString(CultureInfo.InvariantCulture);
        return $"{secondsString}s";
    }
}