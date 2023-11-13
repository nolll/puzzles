using FluentAssertions;
using NUnit.Framework;

namespace Puzzles.aoc.Puzzles.Aoc2020.Aoc202025;

public class Aoc202025Tests
{
    private const string Input = """
5764801
17807724
""";

    [Test]
    public void FindEncryptionKey()
    {
        var finder = new EncryptionKeyFinder(Input.Trim());
        var key = finder.FindKey();

        key.Should().Be(14897079);
    }
}