﻿using NUnit.Framework;

namespace Aquaq.Puzzles.Aquaq02;

public class Aquaq02Tests
{
    [Test]
    public void UniqueNumbers()
    {
        var input = new[]
        {
            1, 4, 3, 2, 4, 7, 2, 6, 3, 6
        };

        var result = Aquaq02.GetUniqueNumbers(input).ToArray();

        Assert.That(result.Count, Is.EqualTo(5));
        Assert.That(result[0], Is.EqualTo(1));
        Assert.That(result[1], Is.EqualTo(4));
        Assert.That(result[2], Is.EqualTo(7));
        Assert.That(result[3], Is.EqualTo(2));
        Assert.That(result[4], Is.EqualTo(6));
    }
}