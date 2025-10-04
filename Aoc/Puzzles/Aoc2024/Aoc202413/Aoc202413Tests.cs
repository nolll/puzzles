namespace Pzl.Aoc.Puzzles.Aoc2024.Aoc202413;

public class Aoc202413Tests
{
    private const string Input = """
                                 Button A: X+94, Y+34
                                 Button B: X+22, Y+67
                                 Prize: X=8400, Y=5400

                                 Button A: X+26, Y+66
                                 Button B: X+67, Y+21
                                 Prize: X=12748, Y=12176

                                 Button A: X+17, Y+86
                                 Button B: X+84, Y+37
                                 Prize: X=7870, Y=6450

                                 Button A: X+69, Y+23
                                 Button B: X+27, Y+71
                                 Prize: X=18641, Y=10279
                                 """;

    [Fact]
    public void Part1()
    {
        Sut.Part1(Input).Answer.Should().Be("480");
    }
    
    [Fact]
    public void Part2()
    {
        Aoc202413.Solve(Input, 0).Should().Be(480);
    }
    
    private static Aoc202413 Sut => new();
}