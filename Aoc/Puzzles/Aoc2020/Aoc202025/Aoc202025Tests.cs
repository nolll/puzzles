namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202025;

public class Aoc202025Tests
{
    private const string Input = """
                                 5764801
                                 17807724
                                 """;

    [Fact]
    public void FindEncryptionKey()
    {
        var finder = new EncryptionKeyFinder(Input.Trim());
        var key = finder.FindKey();

        key.Should().Be(14897079);
    }
}