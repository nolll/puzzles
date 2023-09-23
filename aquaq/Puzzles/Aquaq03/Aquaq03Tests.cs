﻿using Common.CoordinateSystems.CoordinateSystem2D;
using NUnit.Framework;

namespace Aquaq.Puzzles.Aquaq03;

public class Aquaq03Tests
{
    [TestCase("UDRR", 4, 1, 14)]
    [TestCase("RR", 3, 0, 6)]
    public void ShouldEndAt(string input, int expectedX, int expectedY, int expectedSum)
    {
        var walker = new Walker();
        var result = walker.Walk(input);

        Assert.That(walker.Pos, Is.EqualTo(new MatrixAddress(expectedX, expectedY)));
        Assert.That(result, Is.EqualTo(expectedSum));
    }
}