namespace Tests.Euler.Puzzles.Euler059;

public class Euler059Tests
{
    [Theory]
    [InlineData(65, 42, 107)]
    [InlineData(107, 42, 65)]
    public void DecryptInts(int a, int b, int expected) => Pzl.Euler.Puzzles.Euler059.Euler059.Decrypt(a, b).Should().Be(expected);

    [Theory]
    [InlineData('A', '*', 'k')]
    [InlineData('k', '*', 'A')]
    public void DecryptChars(char a, char b, char expected) => Pzl.Euler.Puzzles.Euler059.Euler059.Decrypt(a, b).Should().Be(expected);
}