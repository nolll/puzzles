using Pzl.Common;

namespace Pzl.Aquaq.Puzzles.Aquaq16;

public class Aquaq16Tests
{
    [Fact]
    public void KerningSpaces() => Sut.Solve("LTA", new FileReader().ReadLocal(typeof(Aquaq16), "Alphabet.txt")).Should().Be(53);

    private static Aquaq16 Sut => new();
}