using Pzl.Everybody.Puzzles.Ecs02;

namespace Tests.Everybody.Ecs02;

public class Ecs0202Tests : PuzzleTest<Ecs0202>
{
    [Fact]
    public void Part1() => Sut.Part1("GRBGGGBBBRRRRRRRR").Should().Be(7);

    [Fact]
    public void Part2And3() => Sut.Part2And3("GGBR", 5).Should().Be(14);
}