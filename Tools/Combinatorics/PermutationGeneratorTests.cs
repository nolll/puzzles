using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Tools.Combinatorics;

public class PermutationGeneratorTests
{
    [Test]
    public void GeneratesAllPermutations()
    {
        var sequences = PermutationGenerator.GetPermutations(new[] {1, 2, 3}).ToList();

        sequences.Count.Should().Be(6);
    }
}