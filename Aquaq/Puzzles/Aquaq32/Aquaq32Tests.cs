using FluentAssertions;

namespace Pzl.Aquaq.Puzzles.Aquaq32;

public class Aquaq32Tests
{
    [Theory]
    [InlineData("()", true)]
    [InlineData("([]{})", true)]
    [InlineData("(a[b[]]c){}", true)]
    [InlineData(")()", false)]
    [InlineData("([a)]", false)]
    [InlineData("]{}[", false)]
    [InlineData("((a)){]", false)]
    public void IsBalanced(string input, bool expected)
    {
        var result = Aquaq32.IsBalanced(input);

        result.Should().Be(expected);
    }
}