using NUnit.Framework;

namespace Aoc.Puzzles.Aoc2017.Aoc201708;

public class Aoc201708Tests
{
    [Test]
    public void GetLargestValue()
    {
        const string input = """
b inc 5 if a > 1
a inc 1 if b < 5
c dec -10 if a >= 1
c inc -20 if c == 10
""";

        var calculator = new CpuInstructionCalculator(input.Trim());

        Assert.That(calculator.LargestValueAtEnd, Is.EqualTo(1));
        Assert.That(calculator.LargestValueEver, Is.EqualTo(10));
    }
}