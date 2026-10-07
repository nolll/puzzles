using Pzl.Aquaq.Puzzles;

namespace Tests.Aquaq;

public class Aquaq32Tests : PuzzleTest<Aquaq32>
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