using Aoc.Common.Hashing;
using NUnit.Framework;

namespace Aoc.Puzzles.Year2017.Day10;

public class Year2017Day10Tests
{
    [Test]
    public void SimulatesIntHash()
    {
        const string input = "3,4,1,5";
        var hasher = new IntKnotHasher(input, 5);

        Assert.That(hasher.Checksum, Is.EqualTo(12));
    }

    [TestCase("", "a2582a3a0e66e6e86e3812dcb672a272")]
    [TestCase("AoC 2017", "33efeb34ea91902bb2f59c9920caa6cd")]
    [TestCase("1,2,3", "3efbe78a8d82f29979031a4aa0b16a9d")]
    [TestCase("1,2,4", "63960835bcdc130f0b66d7ff4f6a5a8e")]
    public void SimulatesAsciiHash(string input, string expected)
    {
        var hasher = new AsciiKnotHasher(input);

        Assert.That(hasher.Hash, Is.EqualTo(expected));
    }
}