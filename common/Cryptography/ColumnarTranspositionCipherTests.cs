using FluentAssertions;
using NUnit.Framework;

namespace Puzzles.common.Cryptography;

public class ColumnarTranspositionCipherTests
{
    [Test]
    public void Encrypt()
    {
        var result = ColumnarTranspositionCipher.Encrypt("GLASS", "WE ARE DISCOVERED FLEE AT ONCE");

        result.Should().Be(" DV  NWECEE E ODEOAIEFACRSRLTE");
    }

    [Test]
    public void Decrypt()
    {
        var result = ColumnarTranspositionCipher.Decrypt("GLASS", " DV  NWECEE E ODEOAIEFACRSRLTE");

        result.Should().Be("WE ARE DISCOVERED FLEE AT ONCE");
    }

    [Test]
    public void EncryptSelectionOrderForGlass()
    {
        var result = ColumnarTranspositionCipher.GetEncryptSelectionOrder("GLASS");

        result.Should().BeEquivalentTo(new[] { 2, 0, 1, 3, 4 }, options => options.WithStrictOrdering());
    }

    [Test]
    public void DecryptSelectionOrderForGlass()
    {
        var result = ColumnarTranspositionCipher.GetDecryptSelectionOrder("GLASS");

        result.Should().BeEquivalentTo(new[] { 1, 2, 0, 3, 4 }, options => options.WithStrictOrdering());
    }

    [Test]
    public void EncryptSelectionOrderForLever()
    {
        var result = ColumnarTranspositionCipher.GetEncryptSelectionOrder("LEVER");

        result.Should().BeEquivalentTo(new[] { 1, 3, 0, 4, 2 }, options => options.WithStrictOrdering());
    }

    [Test]
    public void DecryptSelectionOrderForLever()
    {
        var result = ColumnarTranspositionCipher.GetDecryptSelectionOrder("LEVER");

        result.Should().BeEquivalentTo(new[] { 2, 0, 4, 1, 3 }, options => options.WithStrictOrdering());
    }
}