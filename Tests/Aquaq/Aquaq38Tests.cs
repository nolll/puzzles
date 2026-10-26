using Pzl.Aquaq.Puzzles;

namespace Tests.Aquaq;

public class Aquaq38Tests : PuzzleTest<Aquaq38>
{
    [Fact]
    public void IndexStreaks()
    {
        var streaks = Sut.GetIndexStreaks([], [1, 3, 2]);

        int[][][] expected =
        [
            [[0], [0, 1], [0, 1, 2]],
            [[1], [0, 1], [1, 2], [0, 1, 2]], 
            [[0, 1, 2], [1, 2], [2]]
        ];

        streaks.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void ComfScore() => Sut.GetComfScore([1, 3, 2]).Should().Be(7);
}