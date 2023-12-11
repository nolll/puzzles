using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aquaq.Puzzles.Aquaq37;

public class Aquaq37Tests
{
    private const string WordsInput = """
                                      guess,result
                                      guess,0 0 0 0 2
                                      twins,0 1 0 0 2
                                      bowls,0 2 1 0 2
                                      worms,2 2 2 0 2
                                      works,2 2 2 0 2
                                      """;

    private const string MajorInput = """
                                      guess,result
                                      papal,0 2 0 0 0
                                      cacti,0 2 0 0 0
                                      bauds,0 2 0 0 0
                                      ragee,1 2 0 0 0
                                      marry,2 2 1 0 0
                                      manor,2 2 0 2 2
                                      """;

    private const string StoryInput = """
                                      guess,result
                                      yills,1 0 0 0 1
                                      mousy,0 1 0 1 2
                                      savoy,2 0 0 1 2
                                      showy,2 0 2 0 2
                                      stony,2 2 2 0 2
                                      stogy,2 2 2 0 2
                                      """;

    private const string BeganInput = """
                                      guess,result
                                      jotas,0 0 0 2 0
                                      redan,0 2 0 2 2
                                      leman,0 2 0 2 2
                                      vegan,0 2 2 2 2
                                      """;

    private const string ThereInput = """
                                      guess,result
                                      buxom,0 0 0 0 0
                                      three,2 2 1 1 2
                                      """;

    private const string PriorInput = """
                                      guess,result
                                      short,0 0 1 1 0
                                      oiler,1 1 0 0 2
                                      """;

    private const string UnderInput = """
                                      guess,result
                                      scend,0 0 1 1 1
                                      bendy,0 1 1 1 0
                                      endue,1 2 2 1 0
                                      """;

    private const string GroupInput = """
                                      guess,result
                                      tabes,0 0 0 0 0
                                      hying,0 0 0 0 1
                                      doggo,0 1 1 0 0
                                      growl,2 2 2 0 0
                                      """;

    [TestCase(WordsInput, "words")]
    [TestCase(MajorInput, "major")]
    [TestCase(StoryInput, "story")]
    [TestCase(BeganInput, "began")]
    [TestCase(ThereInput, "there")]
    [TestCase(PriorInput, "prior")]
    [TestCase(UnderInput, "under")]
    [TestCase(GroupInput, "group")]
    public void FindWords(string input, string expected)
    {
        var result = new Aquaq37(input, "").FindWords(input);

        result.FirstOrDefault().Should().Be(expected);
    }

    [Test]
    public void MajorMarry()
    {
        var guess = new Aquaq37.Guess("marry", new[] { 2, 2, 1, 0, 0 });
        var result = guess.IsMatch("major");

        result.Should().BeTrue();
    }

    [Test]
    public void GroomDoggo()
    {
        var guess = new Aquaq37.Guess("doggo", new[] { 0, 1, 1, 0, 0 });
        var result = guess.IsMatch("groom");

        result.Should().BeFalse();
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