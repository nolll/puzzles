using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Euler.Puzzles.Euler024;

public class Euler24Tests
{
    [Test]
    public void PermutationsAreGeneratedInLexicographicOrder()
    {
        var permutations = Euler024.GetPermutations(3);

        permutations.Should().BeEquivalentTo(new List<List<int>>
        {
            new() { 0, 1, 2 },
            new() { 0, 2, 1 },
            new() { 1, 0, 2 },
            new() { 1, 2, 0 },
            new() { 2, 0, 1 },
            new() { 2, 1, 0 }
        });
    }
}