namespace Pzl.Tools.Cryptography;

public class CaesarCipherTests
{
    [Theory]
    [InlineData('A', 1)]
    [InlineData('B', 2)]
    [InlineData('C', 3)]
    [InlineData('D', 4)]
    [InlineData('E', 5)]
    [InlineData('F', 6)]
    [InlineData('G', 7)]
    [InlineData('H', 8)]
    [InlineData('I', 9)]
    [InlineData('J', 10)]
    [InlineData('K', 11)]
    [InlineData('L', 12)]
    [InlineData('M', 13)]
    [InlineData('N', 14)]
    [InlineData('O', 15)]
    [InlineData('P', 16)]
    [InlineData('Q', 17)]
    [InlineData('R', 18)]
    [InlineData('S', 19)]
    [InlineData('T', 20)]
    [InlineData('U', 21)]
    [InlineData('V', 22)]
    [InlineData('W', 23)]
    [InlineData('X', 24)]
    [InlineData('Y', 25)]
    [InlineData('Z', 26)]
    public void Encrypt(char input, int expected) => CaesarCipher.Encrypt(input).Should().Be(expected);
}