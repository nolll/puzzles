using Pzl.Aoc.Puzzles.Aoc2018;

namespace Tests.Aoc.Aoc2018;

public class Aoc201808Tests
{
    [Fact]
    public void MetaDataEntrySum()
    {
        const string input = "2 3 0 3 10 11 12 1 1 0 1 99 2 1 1 2";

        var calculator = new Aoc201808.LicenseNumberCalculator(input);

        calculator.MetadataSum.Should().Be(138);
        calculator.RootNodeValue.Should().Be(66);
    }
}