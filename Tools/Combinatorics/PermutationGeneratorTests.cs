using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Tools.Combinatorics;

public class PermutationGeneratorTests
{
    [Test]
    public void GeneratesAllPermutations()
    {
        var result = PermutationGenerator.GetPermutations([1, 2, 3]).ToList();
        int[][] expected =
        [
            [1, 2, 3],
            [1, 3, 2],
            [2, 1, 3],
            [2, 3, 1],
            [3, 1, 2],
            [3, 2, 1]
        ];
        
        ListAssert.IsEquivalent(result, expected);
    }
}