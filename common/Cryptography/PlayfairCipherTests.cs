using NUnit.Framework;

namespace Common.Cryptography;

public class PlayfairCipherTests
{
    [Test]
    public void CreateStringBoard()
    {
        const string expected = "playfirbcdeghkmnoqstuvwxz";

        var result = new PlayfairCipher("play fair").CreateStringCipherBoard();

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Encrypt()
    {
        var result = new PlayfairCipher("play fair").Encrypt("flawless");

        Assert.That(result, Is.EqualTo("pabapgxyxy"));
    }

    [Test]
    public void Decrypt()
    {
        var result = new PlayfairCipher("play fair").Decrypt("pabapgxyxy");

        Assert.That(result, Is.EqualTo("flawlesxsx"));
    }
}