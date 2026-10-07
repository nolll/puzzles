using Pzl.Aoc.Puzzles.Aoc2017;

namespace Tests.Aoc.Aoc2017;

public class Aoc201725Tests : PuzzleTest<Aoc201725>
{
    private const string Input = """
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

    [Fact]
    public void ChecksumIsCorrect() => Sut.Part1(Input).Should().Be(3);
}