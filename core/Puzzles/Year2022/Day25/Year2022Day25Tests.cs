using NUnit.Framework;

namespace Core.Puzzles.Year2022.Day25;

public class Year2022Day25Tests
{
    [Test]
    public void Part1()
    {
        var puzzle = new Year2022Day25();
        var result = puzzle.Part1(Input);

        Assert.That(result, Is.EqualTo("2=-1=0"));
    }

    [Test]
    public void Part2()
    {
        var result = 0;

        Assert.That(result, Is.EqualTo(0));
    }

    [TestCase("1=-0-2", 1747)]
    [TestCase("12111", 906)]
    [TestCase("2=0=", 198)]
    [TestCase("21", 11)]
    [TestCase("2=01", 201)]
    [TestCase("111", 31)]
    [TestCase("20012", 1257)]
    [TestCase("112", 32)]
    [TestCase("1=-1=", 353)]
    [TestCase("1-12", 107)]
    [TestCase("12", 7)]
    [TestCase("1=", 3)]
    [TestCase("122", 37)]
    public void ToDecimal(string input, int expected)
    {
        var result = SnafuConverter.ToInt(input);

        Assert.That(result, Is.EqualTo(expected));
    }

    private const string Input = """
1=-0-2
12111
2=0=
21
2=01
111
20012
112
1=-1=
1-12
12
1=
122
""";
}

public static class SnafuConverter
{
    public static int ToInt(string input)
    {
        var sum = 0;
        var multiplier = 1;
        for (var i = input.Length - 1; i >= 0; i--)
        {
            sum += multiplier * ToInt(input[i]);
            multiplier *= 5;
        }

        return sum;
    }

    private static int ToInt(char input)
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

    public static string ToSnafu(int input)
    {
        return "";
    }
}