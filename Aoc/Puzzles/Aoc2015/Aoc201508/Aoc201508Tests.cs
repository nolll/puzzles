namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201508;

public class Aoc201508Tests
{
    [Fact]
    public void CodeToMemoryDifference()
    {
        const string input = """
                             ""
                             "abc"
                             "aaa\"aaa"
                             "\x27"
                             """;

        var digitalList = new DigitalList(input.Trim());

        digitalList.CodeMinusMemoryDiff.Should().Be(12);
    }

    [Fact]
    public void EncodedToCodeDifference()
    {
        const string input = """
                             ""
                             "abc"
                             "aaa\"aaa"
                             "\x27"
                             """;

        var digitalList = new DigitalList(input.Trim());

        digitalList.EncodedMinusCodeDiff.Should().Be(19);
    }
}