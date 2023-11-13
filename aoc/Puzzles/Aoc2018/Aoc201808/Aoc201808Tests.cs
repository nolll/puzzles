using FluentAssertions;
using NUnit.Framework;

namespace Puzzles.aoc.Puzzles.Aoc2018.Aoc201808;

public class Aoc201808Tests
{
    [Test]
    public void MetaDataEntrySum()
    {
        const string input = "2 3 0 3 10 11 12 1 1 0 1 99 2 1 1 2";

        var calculator = new LicenseNumberCalculator(input);

        calculator.MetadataSum.Should().Be(138);
        calculator.RootNodeValue.Should().Be(66);
    }
}