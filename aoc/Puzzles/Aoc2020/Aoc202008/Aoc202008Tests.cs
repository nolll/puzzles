using FluentAssertions;
using NUnit.Framework;

namespace Puzzles.Aoc.Puzzles.Aoc2020.Aoc202008;

public class Aoc202008Tests
{
    [Test]
    public void AccIsCorrectBeforeInfiniteLoop()
    {
        var console = new GameConsoleRunner(Input.Trim());
        var accBeforeRepeat = console.RunUntilLoop();

        accBeforeRepeat.Should().Be(5);
    }

    [Test]
    public void AccIsCorrectAfterTerminateInModifiedProgram()
    {
        var console = new GameConsoleRunner(Input.Trim());
        var accAtTermination = console.RunUntilTermination();

        accAtTermination.Should().Be(8);
    }

    [Test]
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

        var instructions = GameConsoleRunner.ParseInstructions(input.Trim());
        var console = new GameConsole(instructions);
        var exit = console.Run();

        exit.Status.Should().Be(ExitStatus.End);
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