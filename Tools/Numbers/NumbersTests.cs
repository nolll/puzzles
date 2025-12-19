namespace Pzl.Tools.Numbers;

public class NumbersTests
{
    [Theory]
    [InlineData(1, false)]
    [InlineData(2, true)]
    [InlineData(3, true)]
    [InlineData(4, false)]
    [InlineData(5, true)]
    [InlineData(6, false)]
    [InlineData(7, true)]
    [InlineData(8, false)]
    [InlineData(9, false)]
    [InlineData(10, false)]
    [InlineData(11, true)]
    [InlineData(12, false)]
    public void IsPrime(int n, bool expected) => Numbers.IsPrime(n).Should().Be(expected);

    [Theory]
    [InlineData(13195, 29)]
    [InlineData(14, 7)]
    public void LargestPrimeFactors(int n, int expected) => Numbers.LargestPrimeFactor(n).Should().Be(expected);

    [Theory]
    [InlineData(1, 1)]
    [InlineData(3, 2)]
    [InlineData(6, 4)]
    [InlineData(10, 4)]
    [InlineData(15, 4)]
    [InlineData(21, 4)]
    [InlineData(28, 6)]
    public void Factors(int n, int expected) => Numbers.GetAllDivisors(n).Count().Should().Be(expected);

    [Theory]
    [InlineData(1234567890, false)]
    [InlineData(1235, false)]
    [InlineData(1233, false)]
    [InlineData(1234, true)]
    public void IsPandigital1Through9(long n, bool expected) => Numbers.IsPandigital1Through9(n).Should().Be(expected);

    [Theory]
    [InlineData(12345678901, false)]
    [InlineData(1234567890, true)]
    [InlineData(1234, false)]
    [InlineData(1233, false)]
    [InlineData(12340, true)]
    public void IsPandigital0Through9(long n, bool expected) => Numbers.IsPandigital0Through9(n).Should().Be(expected);

    [Theory]
    [InlineData(1, 1)]
    [InlineData(2, 3)]
    [InlineData(3, 6)]
    [InlineData(4, 10)]
    [InlineData(5, 15)]
    public void GetTriangularNumber(int n, long expected) => Numbers.GetTriangularNumber(n).Should().Be(expected);

    [Theory]
    [InlineData(1, true)]
    [InlineData(3, true)]
    [InlineData(6, true)]
    [InlineData(10, true)]
    [InlineData(15, true)]
    [InlineData(16, false)]
    public void IsTriangularNumber(int n, bool expected) => Numbers.IsTriangularNumber(n).Should().Be(expected);

    [Theory]
    [InlineData(1, 1)]
    [InlineData(2, 5)]
    [InlineData(3, 12)]
    [InlineData(4, 22)]
    [InlineData(5, 35)]
    public void GetPentagonalNumber(int n, long expected) => Numbers.GetPentagonalNumber(n).Should().Be(expected);

    [Theory]
    [InlineData(1, true)]
    [InlineData(5, true)]
    [InlineData(12, true)]
    [InlineData(22, true)]
    [InlineData(35, true)]
    [InlineData(36, false)]
    public void IsPentagonalNumber(int n, bool expected) => Numbers.IsPentagonalNumber(n).Should().Be(expected);

    [Theory]
    [InlineData(1, 1)]
    [InlineData(2, 6)]
    [InlineData(3, 15)]
    [InlineData(4, 28)]
    [InlineData(5, 45)]
    public void GetHexagonalNumber(int n, long expected) => Numbers.GetHexagonalNumber(n).Should().Be(expected);

    [Theory]
    [InlineData(1, true)]
    [InlineData(6, true)]
    [InlineData(15, true)]
    [InlineData(28, true)]
    [InlineData(45, true)]
    [InlineData(46, false)]
    public void IsHexagonalNumber(int n, bool expected) => Numbers.IsHexagonalNumber(n).Should().Be(expected);

    [Fact]
    public void IntsFromString() => 
        Numbers.IntsFromString("abc123def456ghi").Should().BeEquivalentTo((int[])[123, 456]);
    
    [Theory]
    [InlineData(6, 1)]
    [InlineData(28, 2)]
    [InlineData(46456, 5)]
    public void CountDigits(int n, int expected) => Numbers.NumDigits(n).Should().Be(expected);
    
    [Theory]
    [InlineData(6, 3, 63)]
    [InlineData(28, 84, 2884)]
    [InlineData(46456, 54, 4645654)]
    public void ConcatInts(int a, int b, int expected) => Numbers.Concat([a, b]).Should().Be(expected);
    
    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 1)]
    [InlineData(2, 1)]
    [InlineData(3, 2)]
    [InlineData(4, 3)]
    [InlineData(5, 5)]
    [InlineData(6, 8)]
    [InlineData(7, 13)]
    [InlineData(8, 21)]
    [InlineData(9, 34)]
    [InlineData(10, 55)]
    [InlineData(20, 6765)]
    [InlineData(100, 3736710778780434371)]
    public void Fibonacci(long input, long expected) => Numbers.Fibonacci(input).Should().Be(expected);
}