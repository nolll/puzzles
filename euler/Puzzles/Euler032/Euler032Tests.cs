using NUnit.Framework;

namespace Euler.Puzzles.Euler032;

public class Euler032Tests
{
    [Test]
    public void IsPandigital()
    {
        var puzzle = new Euler032();
        var result = Euler032.IsPandigital(39, 186);

        Assert.That(result, Is.True);
    }

    [Test]
    public void IsNotPandigital()
    {
        var puzzle = new Euler032();
        var result = Euler032.IsPandigital(1, 2);

        Assert.That(result, Is.False);
    }
}