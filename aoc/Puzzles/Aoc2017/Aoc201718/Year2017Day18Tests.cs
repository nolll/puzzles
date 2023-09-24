using NUnit.Framework;

namespace Aoc.Puzzles.Aoc2017.Day18;

public class Year2017Day18Tests
{
    [Test]
    public void SingleRunnerFindsFrequency()
    {
        const string input = """
set a 1
add a 2
mul a a
mod a 5
snd a
set a 0
rcv a
jgz a -1
set a 1
jgz a -2
""";

        var single = new SingleRunner(input.Trim());
        single.Run();

        Assert.That(single.RecoveredFrequency, Is.EqualTo(4));
    }

    [Test]
    public void DuetRunnerSendCountIsCorrect()
    {
        const string input = """
snd 1
snd 2
snd p
rcv a
rcv b
rcv c
rcv d
""";

        var duet = new DuetRunner(input.Trim());
        duet.Run();

        Assert.That(duet.Program1SendCount, Is.EqualTo(3));
    }
}