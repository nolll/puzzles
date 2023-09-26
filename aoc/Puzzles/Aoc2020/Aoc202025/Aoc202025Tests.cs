using NUnit.Framework;

namespace Aoc.Puzzles.Aoc2020.Aoc202025;

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

        Assert.That(key, Is.EqualTo(14897079));
    }
}