using Pzl.Everybody.Puzzles.Ecs04;

namespace Tests.Everybody.Ecs04;

public class Ecs0402Tests : PuzzleTest<Ecs0402>
{
    private const string Input = """
                                 START=[5,0]
                                 A=[0,0]
                                 B=[10,0]
                                 C=[5,10]
                                 MOVES=ABCCBABCA
                                 """;

    [Fact]
    public void Part1() => Sut.Part1(Input).Should().Be(8);

    [Fact]
    public void Part2() => Sut.Part2(Input).Should().Be(25);

    [Fact]
    public void Part3()
    {
        const string input = """
                             START=[5,0]
                             A=[0,0]
                             B=[10,0]
                             C=[5,10]
                             """;

        Sut.Part3(input).Should().Be(42);
    }

}