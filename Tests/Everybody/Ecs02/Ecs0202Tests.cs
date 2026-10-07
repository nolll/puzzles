using Pzl.Everybody.Puzzles.Ecs02;

namespace Tests.Everybody.Ecs02;

public class Ecs0202Tests : PuzzleTest<Ecs0202>
{
    [Fact]
    public void Part1()
    {
        const string input = "GRBGGGBBBRRRRRRRR";

        Sut.Part1(input).Should().Be(7);
    }

    [Fact]
    public void Part2And3()
    {
        const string input = "GGBR";

        Ecs0202.Part2And3(input, 5).Should().Be(14);
    }

}