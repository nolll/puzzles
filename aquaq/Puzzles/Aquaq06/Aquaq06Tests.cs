using NUnit.Framework;

namespace Aquaq.Puzzles.Aquaq06;

public class Aquaq06Tests
{
    [Test]
    public void CountOccurrencesOfOne()
    {
        var result = Aquaq06.FindOneCount(3);

        Assert.That(result, Is.EqualTo(9));
    }
}