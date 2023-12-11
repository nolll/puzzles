using Pzl.Tools.CoordinateSystems.CoordinateSystem2D;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202212;

public class HillClimbing
{
    public int Part1(string input)
    {
        var matrix = MatrixBuilder.BuildCharMatrix(input);
        var from = FindFromCoord(matrix);
        var to = FindToCoord(matrix);
        matrix.WriteValueAt(from, 'a');
        matrix.WriteValueAt(to, 'z');
        var steps = StepCountTo(matrix, from, to);

        return steps;
    }

    public int Part2(string input)
    {
        var matrix = MatrixBuilder.BuildCharMatrix(input);
        var from = FindFromCoord(matrix); 
        var to = FindToCoord(matrix);
        matrix.WriteValueAt(from, 'a');
        matrix.WriteValueAt(to, 'z');
        var startingPoints = matrix.Coords.Where(coord => matrix.ReadValueAt(coord) == 'a').ToList();
        var stepCount = StepCountTo(matrix, startingPoints, to);
        return stepCount;
    }

    private static MatrixAddress FindFromCoord(Matrix<char> matrix) => matrix.Coords.First(o => matrix.ReadValueAt(o) == 'S');
    private static MatrixAddress FindToCoord(Matrix<char> matrix) => matrix.Coords.First(o => matrix.ReadValueAt(o) == 'E');

    private static int StepCountTo(Matrix<char> matrix, MatrixAddress from, MatrixAddress to) =>
        StepCountTo(matrix, new List<MatrixAddress> { from }, to);

    private static int StepCountTo(Matrix<char> matrix, IList<MatrixAddress> from, MatrixAddress to)
    {
        var coordCounts = GetCoordCounts(matrix, from, to);
        var goal = coordCounts.FirstOrDefault(o => o.X == to.X && o.Y == to.Y);
        return goal?.Count ?? 0;
    }
    
    private static IList<CoordCount> GetCoordCounts(Matrix<char> matrix, IList<MatrixAddress> from, MatrixAddress to)
    {
        var seen = from.ToDictionary(k => k, v => 0);
        var queue = new Queue<MatrixAddress>(from);
        while (queue.Count > 0 && !seen.ContainsKey(to))
        {
            var next = queue.Dequeue();
            var count = seen[next];
            var adjacentCoords = matrix.OrthogonalAdjacentCoordsTo(next)
                .Where(o => !seen.ContainsKey(o) && matrix.ReadValueAt(o) - matrix.ReadValueAt(next) <= 1);
            foreach (var adjacentCoord in adjacentCoords)
            {
                queue.Enqueue(adjacentCoord);
                seen[adjacentCoord] = count + 1;
            }
        }

        return seen.Select(o => new CoordCount(o.Key, o.Value)).ToList();
    }
}