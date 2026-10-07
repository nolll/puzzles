using Pzl.Aoc.Puzzles.Aoc2020;

namespace Tests.Aoc.Aoc2020;

public class Aoc202025Tests : PuzzleTest<Aoc202025>
{
    private const string Input = """
                                 5764801
                                 17807724
                                 """;

    [Fact]
    public void FindEncryptionKey()
    {
        var finder = new Aoc202025.EncryptionKeyFinder(Input);
        var key = finder.FindKey();

        key.Should().Be(14897079);
    }
}