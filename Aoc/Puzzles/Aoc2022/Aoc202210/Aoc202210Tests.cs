namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202210;

public class Aoc202210Tests
{
    [Fact]
    public void Part1Short()
    {
        var tube = new CathodeRayTube();
        var (result, _, _) = tube.Run(ShortInput);

        result.Should().Be(0);
    }

    [Fact]
    public void Part1Long()
    {
        var tube = new CathodeRayTube();
        var (result, _, _) = tube.Run(LongInput);

        result.Should().Be(13140);
    }

    [Fact]
    public void Part2()
    {
        var tube = new CathodeRayTube();
        var (_, _, result) = tube.Run(LongInput);

        const string expected = """
                                ##..##..##..##..##..##..##..##..##..##..
                                ###...###...###...###...###...###...###.
                                ####....####....####....####....####....
                                #####.....#####.....#####.....#####.....
                                ######......######......######......####
                                #######.......#######.......#######.....
                                """;

        result.Should().Be(expected);
    }

    private const string ShortInput = """
                                      noop
                                      addx 3
                                      addx -5
                                      """;

    private const string LongInput = """
                                     addx 15
                                     addx -11
                                     addx 6
                                     addx -3
                                     addx 5
                                     addx -1
                                     addx -8
                                     addx 13
                                     addx 4
                                     noop
                                     addx -1
                                     addx 5
                                     addx -1
                                     addx 5
                                     addx -1
                                     addx 5
                                     addx -1
                                     addx 5
                                     addx -1
                                     addx -35
                                     addx 1
                                     addx 24
                                     addx -19
                                     addx 1
                                     addx 16
                                     addx -11
                                     noop
                                     noop
                                     addx 21
                                     addx -15
                                     noop
                                     noop
                                     addx -3
                                     addx 9
                                     addx 1
                                     addx -3
                                     addx 8
                                     addx 1
                                     addx 5
                                     noop
                                     noop
                                     noop
                                     noop
                                     noop
                                     addx -36
                                     noop
                                     addx 1
                                     addx 7
                                     noop
                                     noop
                                     noop
                                     addx 2
                                     addx 6
                                     noop
                                     noop
                                     noop
                                     noop
                                     noop
                                     addx 1
                                     noop
                                     noop
                                     addx 7
                                     addx 1
                                     noop
                                     addx -13
                                     addx 13
                                     addx 7
                                     noop
                                     addx 1
                                     addx -33
                                     noop
                                     noop
                                     noop
                                     addx 2
                                     noop
                                     noop
                                     noop
                                     addx 8
                                     noop
                                     addx -1
                                     addx 2
                                     addx 1
                                     noop
                                     addx 17
                                     addx -9
                                     addx 1
                                     addx 1
                                     addx -3
                                     addx 11
                                     noop
                                     noop
                                     addx 1
                                     noop
                                     addx 1
                                     noop
                                     noop
                                     addx -13
                                     addx -19
                                     addx 1
                                     addx 3
                                     addx 26
                                     addx -30
                                     addx 12
                                     addx -1
                                     addx 3
                                     addx 1
                                     noop
                                     noop
                                     noop
                                     addx -9
                                     addx 18
                                     addx 1
                                     addx 2
                                     noop
                                     noop
                                     addx 9
                                     noop
                                     noop
                                     noop
                                     addx -1
                                     addx 2
                                     addx -37
                                     addx 1
                                     addx 3
                                     noop
                                     addx 15
                                     addx -21
                                     addx 22
                                     addx -6
                                     addx 1
                                     noop
                                     addx 2
                                     addx 1
                                     noop
                                     addx -10
                                     noop
                                     noop
                                     addx 20
                                     addx 1
                                     addx 2
                                     addx 2
                                     addx -6
                                     addx -11
                                     noop
                                     noop
                                     noop
                                     """;
}