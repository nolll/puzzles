using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2016;

[Name("Squares With Three Sides")]
public class Aoc201603 : AocPuzzle
{
    [Puzzle("186855295ba3afb3c13eac2a74cafde4")]
    public int Part1(string input) => GetHorizontalValidCount(input);

    [Puzzle("5c4c8d0e219270ef31fae71b72afd00e")]
    public int Part2(string input) => GetVerticalValidCount(input);
    
    public int GetHorizontalValidCount(string input) => 
        input.Trim().Split(LineBreaks.Single).Select(GetNumbers).Count(IsValid);

    public int GetVerticalValidCount(string input)
    {
        var numberRows = input.Trim().Split(LineBreaks.Single).Select(GetNumbers).ToList();
        var validCount = 0;
        while (numberRows.Any())
        {
            var currentRows = numberRows.Take(3).ToList();
            numberRows = numberRows.Skip(3).ToList();
            for (var i = 0; i < 3; i++)
            {
                var triangle = new List<int> { currentRows[0][i], currentRows[1][i], currentRows[2][i] };
                if (IsValid(triangle))
                    validCount += 1;
            }
        }
        return validCount;
    }
    
    public bool IsValid(string triangleSpec) => IsValid(GetNumbers(triangleSpec));

    private static IList<int> GetNumbers(string triangleSpec) => 
        triangleSpec.Split(' ').Where(o => o.Length > 0).Select(int.Parse).ToList();

    private static bool IsValid(IList<int> triangleSpec)
    {
        var sorted = triangleSpec.OrderBy(o => o).ToList();
        return sorted[0] + sorted[1] > sorted[2];
    }
}