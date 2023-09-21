using NUnit.Framework;

namespace AquaQ.Challenges.Challenge02;

public class Challenge02Test
{
    [Test]
    public void HexString()
    {
        var result = Challenge02.GetHexString("kdb4life");

        Assert.That(result, Is.EqualTo("0d40fe"));
    }
}