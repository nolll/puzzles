namespace Pzl.Euler.Puzzles.Euler059;

public class Euler059Tests
{
    [Theory]
    [InlineData(65, 42, 107)]
    [InlineData(107, 42, 65)]
    public void DecryptInts(int a, int b, int expected) => Euler059.Decrypt(a, b).Should().Be(expected);

    [Theory]
    [InlineData('A', '*', 'k')]
    [InlineData('k', '*', 'A')]
    public void DecryptChars(char a, char b, char expected) => Euler059.Decrypt(a, b).Should().Be(expected);
}