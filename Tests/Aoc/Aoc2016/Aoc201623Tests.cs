using Pzl.Aoc.Puzzles.Aoc2016;

namespace Tests.Aoc.Aoc2016;

public class Aoc201623Tests : PuzzleTest<Aoc201623>
{
    [Fact]
    public void RegisterAIsCorrect()
    {
        const string input = """
                             cpy 41 a
                             inc a
                             inc a
                             dec a
                             jnz a 2
                             dec a
                             """;

        Sut.RunPart1(input, 0, 0).Should().Be(42);
    }

    [Fact]
    public void RegisterAIsCorrectWithToggleInstruction()
    {
        const string input = """
                             cpy 2 a
                             tgl a
                             tgl a
                             tgl a
                             cpy 1 a
                             dec a
                             dec a
                             """;

        Sut.RunPart2(input, 0, 0).Should().Be(3);
    }
}