namespace Pzl.Tools.Strings;

public class NumberAsStringTests
{
    [Theory]
    [InlineData(1, "one")]
    [InlineData(2, "two")]
    [InlineData(3, "three")]
    [InlineData(4, "four")]
    [InlineData(5, "five")]
    [InlineData(6, "six")]
    [InlineData(7, "seven")]
    [InlineData(8, "eight")]
    [InlineData(9, "nine")]
    [InlineData(10, "ten")]
    [InlineData(11, "eleven")]
    [InlineData(12, "twelve")]
    [InlineData(13, "thirteen")]
    [InlineData(14, "fourteen")]
    [InlineData(15, "fifteen")]
    [InlineData(16, "sixteen")]
    [InlineData(17, "seventeen")]
    [InlineData(18, "eighteen")]
    [InlineData(19, "nineteen")]
    [InlineData(20, "twenty")]
    [InlineData(27, "twentyseven")]
    [InlineData(37, "thirtyseven")]
    [InlineData(47, "fortyseven")]
    [InlineData(57, "fiftyseven")]
    [InlineData(67, "sixtyseven")]
    [InlineData(77, "seventyseven")]
    [InlineData(87, "eightyseven")]
    [InlineData(97, "ninetyseven")]
    [InlineData(107, "one hundred and seven")]
    [InlineData(342, "three hundred and fortytwo")]
    [InlineData(560, "five hundred and sixty")]
    [InlineData(900, "nine hundred")]
    [InlineData(999, "nine hundred and ninetynine")]
    [InlineData(1000, "one thousand")]
    public void ToString_ReturnsCorrectString(int n, string expected) =>
        new NumberAsString(n).ToString()
            .Should().Be(expected);
}