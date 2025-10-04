namespace Pzl.Tools.Numbers;

public class ConversionTests
{
    [Theory]
    [InlineData(0, "0")]
    [InlineData(1, "1")]
    [InlineData(3, "11")]
    [InlineData(8, "1000")]
    public void ToBinary(int n, string expected) => Conversion.ToBinary(n).Should().Be(expected);

    [Theory]
    [InlineData(1, "I")]
    [InlineData(2, "II")]
    [InlineData(3, "III")]
    [InlineData(4, "IV")]
    [InlineData(5, "V")]
    [InlineData(6, "VI")]
    [InlineData(7, "VII")]
    [InlineData(8, "VIII")]
    [InlineData(9, "IX")]
    [InlineData(10, "X")]
    [InlineData(11, "XI")]
    [InlineData(12, "XII")]
    [InlineData(15, "XV")]
    [InlineData(19, "XIX")]
    [InlineData(20, "XX")]
    [InlineData(41, "XLI")]
    [InlineData(50, "L")]
    [InlineData(99, "XCIX")]
    [InlineData(100, "C")]
    [InlineData(500, "D")]
    [InlineData(1000, "M")]
    [InlineData(2000, "MM")]
    [InlineData(2555, "MMDLV")]
    public void RomanNumbers(int input, string expected) => Conversion.ToRoman(input).Should().Be(expected);
}