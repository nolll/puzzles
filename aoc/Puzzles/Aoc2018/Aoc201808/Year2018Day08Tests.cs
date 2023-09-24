using NUnit.Framework;

namespace Aoc.Puzzles.Aoc2018.Aoc201808;

public class Year2018Day08Tests
{
    [Test]
    public void MetaDataEntrySum()
    {
        const string input = "2 3 0 3 10 11 12 1 1 0 1 99 2 1 1 2";

        var calculator = new LicenseNumberCalculator(input);

        Assert.That(calculator.MetadataSum, Is.EqualTo(138));
        Assert.That(calculator.RootNodeValue, Is.EqualTo(66));
    }
}