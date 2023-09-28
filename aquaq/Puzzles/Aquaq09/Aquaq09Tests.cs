using System.Numerics;
using NUnit.Framework;

namespace Aquaq.Puzzles.Aquaq09;

public class Aquaq09Tests
{
    [Test]
    public void MultiplyLargeNumbers()
    {
        var input = new List<int> { 2, 4, 8 }.Select(o => new BigInteger(o));

        var result = Aquaq09.MultiplyLargeNumbers(input);

        Assert.That(result, Is.EqualTo(new BigInteger(64)));
    }
}