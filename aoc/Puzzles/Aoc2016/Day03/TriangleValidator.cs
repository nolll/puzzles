using System.Collections.Generic;
using System.Linq;

namespace Aoc.Puzzles.Aoc2016.Day03;

public class TriangleValidator
{
    public int GetHorizontalValidCount(string input)
    {
        var stringRows = input.Trim().Split('\n');
        var numberRows = stringRows.Select(GetNumbers);
        return numberRows.Count(IsValid);
    }

    public int GetVerticalValidCount(string input)
    {
        var stringRows = input.Trim().Split('\n');
        var numberRows = stringRows.Select(GetNumbers).ToList();
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

    public bool IsValid(string triangleSpec)
    {
        return IsValid(GetNumbers(triangleSpec));
    }

    private IList<int> GetNumbers(string triangleSpec)
    {
        return triangleSpec.Split(' ').Where(o => o.Length > 0).Select(int.Parse).ToList();
    }

    public bool IsValid(IList<int> triangleSpec)
    {
        var sorted = triangleSpec.OrderBy(o => o).ToList();
        return sorted[0] + sorted[1] > sorted[2];
    }
}