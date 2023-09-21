using NUnit.Framework;

namespace Euler.Problems.Problem031;

public class Problem031Tests
{
    [Test]
    public void TwoDenominations()
    {
        var problem = new Problem031();
        var result = problem.Run(new List<int> { 1, 2 }, 2);

        Assert.That(result, Is.EqualTo(2));
    }

    [Test]
    public void ThreeDenominations()
    {
        var problem = new Problem031();
        var result = problem.Run(new List<int> { 1, 2, 5 }, 5);

        Assert.That(result, Is.EqualTo(4));
    }

    [Test]
    public void FourDenominations()
    {
        var problem = new Problem031();
        var result = problem.Run(new List<int> { 1, 2, 5, 10 }, 10);

        Assert.That(result, Is.EqualTo(11));
    }
}