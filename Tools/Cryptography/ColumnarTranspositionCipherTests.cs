using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Tools.Cryptography;

public class ColumnarTranspositionCipherTests
{
    [Test]
    public void Encrypt() => ColumnarTranspositionCipher
        .Encrypt("GLASS", "WE ARE DISCOVERED FLEE AT ONCE")
        .Should().Be(" DV  NWECEE E ODEOAIEFACRSRLTE");

    [Test]
    public void Decrypt() => ColumnarTranspositionCipher
        .Decrypt("GLASS", " DV  NWECEE E ODEOAIEFACRSRLTE")
        .Should().Be("WE ARE DISCOVERED FLEE AT ONCE");

    [Test]
    public void EncryptSelectionOrderForGlass() => ColumnarTranspositionCipher
        .GetEncryptSelectionOrder("GLASS")
        .Should().BeEquivalentTo([2, 0, 1, 3, 4], options => options.WithStrictOrdering());

    [Test]
    public void DecryptSelectionOrderForGlass() => ColumnarTranspositionCipher
        .GetDecryptSelectionOrder("GLASS")
        .Should().BeEquivalentTo([1, 2, 0, 3, 4], options => options.WithStrictOrdering());

    [Test]
    public void EncryptSelectionOrderForLever() => ColumnarTranspositionCipher
        .GetEncryptSelectionOrder("LEVER")
        .Should().BeEquivalentTo([1, 3, 0, 4, 2], options => options.WithStrictOrdering());

    [Test]
    public void DecryptSelectionOrderForLever() => ColumnarTranspositionCipher
        .GetDecryptSelectionOrder("LEVER")
        .Should().BeEquivalentTo([2, 0, 4, 1, 3], options => options.WithStrictOrdering());
}