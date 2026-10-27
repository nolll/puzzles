using Pzl.Euler.Puzzles;

namespace Tests.Euler;

public class Euler024Tests : PuzzleTest<Euler024>
{
    [Fact]
    public void PermutationsAreGeneratedInLexicographicOrder() => 
        Sut.GetPermutations(3).Should().BeEquivalentTo((List<List<int>>)[[0, 1, 2], [0, 2, 1], [1, 0, 2], [1, 2, 0], [2, 0, 1], [2, 1, 0]]);
}