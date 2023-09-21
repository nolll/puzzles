using NUnit.Framework;

namespace AquaQ.Common.Combinatorics;

public class PermutationGeneratorTests
{
    [Test]
    public void GeneratesAllCombinations()
    {
        var sequences = PermutationGenerator.GetPermutations(new[] { 1, 2, 3 }).ToList();

        Assert.That(sequences.Count, Is.EqualTo(6));
        Assert.That(ListToString(sequences[0]), Is.EqualTo("123"));
        Assert.That(ListToString(sequences[1]), Is.EqualTo("132"));
        Assert.That(ListToString(sequences[2]), Is.EqualTo("213"));
        Assert.That(ListToString(sequences[3]), Is.EqualTo("231"));
        Assert.That(ListToString(sequences[4]), Is.EqualTo("312"));
        Assert.That(ListToString(sequences[5]), Is.EqualTo("321"));
    }

    private static string ListToString(IEnumerable<int> list)
    {
        return string.Join("", list);
    }
}