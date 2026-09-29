using Pzl.Aoc.Puzzles.Aoc2015;

namespace Tests.Aoc.Aoc2015;

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
        
        Sut.Part1(input).Should().Be(12);
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

        Sut.Part2(input).Should().Be(19);
    }

    private static Aoc201508 Sut => new();
}