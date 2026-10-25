using Pzl.Aquaq.Puzzles;

namespace Tests.Aquaq;

public class Aquaq33Tests : PuzzleTest<Aquaq33>
{
    [Fact]
    public void ThrowDarts() => Sut.Run(30).Should().Be(32);

    [Theory]
    [InlineData(301, 6)]
    [InlineData(501, 9)]
    [InlineData(171, 3)]
    [InlineData(180, 3)]
    [InlineData(181, 4)]
    [InlineData(342, 6)]
    [InlineData(361, 7)]
    public void PlayOneGame(int target, int expected) => Sut.Play(target).Should().Be(expected);
}