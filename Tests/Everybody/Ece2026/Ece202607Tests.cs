using Pzl.Everybody.Puzzles.Ece2026;

namespace Tests.Everybody.Ece2026;

public class Ece202607Tests : PuzzleTest<Ece202607>
{
    [Fact]
    public void Part1()
    {
        const string input = """
                             id=1, energy=5, connections=2,5,7
                             id=2, energy=9, connections=6,7
                             id=3, energy=3, connections=4
                             id=4, energy=8, connections=3
                             id=5, energy=1, connections=6,7
                             id=6, energy=7, connections=1,7
                             id=7, energy=6, connections=5
                             """;

        Sut.Part1(input).Should().Be(102);
    }

    [Fact]
    public void Part2()
    {
        const string input = """
                             id=1, energy=5, connections=2,5,7
                             id=2, energy=9, connections=6,7
                             id=3, energy=3, connections=4
                             id=4, energy=8, connections=3
                             id=5, energy=1, connections=6,7
                             id=6, energy=7, connections=1,7
                             id=7, energy=6, connections=5
                             """;

        Sut.Part2(input).Should().Be(1316);
    }

    [Fact]
    public void Part3()
    {
        const string input = """
                             id=1, energy=5, connections=2,5,7
                             id=2, energy=9, connections=6,7
                             id=3, energy=3, connections=4
                             id=4, energy=8, connections=3
                             id=5, energy=1, connections=6,7
                             id=6, energy=7, connections=1,7
                             id=7, energy=6, connections=5
                             """;

        Sut.Part3(input, 100).Should().Be(187);
    }
}