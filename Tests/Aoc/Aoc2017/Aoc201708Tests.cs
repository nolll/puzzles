using Pzl.Aoc.Puzzles.Aoc2017;

namespace Tests.Aoc.Aoc2017;

public class Aoc201708Tests : PuzzleTest<Aoc201708>
{
    [Fact]
    public void GetLargestValue()
    {
        const string input = """
                             b inc 5 if a > 1
                             a inc 1 if b < 5
                             c dec -10 if a >= 1
                             c inc -20 if c == 10
                             """;

        var calculator = new Aoc201708.CpuInstructionCalculator(input.Trim());

        calculator.LargestValueAtEnd.Should().Be(1);
        calculator.LargestValueEver.Should().Be(10);
    }
}