using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Tools.Combinatorics;

public class PermutationGeneratorTests
{
    [Test]
    public void GeneratesAllPermutations()
    {
        var result = PermutationGenerator.GetPermutations([1, 2, 3]).ToList();
        result.Count.Should().Be(6);
        result[0].Should().BeEquivalentTo([1, 2, 3]);
    }
}