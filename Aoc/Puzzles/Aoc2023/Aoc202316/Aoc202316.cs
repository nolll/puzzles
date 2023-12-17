using Pzl.Common;
using Pzl.Tools.CoordinateSystems.CoordinateSystem2D;

namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202316;

[Name("The Floor Will Be Lava")]
public class Aoc202316(string input) : AocPuzzle
{
    protected override PuzzleResult RunPart1()
    {
        var result = EnergizedCount(input);

        return new PuzzleResult(result, "2e8a9c0e869279c02d7e2cdcf12d40ff");
    }

    protected override PuzzleResult RunPart2()
    {
        var result = MostEnergy(input);

        return new PuzzleResult(result);
    }

    public static int MostEnergy(string s)
    {
        var matrix = MatrixBuilder.BuildCharMatrix(s);

        var beams = new List<Beam>();
        beams.AddRange(matrix.Coords.Where(o => o.Y == matrix.YMin).Select(o => new Beam(o, MatrixDirection.Down)));
        beams.AddRange(matrix.Coords.Where(o => o.X == matrix.XMax).Select(o => new Beam(o, MatrixDirection.Left)));
        beams.AddRange(matrix.Coords.Where(o => o.Y == matrix.YMax).Select(o => new Beam(o, MatrixDirection.Up)));
        beams.AddRange(matrix.Coords.Where(o => o.X == matrix.XMin).Select(o => new Beam(o, MatrixDirection.Right)));

        var max = 0;
        foreach (var beam in beams)
        {
            var energy = EnergizedCount(matrix, beam);
            max = Math.Max(energy, max);
        }

        return max;
    }

    public static int EnergizedCount(string s) => 
        EnergizedCount(MatrixBuilder.BuildCharMatrix(s), new Beam(new MatrixAddress(0, 0), MatrixDirection.Right));

    public static int EnergizedCount(Matrix<char> matrix, Beam start)
    {
        var lit = new HashSet<MatrixAddress>();
        var beams = new Queue<Beam>();
        beams.Enqueue(start);
        var seen = new HashSet<(MatrixAddress, string)>();

        while (beams.Count > 0)
        {
            var beam = beams.Dequeue();
            if (seen.Contains((beam.Position, beam.Direction.Name)))
                continue;

            matrix.MoveTo(beam.Position);
            seen.Add((beam.Position, beam.Direction.Name));
            lit.Add(matrix.Address);
            var v = matrix.ReadValue();
            var isHorizontal = beam.Direction.Equals(MatrixDirection.Left) ||
                               beam.Direction.Equals(MatrixDirection.Right);
            var isVertical = !isHorizontal;
            var isPass = v == '.' || isHorizontal && v == '-' || isVertical && v == '|';
            var isMirror = v is '/' or '\\';
            var isSplitter = isHorizontal && v == '|' || isVertical && v == '-';
            if (isPass)
            {
                matrix.TurnTo(beam.Direction);
                var moved = matrix.TryMoveForward();
                if (moved)
                {
                    beams.Enqueue(new Beam(matrix.Address, matrix.Direction));
                }
            }

            if (isSplitter)
            {
                if (isHorizontal)
                {
                    if(!matrix.IsAtTopEdge)
                        beams.Enqueue(new Beam(new MatrixAddress(matrix.Address.X, matrix.Address.Y - 1), MatrixDirection.Up));
                    if (!matrix.IsAtBottomEdge)
                        beams.Enqueue(new Beam(new MatrixAddress(matrix.Address.X, matrix.Address.Y + 1), MatrixDirection.Down));
                }
                else 
                {
                    if (!matrix.IsAtRightEdge)
                        beams.Enqueue(new Beam(new MatrixAddress(matrix.Address.X + 1, matrix.Address.Y), MatrixDirection.Right));
                    if (!matrix.IsAtLeftEdge)
                        beams.Enqueue(new Beam(new MatrixAddress(matrix.Address.X - 1, matrix.Address.Y), MatrixDirection.Left));
                }
            }

            if (isMirror)
            {
                if (beam.Direction.Equals(MatrixDirection.Up))
                {
                    var direction = v == '\\' ? MatrixDirection.Left : MatrixDirection.Right;
                    matrix.TurnTo(direction);
                    if (matrix.TryMoveForward())
                        beams.Enqueue(new Beam(matrix.Address, direction));
                }
                else if (beam.Direction.Equals(MatrixDirection.Right))
                {
                    var direction = v == '\\' ? MatrixDirection.Down : MatrixDirection.Up;
                    matrix.TurnTo(direction);
                    if (matrix.TryMoveForward())
                        beams.Enqueue(new Beam(matrix.Address, direction));
                }
                else if (beam.Direction.Equals(MatrixDirection.Down))
                {
                    var direction = v == '\\' ? MatrixDirection.Right : MatrixDirection.Left;
                    matrix.TurnTo(direction);
                    if (matrix.TryMoveForward())
                        beams.Enqueue(new Beam(matrix.Address, direction));
                }
                else
                {
                    var direction = v == '\\' ? MatrixDirection.Up : MatrixDirection.Down;
                    matrix.TurnTo(direction);
                    if (matrix.TryMoveForward())
                        beams.Enqueue(new Beam(matrix.Address, direction));
                }
            }
        }

        var m = new Matrix<char>(matrix.Width, matrix.Height, '.');
        foreach (var l in lit)
        {
            m.WriteValueAt(l, '#');
        }

        return lit.Count;
    }
}

public class Beam
{
    public MatrixAddress Position { get; }
    public MatrixDirection Direction { get; }

    public Beam(MatrixAddress position, MatrixDirection direction)
    {
        Position = position;
        Direction = direction;
    }
}