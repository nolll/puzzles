using NUnit.Framework;

namespace AquaQ.Puzzles.Aquaq04;

public class Aquaq04Tests
{
    [Test]
    public void FindCoPrimes()
    {
        var result = Aquaq04.FindCoPrimesFor(15).ToArray();

        Assert.That(result.Length, Is.EqualTo(8));
        Assert.That(result[0], Is.EqualTo(1));
        Assert.That(result[1], Is.EqualTo(2));
        Assert.That(result[2], Is.EqualTo(4));
        Assert.That(result[3], Is.EqualTo(7));
        Assert.That(result[4], Is.EqualTo(8));
        Assert.That(result[5], Is.EqualTo(11));
        Assert.That(result[6], Is.EqualTo(13));
        Assert.That(result[7], Is.EqualTo(14));
    }
}