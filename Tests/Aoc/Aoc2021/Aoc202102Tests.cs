using Pzl.Aoc.Puzzles.Aoc2021;

namespace Tests.Aoc.Aoc2021;

public class Aoc202102Tests : PuzzleTest<Aoc202102>
{
    [Fact]
    public void Part1()
    {
        var validator = new Aoc202102.SubmarineControl(Input.Trim(), false);
        validator.Move();

        validator.Result.Should().Be(150);
    }

    [Fact]
    public void Part2()
    {
        var validator = new Aoc202102.SubmarineControl(Input.Trim(), true);
        validator.Move();

        validator.Result.Should().Be(900);
    }

    private const string Input = """
                                 forward 5
                                 down 5
                                 forward 8
                                 up 3
                                 down 8
                                 forward 2
                                 """;
}