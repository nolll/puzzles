using NUnit.Framework;

namespace common.Combinatorics;

public class PermutationGeneratorTests
{
    [Test]
    public void GeneratesAllCombinations()
    {
        var sequences = PermutationGenerator.GetPermutations(new[] {1, 2, 3}).ToList();

        Assert.That(sequences.Count, Is.EqualTo(6));
    }
}