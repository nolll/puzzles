namespace Pzl.Everybody.Puzzles.Ece2024.Ece202403;

public class Ece202403Tests
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

    private static Ece202403 Sut => new();
}