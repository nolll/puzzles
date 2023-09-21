using NUnit.Framework;

namespace Euler.Problems.Problem042;

public class Problem042Tests
{
    [TestCase("SKY", true)]
    [TestCase("WHATEVER", false)]
    public void IsTriangular(string word, bool expected)
    {
        var result = Problem042.IsTriangular(word);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void GetWordValue()
    {
        var result = Problem042.GetWordValue("SKY");

        Assert.That(result, Is.EqualTo(55));
    }

    [Test]
    public void GetTriangularNumbers()
    {
        var result = Problem042.GetTriangularNumbers(10).ToArray();

        Assert.That(result[0], Is.EqualTo(1));
        Assert.That(result[1], Is.EqualTo(3));
        Assert.That(result[2], Is.EqualTo(6));
        Assert.That(result[3], Is.EqualTo(10));
        Assert.That(result[4], Is.EqualTo(15));
        Assert.That(result[5], Is.EqualTo(21));
        Assert.That(result[6], Is.EqualTo(28));
        Assert.That(result[7], Is.EqualTo(36));
        Assert.That(result[8], Is.EqualTo(45));
        Assert.That(result[9], Is.EqualTo(55));
    }
}