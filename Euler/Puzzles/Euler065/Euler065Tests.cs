namespace Pzl.Euler.Puzzles.Euler065;

public class Euler065Tests
{
    [Fact]
    public void NumeratorSum() => 
        Sut.NumeratorSum(10).Should().Be(17);
    
    [Fact]
    public void GetSequenceFor10Levels()
    {
        int[] expected = [1, 2, 1, 1, 4, 1, 1, 6, 1, 1];
        Sut.GetSequence(10).Should().BeEquivalentTo(expected);
    }
    
    [Fact]
    public void GetSequenceFor20Levels()
    {
        int[] expected = [1, 2, 1, 1, 4, 1, 1, 6, 1, 1, 8, 1, 1, 10, 1, 1, 12, 1, 1, 14];
        Sut.GetSequence(20).Should().BeEquivalentTo(expected);
    }

    private static Euler065 Sut => new();
}