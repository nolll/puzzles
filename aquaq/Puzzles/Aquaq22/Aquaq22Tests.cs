using NUnit.Framework;

namespace Aquaq.Puzzles.Aquaq22;

public class Aquaq22Tests
{
    [TestCase(1, "I")]
    [TestCase(2, "II")]
    [TestCase(3, "III")]
    [TestCase(4, "IV")]
    [TestCase(5, "V")]
    [TestCase(6, "VI")]
    [TestCase(7, "VII")]
    [TestCase(8, "VIII")]
    [TestCase(9, "IX")]
    [TestCase(10, "X")]
    [TestCase(11, "XI")]
    [TestCase(12, "XII")]
    [TestCase(15, "XV")]
    [TestCase(19, "XIX")]
    [TestCase(20, "XX")]
    [TestCase(41, "XLI")]
    [TestCase(50, "L")]
    [TestCase(99, "XCIX")]
    [TestCase(100, "C")]
    [TestCase(500, "D")]
    [TestCase(1000, "M")]
    [TestCase(2000, "MM")]
    [TestCase(2555, "MMDLV")]
    public void RomanNumbers(int input, string expected)
    {
        var result = Aquaq22.ToRoman(input);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void CaesarCipher()
    {
        var result = Aquaq22.ToCaesarCipher("IVXLCDM");

        Assert.That(result, Is.EqualTo(87));
    }
}