using System;
using System.Linq;

namespace Core.Puzzles.Year2022.Day25;

public static class SnafuConverter
{
    public static long ToNumber(string input)
    {
        long sum = 0;
        long multiplier = 1;
        for (var i = input.Length - 1; i >= 0; i--)
        {
            sum += multiplier * ToNumber(input[i]);
            multiplier *= 5;
        }

        return sum;
    }

    private static long ToNumber(char input)
    {
        return input switch
        {
            '2' => 2,
            '1' => 1,
            '-' => -1,
            '=' => -2,
            _ => 0
        };
    }

    public static string ToSnafu(long input)
    {
        var power = FindUpperPower(input);
        var values = new long[power + 1];
        for (var i = 0; i < values.Length; i++)
        {
            values[i] = 2;
        }

        var pos = 0;
        while (Sum(values) > input)
        {
            values[pos]--;

            if (values[pos] < -2 || Sum(values) < input)
            {
                values[pos]++;
                pos++;
                power--;
            }
        }

        return ToSnafu(values);
    }

    private static string ToSnafu(long[] values)
    {
        return string.Join("", values.Select(ToSnafuChar)).TrimStart('0');
    }

    private static char ToSnafuChar(long value)
    {
        return value switch
        {
            2 => '2',
            1 => '1',
            -1 => '-',
            -2 => '=',
            _ => '0'
        };
    }

    private static long Sum(long[] values)
    {
        long sum = 0;
        for (var i = 0; i < values.Length; i++)
        {
            var multiplier = (long)Math.Pow(5, values.Length - i - 1);
            sum += values[i] * multiplier;
        }

        return sum;
    }

    private static int FindUpperPower(long num)
    {
        var power = 0;
        while (true)
        {
            if (num < Math.Pow(5, power) * 2)
                return power;

            power++;
        }
    }
}