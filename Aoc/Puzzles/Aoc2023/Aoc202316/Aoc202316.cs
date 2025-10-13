using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202316;

[Name("The Floor Will Be Lava")]
public class Aoc202316 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var result = EnergizedCount(input);

        return new PuzzleResult(result, "2e8a9c0e869279c02d7e2cdcf12d40ff");
    }

    public PuzzleResult RunPart2(string input)
    {
        var result = MostEnergy(input);

        return new PuzzleResult(result, "67135aadd3392286aed149b56d3e6417");
    }

    public static int MostEnergy(string s)
    {
        var matrix = GridBuilder.BuildCharGrid(s);

        var beams = new List<Beam>();
        beams.AddRange(matrix.Coords.Where(o => o.Y == matrix.YMin).Select(o => new Beam(o, GridDirection.Down)));
        beams.AddRange(matrix.Coords.Where(o => o.X == matrix.XMax).Select(o => new Beam(o, GridDirection.Left)));
        beams.AddRange(matrix.Coords.Where(o => o.Y == matrix.YMax).Select(o => new Beam(o, GridDirection.Up)));
        beams.AddRange(matrix.Coords.Where(o => o.X == matrix.XMin).Select(o => new Beam(o, GridDirection.Right)));

        var max = 0;
        foreach (var beam in beams)
        {
            var energy = EnergizedCount(matrix, beam);
            max = Math.Max(energy, max);
        }

        return max;
    }

    public static int EnergizedCount(string s) => 
        EnergizedCount(GridBuilder.BuildCharGrid(s), new Beam(new Coord(0, 0), GridDirection.Right));

    public static int EnergizedCount(Grid<char> grid, Beam start)
    {
        var lit = new HashSet<Coord>();
        var beams = new Queue<Beam>();
        beams.Enqueue(start);
        var seen = new HashSet<(Coord, char)>();

        while (beams.Count > 0)
        {
            var beam = beams.Dequeue();
            if (seen.Contains((beam.Position, beam.Direction.Name)))
                continue;

            grid.MoveTo(beam.Position);
            seen.Add((beam.Position, beam.Direction.Name));
            lit.Add(grid.Address);
            var v = grid.ReadValue();
            var isHorizontal = beam.Direction.Equals(GridDirection.Left) ||
                               beam.Direction.Equals(GridDirection.Right);
            var isVertical = !isHorizontal;
            var isPass = v == '.' || isHorizontal && v == '-' || isVertical && v == '|';
            var isMirror = v is '/' or '\\';
            var isSplitter = isHorizontal && v == '|' || isVertical && v == '-';
            if (isPass)
            {
                grid.TurnTo(beam.Direction);
                var moved = grid.TryMoveForward();
                if (moved)
                {
                    beams.Enqueue(new Beam(grid.Address, grid.Direction));
                }
            }

            if (isSplitter)
            {
                if (isHorizontal)
                {
                    if(!grid.IsAtTopEdge)
                        beams.Enqueue(new Beam(new Coord(grid.Address.X, grid.Address.Y - 1), GridDirection.Up));
                    if (!grid.IsAtBottomEdge)
                        beams.Enqueue(new Beam(new Coord(grid.Address.X, grid.Address.Y + 1), GridDirection.Down));
                }
                else 
                {
                    if (!grid.IsAtRightEdge)
                        beams.Enqueue(new Beam(new Coord(grid.Address.X + 1, grid.Address.Y), GridDirection.Right));
                    if (!grid.IsAtLeftEdge)
                        beams.Enqueue(new Beam(new Coord(grid.Address.X - 1, grid.Address.Y), GridDirection.Left));
                }
            }

            if (isMirror)
            {
                if (beam.Direction.Equals(GridDirection.Up))
                {
                    var direction = v == '\\' ? GridDirection.Left : GridDirection.Right;
                    grid.TurnTo(direction);
                    if (grid.TryMoveForward())
                        beams.Enqueue(new Beam(grid.Address, direction));
                }
                else if (beam.Direction.Equals(GridDirection.Right))
                {
                    var direction = v == '\\' ? GridDirection.Down : GridDirection.Up;
                    grid.TurnTo(direction);
                    if (grid.TryMoveForward())
                        beams.Enqueue(new Beam(grid.Address, direction));
                }
                else if (beam.Direction.Equals(GridDirection.Down))
                {
                    var direction = v == '\\' ? GridDirection.Right : GridDirection.Left;
                    grid.TurnTo(direction);
                    if (grid.TryMoveForward())
                        beams.Enqueue(new Beam(grid.Address, direction));
                }
                else
                {
                    var direction = v == '\\' ? GridDirection.Up : GridDirection.Down;
                    grid.TurnTo(direction);
                    if (grid.TryMoveForward())
                        beams.Enqueue(new Beam(grid.Address, direction));
                }
            }
        }

        var m = new Grid<char>(grid.Width, grid.Height, '.');
        foreach (var l in lit)
        {
            m.WriteValueAt(l, '#');
        }

        return lit.Count;
    }
}

public class Beam
{
    public Coord Position { get; }
    public GridDirection Direction { get; }

    public Beam(Coord position, GridDirection direction)
    {
        Position = position;
        Direction = direction;
    }
}