using FluentAssertions;
using NUnit.Framework;

namespace Puzzles.aquaq.Puzzles.Aquaq37;

public class Aquaq37Tests
{
    [Test]
    public void FindNextWord()
    {
        const string input = """
guess,result
papal,0 2 0 0 0
guess,0 0 0 0 2
twins,0 1 0 0 2
bowls,0 2 1 0 2
worms,2 2 2 0 2
works,2 2 2 0 2
""";

        var result = new Aquaq37().FindWords(input);

        result.First().Should().Be("words");
    }

    [TestCase("a", 0)]
    [TestCase("wordsmince", 113)]
    [TestCase("words", 74)]
    [TestCase("mince", 39)]
    public void WordScore(string input, int expected)
    {
        Aquaq37.GetWordScore(input).Should().Be(expected);
    }
}