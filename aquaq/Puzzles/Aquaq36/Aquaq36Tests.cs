using FluentAssertions;
using NUnit.Framework;

namespace Puzzles.aquaq.Puzzles.Aquaq36;

public class Aquaq36Tests
{
    [Test]
    public void SolveWithKnownNumbers()
    {
        var gridNumbers = "252 260 13 30 25 144 36 30 48 21 40 30 224 56 46 22"
            .Split().Select(int.Parse).ToList();

        var inputNumbers = "1 2 2 5 6 6 8 10 14 16 21 23 24 26 28 42"
            .Split().Select(int.Parse).Cast<int?>().ToList();

        var result = Aquaq36.Solve(gridNumbers, inputNumbers);

        result.Should().Be(142);
    }

    [Test]
    public void Factors()
    {
        var gridNumbers = "10 12 25"
            .Split().Select(int.Parse).ToList();

        var result = Aquaq36.GetAllFactors(gridNumbers);

        var expected = new[] { 1, 1, 1, 2, 2, 3, 4, 5, 5, 6, 10, 12, 25 };
        
        result.Should().BeEquivalentTo(expected);
    }
    
    [Test]
    public void PossibleInputNumbers()
    {
        var input = "* 2 3 * 4 5 6 * 7 7 * 10 10 13 * 15"
            .Split().Select(o => (int?)(o == "*" ? null : int.Parse(o))).ToList();

        var factors = new HashSet<int> { 2, 4, 7, 9, 14, 15 };

        var result = Aquaq36.FindPossibleInputNumbers(input, 70, factors);

        result.Should().BeEquivalentTo(new List<List<int>>
        {
            new() { 2 },
            new() { 2 },
            new() { 3 },
            new() { 4 },
            new() { 4 },
            new() { 5 },
            new() { 6 },
            new() { 7 },
            new() { 7 },
            new() { 7 },
            new() { 7, 9 },
            new() { 10 },
            new() { 10 },
            new() { 13 },
            new() { 14, 15 },
            new() { 15 },
        });
    }

    //[Test]
    //public void PossibleInputNumbersCombinationsRestrictedToFactors()
    //{
    //    var input = "* 2 3 * 4 5 6 * 7 7 * 10 10 13 * 15"
    //        .Split().Select(o => (int?)(o == "*" ? null : int.Parse(o))).ToList();

    //    var factors = new HashSet<int> { 2, 4, 7, 9, 14, 15 };

    //    var positionPossibilities = Aquaq36.FindPossibleInputNumbers2(input, 70, factors);
    //    var maxCounts = new Dictionary<int, int>();
    //    var result = Aquaq36.FindInputNumberCombinations(positionPossibilities, maxCounts);

    //    result.Should().BeEquivalentTo(new List<List<int>>
    //    {
    //        new() { 2, 2, 3, 4, 4, 5, 6, 7, 7, 7, 7, 10, 10, 13, 14, 15 },
    //        new() { 2, 2, 3, 4, 4, 5, 6, 7, 7, 7, 7, 10, 10, 13, 15, 15 },
    //        new() { 2, 2, 3, 4, 4, 5, 6, 7, 7, 7, 9, 10, 10, 13, 14, 15 },
    //        new() { 2, 2, 3, 4, 4, 5, 6, 7, 7, 7, 9, 10, 10, 13, 15, 15 },
    //    });
    //}

    //[Test]
    //public void PossibleFullInputNumbersRestrictedToFactors()
    //{
    //    var input = "* 2 3 * 4 5 6 * 7 7 * 10 10 13 * 15"
    //        .Split().Select(o => (int?)(o == "*" ? null : int.Parse(o))).ToList();

    //    var factors = new HashSet<int> { 2, 4, 7, 9, 14, 15 };

    //    var result = Aquaq36.FindPossibleInputNumbers(input, 70, factors);

    //    result.Should().BeEquivalentTo(new Dictionary<int, List<int>>
    //    {
    //        { 0, new List<int>{ 2 }},
    //        { 3, new List<int>{ 4 }},
    //        { 7, new List<int>{ 7 }},
    //        { 10, new List<int>{ 7, 9 }},
    //        { 14, new List<int>{ 14, 15 }},
    //    });

    //    var unknownIndices = result.Keys.ToList();
    //    var unknownValues = result.Values.ToList();
    //    var result2 = 
    //}
}