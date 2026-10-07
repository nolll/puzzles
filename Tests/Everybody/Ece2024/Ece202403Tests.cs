using Pzl.Everybody.Puzzles.Ece2024;

namespace Tests.Everybody.Ece2024;

public class Ece202403Tests : PuzzleTest<Ece202403>
{
    private const string Input = """
                                 ..........
                                 ..###.##..
                                 ...####...
                                 ..######..
                                 ..######..
                                 ...####...
                                 ..........
                                 """;

    [Fact]
    public void Part1And2() => Sut.Part1(Input).Should().Be(35);

    [Fact]
    public void Part3() => Sut.Part3(Input).Should().Be(29);

}