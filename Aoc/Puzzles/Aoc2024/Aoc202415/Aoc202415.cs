using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;
using Pzl.Tools.HashSets;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2024.Aoc202415;

[Name("Warehouse Woes")]
public class Aoc202415 : AocPuzzle
{
    private static class Symbol
    {
        public const char Empty = '.';
        public const char Robot = '@';
        public const char Box = 'O';
        public const char Wall = '#';
    }
    
    public PuzzleResult Part1(string input)
    {
        var parts = input.Split(LineBreaks.Double);
        var matrix = MatrixBuilder.BuildCharMatrix(parts[0]);
        var moves = parts[1].Replace(LineBreaks.Single, "").ToCharArray();
        
        matrix.MoveTo(matrix.FindAddresses(Symbol.Robot).First());
        matrix.WriteValue(Symbol.Empty);

        var allBoxes = matrix.FindAddresses(Symbol.Box).Select(o => new BoxPart1(o)).Cast<IBox>().ToList();
        foreach (var box in allBoxes)
        {
            matrix.WriteValueAt(box.Coords.First(), Symbol.Empty);
        }
        
        foreach (var move in moves)
        {
            var direction = GetDirection(move);
            matrix.TurnTo(direction);
            var lastCoord = matrix.Address;

            var (canMove, boxesToMove) = CanMoveRobot(matrix, allBoxes, direction);
            if (!canMove)
            {
                matrix.MoveTo(lastCoord);
                continue;
            }
            
            matrix.MoveTo(lastCoord);
            matrix.MoveForward();
            
            foreach (var box in boxesToMove.Reversed())
            {
                box.Move(matrix.Direction);
            }
        }
        
        var score = allBoxes.SelectMany(box => box.Coords)
            .Aggregate(0L, (current, coord) => current + (100 * coord.Y + coord.X));

        return new PuzzleResult(score, "8b8573e47a8beee67caf8b6ab4142420");
    }

    private (bool canMove, HashSet<IBox> boxesThatMustMove) CanMoveRobot(
        Matrix<char> matrix,
        List<IBox> allBoxes,
        MatrixDirection direction)
    {
        var coordToCheck = new Coord(matrix.Address.X + direction.X, matrix.Address.Y + direction.Y);
        var v = matrix.ReadValueAt(coordToCheck);
        if (v == Symbol.Wall)
        {
            return (false, []);
        }

        var box = allBoxes.FirstOrDefault(o => o.Coords.Contains(coordToCheck));
        if (box is null)
            return (true, []);
        
        var res = CanMoveBox(matrix, allBoxes, box, direction);
        return !res.canMove 
            ? (false, []) 
            : (true, res.boxesThatMustMove);
    }
    
    private (bool canMove, HashSet<IBox> boxesThatMustMove) CanMoveBox(
        Matrix<char> matrix,
        List<IBox> allBoxes,
        IBox box,
        MatrixDirection direction)
    {
        var list = new HashSet<IBox>();
        var hasTwoCoords = box.Coords.Count == 2;
        for (var i = 0; i < box.Coords.Count; i++)
        {
            var boxCoord = box.Coords[i];
            var lookTwoAhead = i == 0 && direction.Equals(MatrixDirection.Right) ||
                               i == 1 && direction.Equals(MatrixDirection.Left);
            var steps = hasTwoCoords && lookTwoAhead
                ? 2
                : 1;
            var coordToCheck = new Coord(boxCoord.X + direction.X * steps, boxCoord.Y + direction.Y * steps);
            var v = matrix.ReadValueAt(coordToCheck);
            if (v == Symbol.Wall)
            {
                return (false, []);
            }

            var subBox = allBoxes.FirstOrDefault(o => o.Coords.Contains(coordToCheck));
            if (subBox is not null)
            {
                var res = CanMoveBox(matrix, allBoxes, subBox, direction);
                if (!res.canMove)
                    return (false, []);
                list.AddRange(res.boxesThatMustMove);
            }
        }

        return (true, [..list, box]);
    }

    private MatrixDirection GetDirection(char dir) =>
        dir switch
        {
            '^' => MatrixDirection.Up,
            '>' => MatrixDirection.Right,
            'v' => MatrixDirection.Down,
            _ => MatrixDirection.Left
        };

    public PuzzleResult Part2(string input)
    {
        var parts = input.Split(LineBreaks.Double);
        var matrix = MatrixBuilder.BuildCharMatrix(parts[0]);
        var moves = parts[1].Replace(LineBreaks.Single, "").ToCharArray();
        
        matrix.MoveTo(matrix.FindAddresses(Symbol.Robot).First());
        matrix.WriteValue(Symbol.Empty);

        var boxCoords = matrix.FindAddresses(Symbol.Box); 
        foreach (var coord in boxCoords)
        {
            matrix.WriteValueAt(coord, Symbol.Empty);
        }

        var wideMatrix = new Matrix<char>(matrix.Width * 2, matrix.Height, Symbol.Empty);
        var walls = matrix.FindAddresses(Symbol.Wall);
        foreach (var wall in walls)
        {
            wideMatrix.WriteValueAt(new Coord(wall.X * 2, wall.Y), Symbol.Wall);
            wideMatrix.WriteValueAt(new Coord(wall.X * 2 + 1, wall.Y), Symbol.Wall);
        }

        wideMatrix.MoveTo(new Coord(matrix.Address.X * 2, matrix.Address.Y));
        var allBoxes = boxCoords
            .Select(o => new BoxPart2([new Coord(o.X * 2, o.Y), new Coord(o.X * 2 + 1, o.Y)]))
            .Cast<IBox>().ToList();
        
        matrix = wideMatrix;
        
        foreach (var move in moves)
        {
            var direction = GetDirection(move);
            matrix.TurnTo(direction);
            var lastCoord = matrix.Address;

            var (canMove, boxesToMove) = CanMoveRobot(matrix, allBoxes, direction);
            if (!canMove)
            {
                matrix.MoveTo(lastCoord);
                continue;
            }
            
            matrix.MoveTo(lastCoord);
            matrix.MoveForward();
            
            foreach (var box in boxesToMove.Reversed())
            {
                box.Move(matrix.Direction);
            }
        }
        
        var score = allBoxes.SelectMany(box => box.Coords.Take(1))
            .Aggregate(0L, (current, coord) => current + (100 * coord.Y + coord.X));

        return new PuzzleResult(score, "48a79a74450762d492fd151f9c3c6400");
    }

    public interface IBox
    {
        public List<Coord> Coords { get; }
        public void Move(MatrixDirection dir);
    }
    
    private class BoxPart1(Coord coord) : IBox
    {
        private Coord _coord = coord;
        public List<Coord> Coords => [_coord];
        
        public void Move(MatrixDirection dir)
        {
            _coord = new Coord(_coord.X + dir.X, _coord.Y + dir.Y);
        }
    }
    
    private class BoxPart2(List<Coord> coords) : IBox
    {
        public List<Coord> Coords { get; } = coords;

        public void Move(MatrixDirection dir)
        {
            for (var i = 0; i < Coords.Count; i++)
            {
                Coords[i] = new Coord(Coords[i].X + dir.X, Coords[i].Y + dir.Y);
            }
        }
    }
}