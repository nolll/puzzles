using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aquaq.Puzzles.Aquaq38;

public class Aquaq38Tests
{
    [Test]
    public void IndexStreaks()
    {
        var streaks = new IndexStreakProvider().Get(new[] { 1, 3, 2 });

        var expected = new[]
        {
            new[]
            {
                new[] { 0 },
                new[] { 0, 1 },
                new[] { 0, 1, 2 }
            },
            new[]
            {
                new[] { 1 },
                new[] { 0, 1 },
                new[] { 1, 2 },
                new[] { 0, 1, 2 }
            },
            new[]
            {
                new[] { 0, 1, 2 },
                new[] { 1, 2 },
                new[] { 2 }
            }
        };

        streaks.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void ComfScore()
    {
        var streaks = Aquaq38.GetComfScore(new IndexStreakProvider(), new[] { 1, 3, 2 });

        streaks.Should().Be(7);
    }
}