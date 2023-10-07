using NUnit.Framework;

namespace Aquaq.Puzzles.Aquaq22;

public class Aquaq22Tests
{
    [Test]
    public void CaesarCipher()
    {
        var result = Aquaq22.ToCaesarCipherSum("IVXLCDM");

        Assert.That(result, Is.EqualTo(87));
    }
}