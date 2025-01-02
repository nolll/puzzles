using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201603;

public class Aoc201603Tests
{
    [TestCase("12 13 14", true)]
    [TestCase("1 2 5", false)]
    public void ValidateTriangles(string triangleSpec, bool expectedResult)
    {
        var validator = new TriangleValidator();
        var isValid = TriangleValidator.IsValid(triangleSpec);

        isValid.Should().Be(expectedResult);
    }

    [Test]
    public void ValidHorizontalCount()
    {
        const string input = """
                             12 13 14
                             1 2 5
                             """;

        var validator = new TriangleValidator();
        var validCount = validator.GetHorizontalValidCount(input);

        validCount.Should().Be(1);
    }

    [Test]
    public void ValidVerticalCount()
    {
        const string input = """
                             101 301 501
                             102 302 502
                             103 303 503
                             201 401 601
                             202 402 602
                             203 403 603
                             """;

        var validator = new TriangleValidator();
        var validCount = validator.GetVerticalValidCount(input);

        validCount.Should().Be(6);
    }
}