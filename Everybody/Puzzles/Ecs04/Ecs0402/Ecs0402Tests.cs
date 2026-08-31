namespace Pzl.Everybody.Puzzles.Ecs04.Ecs0402;

public class Ecs0402Tests
{
    [Fact]
    public void Part1()
    {
        const string input = """
                             START=[5,0]
                             A=[0,0]
                             B=[10,0]
                             C=[5,10]
                             MOVES=ABCCBABCA
                             """;

        Sut.Part1(input).Should().Be(8);
    }

    [Fact]
    public void Part2()
    {
        const string input = """
                             START=[5,0]
                             A=[0,0]
                             B=[10,0]
                             C=[5,10]
                             MOVES=ABCCBABCA
                             """;

        Sut.Part2(input).Should().Be(25);
    }

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

    private static Ecs0402 Sut => new();
}