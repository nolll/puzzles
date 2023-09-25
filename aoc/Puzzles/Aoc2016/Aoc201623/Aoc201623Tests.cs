using NUnit.Framework;

namespace Aoc.Puzzles.Aoc2016.Aoc201623;

public class Aoc201623Tests
{
    [Test]
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

        var control = new SafeCrackingComputerPart1(input.Trim(), 0, 0);

        Assert.That(control.ValueA, Is.EqualTo(42));
    }

    [Test]
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

        var control = new SafeCrackingComputerPart1(input.Trim(), 0, 0);

        Assert.That(control.ValueA, Is.EqualTo(3));
    }
}