using FluentAssertions;
using NUnit.Framework;

namespace Puzzles.Common.Strings;

public class NumberAsStringTests
{
    [TestCase(1, "one")]
    [TestCase(2, "two")]
    [TestCase(3, "three")]
    [TestCase(4, "four")]
    [TestCase(5, "five")]
    [TestCase(6, "six")]
    [TestCase(7, "seven")]
    [TestCase(8, "eight")]
    [TestCase(9, "nine")]
    [TestCase(10, "ten")]
    [TestCase(11, "eleven")]
    [TestCase(12, "twelve")]
    [TestCase(13, "thirteen")]
    [TestCase(14, "fourteen")]
    [TestCase(15, "fifteen")]
    [TestCase(16, "sixteen")]
    [TestCase(17, "seventeen")]
    [TestCase(18, "eighteen")]
    [TestCase(19, "nineteen")]
    [TestCase(20, "twenty")]
    [TestCase(27, "twentyseven")]
    [TestCase(37, "thirtyseven")]
    [TestCase(47, "fortyseven")]
    [TestCase(57, "fiftyseven")]
    [TestCase(67, "sixtyseven")]
    [TestCase(77, "seventyseven")]
    [TestCase(87, "eightyseven")]
    [TestCase(97, "ninetyseven")]
    [TestCase(107, "one hundred and seven")]
    [TestCase(342, "three hundred and fortytwo")]
    [TestCase(560, "five hundred and sixty")]
    [TestCase(900, "nine hundred")]
    [TestCase(999, "nine hundred and ninetynine")]
    [TestCase(1000, "one thousand")]
    public void ToString_ReturnsCorrectString(int n, string expected)
    {
        var result = new NumberAsString(n).ToString();

        result.Should().Be(expected);
    }
}