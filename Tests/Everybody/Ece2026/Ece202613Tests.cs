using Pzl.Everybody.Puzzles.Ece2026;

namespace Tests.Everybody.Ece2026;

public class Ece202613Tests : PuzzleTest<Ece202613>
{
    [Fact]
    public void Part1_1()
    {
        const string input = """
                             hands 6:8:12
                             direction CW:CCW:CW
                             current 2:4:8
                             move 9:7:4
                             """;

        Sut.Part1(input).Should().Be(5);
    }
    
    [Fact]
    public void Part1_2()
    {
        const string input = """
                             hands 6:8:12
                             direction CW:CCW:CW
                             current 1:2:2
                             move 10:12:15
                             """;

        Sut.Part1(input).Should().Be(7);
    }
    
    [Fact]
    public void Part1_3()
    {
        const string input = """
                             hands 6:8:12
                             direction CW:CCW:CW
                             current 1:2:2
                             move 10:12:20
                             """;

        Sut.Part1(input).Should().Be(9);
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