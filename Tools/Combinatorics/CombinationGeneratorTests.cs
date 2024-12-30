using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Tools.Combinatorics;

public class CombinationGeneratorTests
{
    [Test]
    public void GeneratesAllUniqueCombinationsOfAnySize()
    {
        var result = CombinationGenerator.GetUniqueCombinationsAnySize([1, 2, 3]).ToList();
        int[][] expected =
        [
            [1],
            [2],
            [2, 1],
            [3],
            [3, 1],
            [3, 2],
            [3, 2, 1]
        ];
        
        ListAssert.IsEquivalent(result, expected);
    }
    
    [Test]
    public void GeneratesAllUniqueCombinationsOfSpecifiedSize()
    {
        var result = CombinationGenerator.GetUniqueCombinationsFixedSize([1, 2, 3, 4, 5], 3).ToList();
        int[][] expected =
        [
            [1, 2, 3],
            [1, 2, 4],
            [1, 2, 5],
            [1, 3, 4],
            [1, 3, 5],
            [1, 4, 5],
            [2, 3, 4],
            [2, 3, 5],
            [2, 4, 5],
            [3, 4, 5]  
        ];
        
        ListAssert.IsEquivalent(result, expected);
    }
    
    [Test]
    public void GeneratesAllUniqueCombinationsOfMaxSize()
    {
        var result = CombinationGenerator.GetUniqueCombinationsMaxSize([1, 2, 3], 2).ToList();
        int[][] expected =
        [
            [1],
            [2],
            [2, 1],
            [3],
            [3, 1],
            [3, 2]
        ];
        
        ListAssert.IsEquivalent(result, expected);
    }

    [Test]
    public void GeneratesAllCombinationsIncludingDuplicatesOfSpecifiedSize()
    {
        var result = CombinationGenerator.GetCombinationsFixedSize([1, 2, 3], 2).ToList();
        int[][] expected =
        [
            [1, 1],
            [1, 2],
            [1, 3],
            [2, 1],
            [2, 2],
            [2, 3],
            [3, 1],
            [3, 2],
            [3, 3]
        ];
        
        ListAssert.IsEquivalent(result, expected);
    }

    [Test]
    public void GeneratesCartesianProductOfLists()
    {
        var result = CombinationGenerator.CartesianProduct([[1, 2], [3, 4, 5], [6, 7]]).ToList();
        int[][] expected =
        [
            [1, 3, 6],
            [1, 3, 7],
            [1, 4, 6],
            [1, 4, 7],
            [1, 5, 6],
            [1, 5, 7],
            [2, 3, 6],
            [2, 3, 7],
            [2, 4, 6],
            [2, 4, 7],
            [2, 5, 6],
            [2, 5, 7]
        ];
        
        ListAssert.IsEquivalent(result, expected);
    }
}