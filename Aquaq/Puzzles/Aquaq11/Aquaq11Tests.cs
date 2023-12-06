using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aquaq.Puzzles.Aquaq11;

public class Aquaq11Tests
{
    private const string Input = """
lx,ly,ux,uy
0,0,3,3
2,2,4,5
6,3,8,7
""";

    [Test]
    public void CountRequiredTile()
    {
        var result = Aquaq11.CountRequiredTiles(Input);

        result.Should().Be(14);
    }
}