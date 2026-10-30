using Pzl.Everybody.Puzzles.Ece2026;

namespace Tests.Everybody.Ece2026;

public class Ece202602Tests : PuzzleTest<Ece202602>
{
    [Fact]
    public void Part1()
    {
        const string input = """
                             4<3 2<5 3>1 1>2 1<5 4<1 3>2 4<2 3>5 4<5
                             4>1 2>1 3>2 1<5 4>5 2<5 3>1 4>3 2<4 5<3
                             5>1 5>2 4>1 2<4 3>2 3<4 1>2 3>5 1<3 4>5
                             """;

        Sut.Part1(input).Should().Be(122157);
    }

    [Fact]
    public void Part2()
    {
        const string input = "";

        Sut.Part2(input).Should().Be(0);
    }

    [Fact]
    public void Part3()
    {
        const string input = "";

        Sut.Part3(input).Should().Be(0);
    }
}