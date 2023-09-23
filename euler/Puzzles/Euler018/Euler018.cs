using Common.Puzzles;
using Common.Strings;

namespace Euler.Puzzles.Euler018;

public class Euler018 : EulerPuzzle
{
    public override string Name => "Maximum path sum I";

    public override PuzzleResult Run()
    {
        var result = Run(Triangle);
        return new PuzzleResult(result, 1074);
    }

    public int Run(string triangleString)
    {
        var triangle = BuildTriangle(triangleString);
        var sum = triangle.First().First().BestPath;
           
        return sum;
    }

    private static IEnumerable<List<TriangleNode>> BuildTriangle(string triangleString)
    {
        var lines = InputReader.ReadLines(triangleString);
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

    protected class TriangleNode
    {
        private int? _bestPath;

        private int Value { get; }
        private List<TriangleNode> Children { get; } = new();

        public int BestPath
        {
            get
            {
                if (_bestPath == null)
                {
                    _bestPath = Children.Any()
                        ? Value + Children.Max(o => o.BestPath)
                        : Value;
                }

                return _bestPath.Value;
            }
        }

        public TriangleNode(int value)
        {
            Value = value;
        }

        public void AddChild(TriangleNode triangleNode)
        {
            Children.Add(triangleNode);
        }
    }

    private const string Triangle = @"
75
95 64
17 47 82
18 35 87 10
20 04 82 47 65
19 01 23 75 03 34
88 02 77 73 07 63 67
99 65 04 28 06 16 70 92
41 41 26 56 83 40 80 70 33
41 48 72 33 47 32 37 16 94 29
53 71 44 65 25 43 91 52 97 51 14
70 11 33 28 77 73 17 78 39 68 17 57
91 71 52 38 17 14 91 43 58 50 27 29 48
63 66 04 68 89 53 67 30 73 16 69 87 40 31
04 62 98 27 23 09 70 98 73 93 38 53 60 04 23";
}