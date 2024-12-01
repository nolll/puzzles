using FluentAssertions;
using NUnit.Framework;
using Pzl.Common;

namespace Pzl.Aquaq.Puzzles.Aquaq16;

public class Aquaq16Tests
{
    [Test]
    public void KerningSpaces()
    {
        const string input = "LTA";

        var result = new Aquaq16(input, FileReader.ReadLocal(typeof(Aquaq16), "Alphabet.txt")).RunInternal(input);

        result.Should().Be(53);
    }
}