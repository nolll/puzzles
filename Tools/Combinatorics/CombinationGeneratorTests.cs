using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Tools.Combinatorics;

public class CombinationGeneratorTests
{
    [Test]
    public void GeneratesAllCombinations()
    {
        var result = CombinationGenerator.GetUniqueCombinationsFixedSize([1, 2, 3, 4, 5], 3).ToList();
        result.Count.Should().Be(10);
        result[0].Should().BeEquivalentTo([1, 2, 3]);
        result[1].Should().BeEquivalentTo([1, 2, 4]);
        result[2].Should().BeEquivalentTo([1, 2, 5]);
        result[3].Should().BeEquivalentTo([1, 3, 4]);
        result[4].Should().BeEquivalentTo([1, 3, 5]);
        result[5].Should().BeEquivalentTo([1, 4, 5]);
        result[6].Should().BeEquivalentTo([2, 3, 4]);
        result[7].Should().BeEquivalentTo([2, 3, 5]);
        result[8].Should().BeEquivalentTo([2, 4, 5]);
        result[9].Should().BeEquivalentTo([3, 4, 5]);
    }

    [Test]
    public void GeneratesAllCombinationsIncludingDuplicates()
    {
        var result = CombinationGenerator.GetCombinationsFixedSize([1, 2, 3], 2).ToList();
        result.Count.Should().Be(9);
        result[0].Should().BeEquivalentTo([1, 1]);
        result[1].Should().BeEquivalentTo([1, 2]);
        result[2].Should().BeEquivalentTo([1, 3]);
        result[3].Should().BeEquivalentTo([2, 1]);
        result[4].Should().BeEquivalentTo([2, 2]);
        result[5].Should().BeEquivalentTo([2, 3]);
        result[6].Should().BeEquivalentTo([3, 1]);
        result[7].Should().BeEquivalentTo([3, 2]);
        result[8].Should().BeEquivalentTo([3, 3]);
    }

    [Test]
    public void GeneratesCartesianProductOfLists()
    {
        var result = CombinationGenerator.CartesianProduct([[1, 2], [3, 4, 5], [6, 7]]).ToList();
        result.Count.Should().Be(12);
        result[0].Should().BeEquivalentTo([1, 3, 6]);
        result[1].Should().BeEquivalentTo([1, 3, 7]);
        result[2].Should().BeEquivalentTo([1, 4, 6]);
        result[3].Should().BeEquivalentTo([1, 4, 7]);
        result[4].Should().BeEquivalentTo([1, 5, 6]);
        result[5].Should().BeEquivalentTo([1, 5, 7]);
        result[6].Should().BeEquivalentTo([2, 3, 6]);
        result[7].Should().BeEquivalentTo([2, 3, 7]);
        result[8].Should().BeEquivalentTo([2, 4, 6]);
        result[9].Should().BeEquivalentTo([2, 4, 7]);
        result[10].Should().BeEquivalentTo([2, 5, 6]);
        result[11].Should().BeEquivalentTo([2, 5, 7]);
    }
}