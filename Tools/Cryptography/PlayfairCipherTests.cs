using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Tools.Cryptography;

public class PlayfairCipherTests
{
    [Test]
    public void CreateStringBoard() => new PlayfairCipher("play fair")
        .CreateStringCipherBoard()
        .Should().Be("playfirbcdeghkmnoqstuvwxz");

    [Test]
    public void Encrypt() => new PlayfairCipher("play fair")
        .Encrypt("flawless")
        .Should().Be("pabapgxyxy");

    [Test]
    public void Decrypt() => new PlayfairCipher("play fair")
        .Decrypt("pabapgxyxy")
        .Should().Be("flawlesxsx");
}