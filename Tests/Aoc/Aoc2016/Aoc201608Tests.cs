using Pzl.Aoc.Puzzles.Aoc2016;

namespace Tests.Aoc.Aoc2016;

public class Aoc201608Tests : PuzzleTest<Aoc201608>
{
    [Fact]
    public void PixelCount()
    {
        const string input = """
                             rect 3x2
                             rotate column x=1 by 1
                             rotate row y=0 by 4
                             rotate column x=1 by 1
                             """;
        
        Sut.SolvePart1(input, 7, 5).Should().Be(6);
    }
}