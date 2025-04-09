using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Tools.Maths;

public class MathToolsTests
{
    [TestCase(9, 9, 3)]
    [TestCase(90915, 435, 33, 57)]
    [TestCase(616, 2, 4, 8, 77)]
    [TestCase(616, 2, 8, 77)]
    public void FindsLcm(long expected, params long[] numbers) => MathTools.Lcm(numbers).Should().Be(expected);

    [TestCase(10, new[] { 1, 2, 5, 10 })]
    [TestCase(12, new[] { 1, 2, 3, 4, 6, 12 })]
    [TestCase(25, new[] { 1, 5, 25 })]
    [TestCase(99, new[] { 1, 3, 9, 11, 33, 99 })]
    [TestCase(45, new[] { 1, 3, 5, 9, 15, 45 })]
    [TestCase(20, new[] { 1, 2, 4, 5, 10, 20 })]
    [TestCase(11, new[] { 1, 11 })]
    [TestCase(17, new[] { 1, 17 })]
    public void GetFactors(int input, int[] expected) => 
        MathTools.GetFactors(input).Should().BeEquivalentTo(expected);

    [Test]
    public void GetMultiplicationFactors()
    {
        var result = MathTools.GetMultiplicationFactors(21);

        result.Count.Should().Be(2);
        result.First().Should().Be((1, 21));
        result.Last().Should().Be((3, 7));
    }

    [TestCase(1, 1)]
    [TestCase(-1, 99)]
    [TestCase(101, 1)]
    public void Clamp(int input, int expected) => MathTools.Clamp(input, 1, 100).Should().Be(expected);

    [TestCase(1, 1)]
    [TestCase(-1, 99)]
    [TestCase(101, 1)]
    public void Clamp(long input, long expected) => MathTools.Clamp(input, 1, 100).Should().Be(expected);
}