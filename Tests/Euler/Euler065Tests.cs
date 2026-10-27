using Pzl.Euler.Puzzles;

namespace Tests.Euler;

public class Euler065Tests : PuzzleTest<Euler065>
{
    [Fact]
    public void NumeratorSum() => Sut.NumeratorSum(10).Should().Be(17);
    
    [Fact]
    public void GetSequenceFor10Levels() => Sut.GetSequence(10).Should().BeEquivalentTo((int[])[1, 2, 1, 1, 4, 1, 1, 6, 1, 1]);

    [Fact]
    public void GetSequenceFor20Levels() => 
        Sut.GetSequence(20).Should().BeEquivalentTo((int[])[1, 2, 1, 1, 4, 1, 1, 6, 1, 1, 8, 1, 1, 10, 1, 1, 12, 1, 1, 14]);
}