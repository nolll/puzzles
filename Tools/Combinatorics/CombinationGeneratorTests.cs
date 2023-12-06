using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Tools.Combinatorics;

public class CombinationGeneratorTests
{
    [Test]
    public void GeneratesAllCombinations()
    {
        var sequences = CombinationGenerator.GetUniqueCombinationsFixedSize(new[] { 1, 2, 3, 4, 5 }, 3).ToList();

        sequences.Count.Should().Be(10);
    }

    [Test]
    public void GeneratesAllCombinationsIncludingDuplicates()
    {
        var sequences = CombinationGenerator.GetCombinationsFixedSize(new[] { 1, 2, 3 }, 2).ToList();

        sequences.Count.Should().Be(9);
    }
}