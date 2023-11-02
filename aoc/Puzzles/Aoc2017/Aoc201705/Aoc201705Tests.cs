using FluentAssertions;
using NUnit.Framework;

namespace Aoc.Puzzles.Aoc2017.Aoc201705;

public class Aoc201705Tests
{
    [Test]
    public void Part1_StepsUntilExit()
    {
        const string input = """
0
3
0
1
-3
""";

        var jumper = new InstructionJumper(input);
        jumper.Start1();

        jumper.StepCount.Should().Be(5);
    }

    [Test]
    public void Part2_StepsUntilExit()
    {
        const string input = """
0
3
0
1
-3
""";

        var jumper = new InstructionJumper(input);
        jumper.Start2();

        jumper.StepCount.Should().Be(10);
    }
}