using System.Collections.Generic;
using System.Linq;

namespace Core.ImpossibleTriangles
{
    public class TriangleValidator
    {
        public int GetValidCount(string input)
        {
            var rows = input.Split('\n');
            return rows.Count(o => IsValid((string) o.Trim()));
        }

        public bool IsValid(string triangleSpec)
        {
            return IsValid(triangleSpec.Replace("\t", " ").Split(' ').Where(o => o.Length > 0).Select(int.Parse).ToList());
        }

        public bool IsValid(IList<int> triangleSpec)
        {
            var sorted = triangleSpec.OrderBy(o => o).ToList();
            return sorted[0] + sorted[1] > sorted[2];
        }
    }
}