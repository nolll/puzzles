using Pzl.Aoc.Puzzles.Aoc2017;

namespace Tests.Aoc.Aoc2017;

public class Aoc201702Tests : PuzzleTest<Aoc201702>
{
    [Fact]
    public void ChecksumMaxMinIsCorrect()
    {
        const string input = """
                             5 1 9 5
                             7 5 3
                             2 4 6 8
                             """;

        Sut.Part1(input).Should().Be(18);
    }

    [Fact]
    public void ChecksumDivisionIsCorrect()
    {
        const string input = """
                             5 9 2 8
                             9 4 7 3
                             3 8 6 5
                             """;

        Sut.Part2(input).Should().Be(9);
    }
}