using NUnit.Framework;

namespace AquaQ.Puzzles.Aquaq01;

public class Aquaq01Test
{
    [Test]
    public void HexString()
    {
        var result = Aquaq01.GetHexString("kdb4life");

        Assert.That(result, Is.EqualTo("0d40fe"));
    }
}