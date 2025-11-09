using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Euler.Puzzles.Euler018;

[Name("Maximum path sum I")]
public class Euler018 : EulerPuzzle
{
    public PuzzleResult Run(string input)
    {
        var triangle = BuildTriangle(input);
        var sum = triangle.First().First().BestPath;
        return new PuzzleResult(sum, "ac0ed37fe47b088e57246f49e0564317");
    }

    private static IEnumerable<List<TriangleNode>> BuildTriangle(string triangleString)
    {
        var lines = triangleString.Split(LineBreaks.Single);
        var triangle = new List<List<TriangleNode>>();
        foreach (var line in lines)
        {
            var numbers = line
                .Trim()
                .Replace("  ", " ")
                .Split(' ')
                .Select(o => o.TrimStart('0'))
                .Select(o => new TriangleNode(int.Parse(o)))
                .ToList();
            triangle.Add(numbers);
        }

        for (var i = 0; i < triangle.Count - 1; i++)
        {
            var currentRow = triangle[i];
            var nextRow = triangle[i + 1];

            for (var j = 0; j < currentRow.Count; j++)
            {
                var currentNode = currentRow[j];
                var childA = nextRow[j];
                var childB = nextRow[j + 1];
                currentNode.AddChild(childA);
                currentNode.AddChild(childB);
            }
        }

        return triangle;
    }

    protected class TriangleNode(int value)
    {
        private int? _bestPath;

        private int Value { get; } = value;
        private List<TriangleNode> Children { get; } = new();

        public int BestPath
        {
            get
            {
                _bestPath ??= Children.Any()
                    ? Value + Children.Max(o => o.BestPath)
                    : Value;

                return _bestPath.Value;
            }
        }

        public void AddChild(TriangleNode triangleNode) => Children.Add(triangleNode);
    }
}