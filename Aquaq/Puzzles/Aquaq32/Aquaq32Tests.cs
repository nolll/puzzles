using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aquaq.Puzzles.Aquaq32;

public class Aquaq32Tests
{
    [TestCase("()", true)]
    [TestCase("([]{})", true)]
    [TestCase("(a[b[]]c){}", true)]
    [TestCase(")()", false)]
    [TestCase("([a)]", false)]
    [TestCase("]{}[", false)]
    [TestCase("((a)){]", false)]
    public void IsBalanced(string input, bool expected)
    {
        var result = Aquaq32.IsBalanced(input);

        result.Should().Be(expected);
    }
}