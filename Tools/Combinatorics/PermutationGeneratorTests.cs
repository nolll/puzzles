using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Tools.Combinatorics;

public class PermutationGeneratorTests
{
    [Test]
    public void GeneratesAllPermutations() => 
        PermutationGenerator.GetPermutations([1, 2, 3])
            .ToList().Count.Should().Be(6);
}