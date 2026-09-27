namespace Tests.Euler.Puzzles.Euler021;

public class Euler021Tests
{
    [Fact]
    public void Test()
    {
        const int a = 220;
        const int b = 284;

        var sumA = Pzl.Euler.Puzzles.Euler021.Euler021.GetFactorialSum(a);
        var sumB = Pzl.Euler.Puzzles.Euler021.Euler021.GetFactorialSum(b);

        sumA.Should().Be(b);
        sumB.Should().Be(a);
    }
}