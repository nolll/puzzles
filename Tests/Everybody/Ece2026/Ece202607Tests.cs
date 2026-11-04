using Pzl.Everybody.Puzzles.Ece2026;

namespace Tests.Everybody.Ece2026;

public class Ece202607Tests : PuzzleTest<Ece202607>
{
    private const string Input = """
                                 id=1, energy=5, connections=2,5,7
                                 id=2, energy=9, connections=6,7
                                 id=3, energy=3, connections=4
                                 id=4, energy=8, connections=3
                                 id=5, energy=1, connections=6,7
                                 id=6, energy=7, connections=1,7
                                 id=7, energy=6, connections=5
                                 """;

    [Fact]
    public void Part1() => Sut.Part1(Input).Should().Be(102);

    [Fact]
    public void Part2() => Sut.Part2(Input).Should().Be(1316);

    [Fact]
    public void Part3() => Sut.Part3(Input, 100).Should().Be(187);
}