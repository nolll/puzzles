using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Tools.Combinatorics;

public class CombinationGeneratorTests
{
    [Test]
    public void GeneratesAllCombinations() =>
        CombinationGenerator.GetUniqueCombinationsFixedSize([1, 2, 3, 4, 5], 3).ToList()
            .Count.Should().Be(10);

    [Test]
    public void GeneratesAllCombinationsIncludingDuplicates() =>
        CombinationGenerator.GetCombinationsFixedSize([1, 2, 3], 2).ToList()
            .Count.Should().Be(9);
}