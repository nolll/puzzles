using NUnit.Framework;

namespace Euler.Common.Numbers;

public class ConversionTests
{
    [TestCase(0, "0")]
    [TestCase(1, "1")]
    [TestCase(3, "11")]
    [TestCase(8, "1000")]
    public void ToBinary(int n, string expected)
    {
        var result = Conversion.ToBinary(n);

        Assert.That(result, Is.EqualTo(expected));
    }
}