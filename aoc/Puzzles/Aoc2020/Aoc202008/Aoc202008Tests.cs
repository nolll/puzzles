using NUnit.Framework;

namespace Aoc.Puzzles.Aoc2020.Aoc202008;

public class Aoc202008Tests
{
    [Test]
    public void AccIsCorrectBeforeInfiniteLoop()
    {
        var console = new GameConsoleRunner(Input.Trim());
        var accBeforeRepeat = console.RunUntilLoop();

        Assert.That(accBeforeRepeat, Is.EqualTo(5));
    }

    [Test]
    public void AccIsCorrectAfterTerminateInModifiedProgram()
    {
        var console = new GameConsoleRunner(Input.Trim());
        var accAtTermination = console.RunUntilTermination();

        Assert.That(accAtTermination, Is.EqualTo(8));
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

        Assert.That(exit.Status, Is.EqualTo(ExitStatus.End));
        Assert.That(exit.ExitValue, Is.EqualTo(8));
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