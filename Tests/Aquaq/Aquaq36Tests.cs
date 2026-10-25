using Pzl.Aquaq.Puzzles;

namespace Tests.Aquaq;

public class Aquaq36Tests : PuzzleTest<Aquaq36>
{
    [Fact]
    public void SolveWithKnownNumbers()
    {
        var gridNumbers = "252 260 13 30 25 144 36 30 48 21 40 30 224 56 46 22".Split().Select(int.Parse).ToList();
        var inputNumbers = "1 2 2 5 6 6 8 10 14 16 21 23 24 26 28 42".Split().Select(int.Parse).Cast<int?>().ToList();
        Sut.Solve(gridNumbers, inputNumbers).Should().Be(142);
    }

    [Fact]
    public void Factors()
    {
        var gridNumbers = "10 12 25".Split().Select(int.Parse).ToList();
        var expected = new[] { 1, 1, 1, 2, 2, 3, 4, 5, 5, 6, 10, 12, 25 };
        Sut.GetAllFactors(gridNumbers).Should().BeEquivalentTo(expected);
    }
    
    [Fact]
    public void PossibleInputNumbers()
    {
        var input = "* 2 3 * 4 5 6 * 7 7 * 10 10 13 * 15".Split().Select(o => (int?)(o == "*" ? null : int.Parse(o))).ToList();
        var factors = new HashSet<int> { 2, 4, 7, 9, 14, 15 };
        
        List<List<int>> expected =
        [
            [2],
            [2],
            [3],
            [4],
            [4],
            [5],
            [6],
            [7],
            [7],
            [7],
            [7, 9],
            [10],
            [10],
            [13],
            [14, 15],
            [15]
        ];

        Sut.FindPossibleInputNumbers(input, 70, factors).Should().BeEquivalentTo(expected);
    }
}