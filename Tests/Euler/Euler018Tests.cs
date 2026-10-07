using Pzl.Euler.Puzzles;

namespace Tests.Euler;

public class Euler018Tests : PuzzleTest<Euler018>
{
    [Fact]
    public void Test()
    {
        const string input = """
                                3
                                7 4
                                2 4 6
                                8 5 9 3
                                """;
        
        Sut.Solve(input).Should().Be(23);
    }

}