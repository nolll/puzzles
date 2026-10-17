using Pzl.Aoc.Puzzles.Aoc2020;

namespace Tests.Aoc.Aoc2020;

public class Aoc202014Tests : PuzzleTest<Aoc202014>
{
    [Fact]
    public void Part1_SumIsCorrect()
    {
        const string input = """
                             mask = XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X
                             mem[8] = 11
                             mem[7] = 101
                             mem[8] = 0
                             """;

        Sut.Part1(input).Should().Be(165);
    }

    [Fact]
    public void Part2_SumIsCorrect()
    {
        const string input = """
                             mask = 000000000000000000000000000000X1001X
                             mem[42] = 100
                             mask = 00000000000000000000000000000000X0XX
                             mem[26] = 1
                             """;

        Sut.Part2(input).Should().Be(208);
    }
}