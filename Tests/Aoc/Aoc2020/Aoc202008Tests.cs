using Pzl.Aoc.Puzzles.Aoc2020;

namespace Tests.Aoc.Aoc2020;

public class Aoc202008Tests : PuzzleTest<Aoc202008>
{
    [Fact]
    public void AccIsCorrectBeforeInfiniteLoop() => Sut.Part1(Input).Should().Be(5);

    [Fact]
    public void AccIsCorrectAfterTerminateInModifiedProgram() => Sut.Part2(Input).Should().Be(8);

    private const string Input = """
                                 nop +0
                                 acc +1
                                 jmp +4
                                 acc +3
                                 jmp -3
                                 acc -99
                                 acc +1
                                 jmp -4
                                 acc +6
                                 """;
}