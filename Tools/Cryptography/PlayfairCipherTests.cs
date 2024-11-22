using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Tools.Cryptography;

public class PlayfairCipherTests
{
    [Test]
    public void CreateStringBoard()
    {
        const string expected = "playfirbcdeghkmnoqstuvwxz";

        var result = new PlayfairCipher("play fair").CreateStringCipherBoard();

        result.Should().Be(expected);
    }

    [Test]
    public void Encrypt()
    {
        var result = new PlayfairCipher("play fair").Encrypt("flawless");

        result.Should().Be("pabapgxyxy");
    }

    [Test]
    public void Decrypt()
    {
        var result = new PlayfairCipher("play fair").Decrypt("pabapgxyxy");

        result.Should().Be("flawlesxsx");
    }
}