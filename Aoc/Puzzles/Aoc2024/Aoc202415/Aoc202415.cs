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
        var grid = GridBuilder.BuildCharGrid(parts[0]);
        var moves = parts[1].Replace(LineBreaks.Single, "").ToCharArray();
        
        grid.MoveTo(grid.FindAddresses(Symbol.Robot).First());
        grid.WriteValue(Symbol.Empty);

        var allBoxes = grid.FindAddresses(Symbol.Box).Select(o => new BoxPart1(o)).Cast<IBox>().ToList();
        foreach (var box in allBoxes)
        {
            grid.WriteValueAt(box.Coords.First(), Symbol.Empty);
        }
        
        foreach (var move in moves)
        {
            var direction = GetDirection(move);
            grid.TurnTo(direction);
            var lastCoord = grid.Coord;

            var (canMove, boxesToMove) = CanMoveRobot(grid, allBoxes, direction);
            if (!canMove)
            {
                grid.MoveTo(lastCoord);
                continue;
            }
            
            grid.MoveTo(lastCoord);
            grid.MoveForward();
            
            foreach (var box in boxesToMove.Reversed())
            {
                box.Move(grid.Direction);
            }
        }
        
        var score = allBoxes.SelectMany(box => box.Coords)
            .Aggregate(0L, (current, coord) => current + (100 * coord.Y + coord.X));

        return new PuzzleResult(score, "8b8573e47a8beee67caf8b6ab4142420");
    }

    private (bool canMove, HashSet<IBox> boxesThatMustMove) CanMoveRobot(
        Grid<char> grid,
        List<IBox> allBoxes,
        GridDirection direction)
    {
        var coordToCheck = new Coord(grid.Coord.X + direction.X, grid.Coord.Y + direction.Y);
        var v = grid.ReadValueAt(coordToCheck);
        if (v == Symbol.Wall)
        {
            return (false, []);
        }

        var box = allBoxes.FirstOrDefault(o => o.Coords.Contains(coordToCheck));
        if (box is null)
            return (true, []);
        
        var res = CanMoveBox(grid, allBoxes, box, direction);
        return !res.canMove 
            ? (false, []) 
            : (true, res.boxesThatMustMove);
    }
    
    private (bool canMove, HashSet<IBox> boxesThatMustMove) CanMoveBox(
        Grid<char> grid,
        List<IBox> allBoxes,
        IBox box,
        GridDirection direction)
    {
        var list = new HashSet<IBox>();
        var hasTwoCoords = box.Coords.Count == 2;
        for (var i = 0; i < box.Coords.Count; i++)
        {
            var boxCoord = box.Coords[i];
            var lookTwoAhead = i == 0 && direction.Equals(GridDirection.Right) ||
                               i == 1 && direction.Equals(GridDirection.Left);
            var steps = hasTwoCoords && lookTwoAhead
                ? 2
                : 1;
            var coordToCheck = new Coord(boxCoord.X + direction.X * steps, boxCoord.Y + direction.Y * steps);
            var v = grid.ReadValueAt(coordToCheck);
            if (v == Symbol.Wall)
            {
                return (false, []);
            }

            var subBox = allBoxes.FirstOrDefault(o => o.Coords.Contains(coordToCheck));
            if (subBox is not null)
            {
                var res = CanMoveBox(grid, allBoxes, subBox, direction);
                if (!res.canMove)
                    return (false, []);
                list.AddRange(res.boxesThatMustMove);
            }
        }

        return (true, [..list, box]);
    }

    private GridDirection GetDirection(char dir) =>
        dir switch
        {
            '^' => GridDirection.Up,
            '>' => GridDirection.Right,
            'v' => GridDirection.Down,
            _ => GridDirection.Left
        };

    public PuzzleResult Part2(string input)
    {
        var parts = input.Split(LineBreaks.Double);
        var grid = GridBuilder.BuildCharGrid(parts[0]);
        var moves = parts[1].Replace(LineBreaks.Single, "").ToCharArray();
        
        grid.MoveTo(grid.FindAddresses(Symbol.Robot).First());
        grid.WriteValue(Symbol.Empty);

        var boxCoords = grid.FindAddresses(Symbol.Box); 
        foreach (var coord in boxCoords)
        {
            grid.WriteValueAt(coord, Symbol.Empty);
        }

        var wideGrid = new Grid<char>(grid.Width * 2, grid.Height, Symbol.Empty);
        var walls = grid.FindAddresses(Symbol.Wall);
        foreach (var wall in walls)
        {
            wideGrid.WriteValueAt(new Coord(wall.X * 2, wall.Y), Symbol.Wall);
            wideGrid.WriteValueAt(new Coord(wall.X * 2 + 1, wall.Y), Symbol.Wall);
        }

        wideGrid.MoveTo(new Coord(grid.Coord.X * 2, grid.Coord.Y));
        var allBoxes = boxCoords
            .Select(o => new BoxPart2([new Coord(o.X * 2, o.Y), new Coord(o.X * 2 + 1, o.Y)]))
            .Cast<IBox>().ToList();
        
        grid = wideGrid;
        
        foreach (var move in moves)
        {
            var direction = GetDirection(move);
            grid.TurnTo(direction);
            var lastCoord = grid.Coord;

            var (canMove, boxesToMove) = CanMoveRobot(grid, allBoxes, direction);
            if (!canMove)
            {
                grid.MoveTo(lastCoord);
                continue;
            }
            
            grid.MoveTo(lastCoord);
            grid.MoveForward();
            
            foreach (var box in boxesToMove.Reversed())
            {
                box.Move(grid.Direction);
            }
        }
        
        var score = allBoxes.SelectMany(box => box.Coords.Take(1))
            .Aggregate(0L, (current, coord) => current + (100 * coord.Y + coord.X));

        return new PuzzleResult(score, "48a79a74450762d492fd151f9c3c6400");
    }

    public interface IBox
    {
        public List<Coord> Coords { get; }
        public void Move(GridDirection dir);
    }
    
    private class BoxPart1(Coord coord) : IBox
    {
        private Coord _coord = coord;
        public List<Coord> Coords => [_coord];
        
        public void Move(GridDirection dir)
        {
            _coord = new Coord(_coord.X + dir.X, _coord.Y + dir.Y);
        }
    }
    
    private class BoxPart2(List<Coord> coords) : IBox
    {
        public List<Coord> Coords { get; } = coords;

        public void Move(GridDirection dir)
        {
            for (var i = 0; i < Coords.Count; i++)
            {
                Coords[i] = new Coord(Coords[i].X + dir.X, Coords[i].Y + dir.Y);
            }
        }
    }
}