using FluentAssertions;
using NUnit.Framework;

namespace Common.Cryptography;

public class ColumnarTranspositionCipherTests
{
    [Test]
    public void Encrypt()
    {
        var result = ColumnarTranspositionCipher.Encrypt("GLASS", "WE ARE DISCOVERED FLEE AT ONCE");

        result.Should().Be(" DV  NWECEE E ODEOAIEFACRSRLTE");
    }
}