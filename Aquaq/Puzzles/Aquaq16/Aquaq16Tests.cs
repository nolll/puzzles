using FluentAssertions;
using Pzl.Common;

namespace Pzl.Aquaq.Puzzles.Aquaq16;

public class Aquaq16Tests
{
    [Fact]
    public void KerningSpaces()
    {
        const string input = "LTA";

        var result = Sut.RunInternal(input, new FileReader().ReadLocal(typeof(Aquaq16), "Alphabet.txt"));

        result.Should().Be(53);
    }

    private static Aquaq16 Sut => new Aquaq16();
}