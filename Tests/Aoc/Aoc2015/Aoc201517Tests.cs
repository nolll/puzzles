using Pzl.Aoc.Puzzles.Aoc2015;

namespace Tests.Aoc.Aoc2015;

public class Aoc201517Tests : PuzzleTest<Aoc201517>
{
    [Fact]
    public void NumberOfCombinationsIsCorrect()
    {
        const string input = """
                             20
                             15
                             10
                             5
                             5
                             """;
        
        Sut.GetCombinations(input, 25).Count().Should().Be(4);
    }
}