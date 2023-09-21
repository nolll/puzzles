using NUnit.Framework;

namespace Euler.Problems.Problem032;

public class Problem032Tests
{
    [Test]
    public void IsPandigital()
    {
        var problem = new Problem032();
        var result = Problem032.IsPandigital(39, 186);

        Assert.That(result, Is.True);
    }

    [Test]
    public void IsNotPandigital()
    {
        var problem = new Problem032();
        var result = Problem032.IsPandigital(1, 2);

        Assert.That(result, Is.False);
    }
}