using Pzl.Aquaq.Puzzles;

namespace Tests.Aquaq;

public class Aquaq38Tests
{
    [Fact]
    public void IndexStreaks()
    {
        var streaks = new Aquaq38.IndexStreakProvider().Get([1, 3, 2]);

        int[][][] expected =
        [
            [
                [0],
                [0, 1],
                [0, 1, 2]
            ],
            [
                [1],
                [0, 1],
                [1, 2],
                [0, 1, 2]
            ],
            [
                [0, 1, 2],
                [1, 2],
                [2]
            ]
        ];

        streaks.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void ComfScore() => 
        Aquaq38.GetComfScore(new Aquaq38.IndexStreakProvider(), [1, 3, 2]).Should().Be(7);
}