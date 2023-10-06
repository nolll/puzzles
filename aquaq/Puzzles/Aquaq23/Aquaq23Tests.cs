using NUnit.Framework;

namespace Aquaq.Puzzles.Aquaq23;

public class Aquaq23Tests
{
    [Test]
    public void CreateBoard()
    {
        var expected =
"""
playf
irbcd
eghkm
noqst
uvwxz
""";

        var result = Aquaq23.CreateCipherBoard("playfair");

        Assert.That(result.Print().Trim(), Is.EqualTo(expected));
    }
}