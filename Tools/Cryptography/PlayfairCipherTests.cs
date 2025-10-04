namespace Pzl.Tools.Cryptography;

public class PlayfairCipherTests
{
    [Fact]
    public void CreateStringBoard() => new PlayfairCipher("play fair")
        .CreateStringCipherBoard()
        .Should().Be("playfirbcdeghkmnoqstuvwxz");

    [Fact]
    public void Encrypt() => new PlayfairCipher("play fair")
        .Encrypt("flawless")
        .Should().Be("pabapgxyxy");

    [Fact]
    public void Decrypt() => new PlayfairCipher("play fair")
        .Decrypt("pabapgxyxy")
        .Should().Be("flawlesxsx");
}