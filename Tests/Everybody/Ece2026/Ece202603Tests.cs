using Pzl.Everybody.Puzzles.Ece2026;

namespace Tests.Everybody.Ece2026;

public class Ece202603Tests : PuzzleTest<Ece202603>
{
    [Fact]
    public void Part1()
    {
        const string input = """
                             ISO-3210 7654
                             ISO-8742 2468
                             ISO-1111 1111
                             """;

        Sut.Part1(input).Should().Be(1478);
    }

    [Fact]
    public void Part2()
    {
        const string input = """
                             ISO-3210 7654
                             ISO-8742 2468
                             ISO-1 1111
                             ISO-13 777
                             ISO-34 140856
                             ISO-789 2465112
                             ISO-2341 945
                             """;

        Sut.Part2(input).Should().Be(1161463);
    }

    [Fact]
    public void Part3()
    {
        const string input = """
                             ISO2-3 23
                             ISO2-61 149
                             ISO2-978 99
                             ISO2-5887 5923
                             ISO2-76988 123749
                             ISO2-435657 929977
                             ISO2-3949 870737
                             """;

        Sut.Part3(input).Should().Be(50987);
    }
}