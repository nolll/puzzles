using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201725;

public class Aoc201725Tests
{
    [Test]
    public void ChecksumIsCorrect()
    {
        const string input = """
                             Begin in state A.
                             Perform a diagnostic checksum after 6 steps.

                             In state A:
                               If the current value is 0:
                                 - Write the value 1.
                                 - Move one slot to the right.
                                 - Continue with state B.
                               If the current value is 1:
                                 - Write the value 0.
                                 - Move one slot to the left.
                                 - Continue with state B.

                             In state B:
                               If the current value is 0:
                                 - Write the value 1.
                                 - Move one slot to the left.
                                 - Continue with state A.
                               If the current value is 1:
                                 - Write the value 1.
                                 - Move one slot to the right.
                                 - Continue with state A.
                             """;

        var turingMachine = new TuringMachine(input.Trim());
        var checksum = turingMachine.Run();

        checksum.Should().Be(3);
    }
}