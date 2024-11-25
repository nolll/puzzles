using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aquaq.Puzzles.Aquaq38;

public class Aquaq38Tests
{
    [Test]
    public void IndexStreaks()
    {
        var streaks = new IndexStreakProvider().Get([1, 3, 2]);

        var expected = new[]
        {
            new[]
            {
                new[] { 0 },
                [0, 1],
                [0, 1, 2]
            },
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
        };

        streaks.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void ComfScore()
    {
        var streaks = Aquaq38.GetComfScore(new IndexStreakProvider(), [1, 3, 2]);

        streaks.Should().Be(7);
    }
}