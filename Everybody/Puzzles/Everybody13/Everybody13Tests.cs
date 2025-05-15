using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Everybody.Puzzles.Everybody13;

public class Everybody13Tests
{
    [Test]
    public void Part1()
    {
        const string input = """
                             #######
                             #6769##
                             S50505E
                             #97434#
                             #######
                             """;

        Sut.Part1(input).Answer.Should().Be("28");
    }
    
    [TestCase(0, 0, 0)]
    [TestCase(1, 2, 1)]
    [TestCase(1, 9, 2)]
    [TestCase(9, 1, 2)]
    public void Cost(int a, int b, int expected)
    {
        Everybody13.GetCost(a, b).Should().Be(expected);
    }
    
    [Test]
    public void Part3()
    {
        const string input = """
                             SSSSSSSSSSS
                             S674345621S
                             S###6#4#18S
                             S53#6#4532S
                             S5450E0485S
                             S##7154532S
                             S2##314#18S
                             S971595#34S
                             SSSSSSSSSSS
                             """;

        Sut.Part3(input).Answer.Should().Be("14");
    }

    private static Everybody13 Sut => new();
}