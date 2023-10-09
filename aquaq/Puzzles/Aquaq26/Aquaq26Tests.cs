using NUnit.Framework;

namespace Aquaq.Puzzles.Aquaq26;

public class Aquaq26Tests
{
    [TestCase(1423, 1432)]
    [TestCase(121, 211)]
    [TestCase(10290, 10902)]
    [TestCase(4321, 4321)]
    public void FindFirstLargestNumber(long input, long expected)
    {
        var result = Aquaq26.FindFirstLargerNumber(input);

        Assert.That(result, Is.EqualTo(expected));
    }
}