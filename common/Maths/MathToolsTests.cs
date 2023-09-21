using NUnit.Framework;

namespace common.Maths;

public class MathToolsTests
{
    [TestCase(9, 9, 3)]
    [TestCase(90915, 435, 33, 57)]
    [TestCase(616, 2, 4, 8, 77)]
    [TestCase(616, 2, 8, 77)]
    public void FindsLcm(long expected, params long[] numbers)
    {
        var result = MathTools.Lcm(numbers);

        Assert.That(result, Is.EqualTo(expected));
    }
}