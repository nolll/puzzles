using Pzl.Aoc.Puzzles.Aoc2020;

namespace Tests.Aoc.Aoc2020;

public class Aoc202008Tests : PuzzleTest<Aoc202008>
{
    [Fact]
    public void AccIsCorrectBeforeInfiniteLoop()
    {
        var console = new Aoc202008.GameConsoleRunner(Input.Trim());
        var accBeforeRepeat = console.RunUntilLoop();

        accBeforeRepeat.Should().Be(5);
    }

    [Fact]
    public void AccIsCorrectAfterTerminateInModifiedProgram()
    {
        var console = new Aoc202008.GameConsoleRunner(Input.Trim());
        var accAtTermination = console.RunUntilTermination();

        accAtTermination.Should().Be(8);
    }

    [Fact]
    public void ModifiedProgramReturnsCorrectExitStatus()
    {
        const string input = """
                             nop +0
                             acc +1
                             jmp +4
                             acc +3
                             jmp -3
                             acc -99
                             acc +1
                             nop -4
                             acc +6
                             """;

        var instructions = Aoc202008.GameConsoleRunner.ParseInstructions(input.Trim());
        var console = new Aoc202008.GameConsole(instructions);
        var exit = console.Run();

        exit.Status.Should().Be(Aoc202008.ExitStatus.End);
        exit.ExitValue.Should().Be(8);
    }

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