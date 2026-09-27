using System.Numerics;

namespace Tests.Aquaq;

public class Aquaq26Tests
{
    [Theory]
    [InlineData("1423", "1432")]
    [InlineData("121", "211")]
    [InlineData("10290", "10902")]
    [InlineData("4321", "4321")]
    public void FindFirstLargestNumber(string input, string expected) => 
        Pzl.Aquaq.Puzzles.Aquaq26.Aquaq26.FindFirstLargerNumber(BigInteger.Parse(input))
            .Should().Be(BigInteger.Parse(expected));
}