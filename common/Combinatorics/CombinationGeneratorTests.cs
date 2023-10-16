using NUnit.Framework;

namespace Common.Combinatorics;

public class CombinationGeneratorTests
{
    [Test]
    public void GeneratesAllCombinations()
    {
        var sequences = CombinationGenerator.GetUniqueCombinationsFixedSize(new[] { 1, 2, 3, 4, 5 }, 3).ToList();

        Assert.That(sequences.Count, Is.EqualTo(10));
    }

    [Test]
    public void GeneratesAllCombinationsIncludingDuplicates()
    {
        var sequences = CombinationGenerator.GetCombinationsFixedSize(new[] { 1, 2, 3 }, 2).ToList();

        Assert.That(sequences.Count, Is.EqualTo(7));
    }
}