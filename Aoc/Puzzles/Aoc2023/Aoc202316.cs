using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2023;

[Name("The Floor Will Be Lava")]
public class Aoc202316 : AocPuzzle
{
    [Puzzle("2e8a9c0e869279c02d7e2cdcf12d40ff")]
    public int Part1(string input) => EnergizedCount(input);

    [Puzzle("67135aadd3392286aed149b56d3e6417")]
    public int Part2(string input) => MostEnergy(input);

    public int MostEnergy(string s)
    {
        var grid = GridBuilder.BuildCharGrid(s);

        var beams = new List<Beam>();
        beams.AddRange(grid.Coords.Where(o => o.Y == grid.YMin).Select(o => new Beam(o, GridDirection.Down)));
        beams.AddRange(grid.Coords.Where(o => o.X == grid.XMax).Select(o => new Beam(o, GridDirection.Left)));
        beams.AddRange(grid.Coords.Where(o => o.Y == grid.YMax).Select(o => new Beam(o, GridDirection.Up)));
        beams.AddRange(grid.Coords.Where(o => o.X == grid.XMin).Select(o => new Beam(o, GridDirection.Right)));

        var max = 0;
        foreach (var beam in beams)
        {
            var energy = EnergizedCount(grid, beam);
            max = Math.Max(energy, max);
        }

        return max;
    }

    public int EnergizedCount(string s) => 
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
            lit.Add(grid.Coord);
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
                    beams.Enqueue(new Beam(grid.Coord, grid.Direction));
                }
            }

            if (isSplitter)
            {
                if (isHorizontal)
                {
                    if(!grid.IsAtTopEdge())
                        beams.Enqueue(new Beam(grid.Coord.Up(), GridDirection.Up));
                    if (!grid.IsAtBottomEdge())
                        beams.Enqueue(new Beam(grid.Coord.Down(), GridDirection.Down));
                }
                else 
                {
                    if (!grid.IsAtRightEdge())
                        beams.Enqueue(new Beam(grid.Coord.Right(), GridDirection.Right));
                    if (!grid.IsAtLeftEdge())
                        beams.Enqueue(new Beam(grid.Coord.Left(), GridDirection.Left));
                }
            }

            if (isMirror)
            {
                var direction = GetNextDirection(beam.Direction, v);
                grid.TurnTo(direction);
                if (grid.TryMoveForward())
                    beams.Enqueue(new Beam(grid.Coord, direction));
            }
        }

        var m = new Grid<char>(grid.Width, grid.Height, '.');
        foreach (var l in lit) 
            m.WriteValueAt(l, '#');

        return lit.Count;
    }

    private static GridDirection GetNextDirection(GridDirection dir, char value) => value == '\\' 
        ? GetNextDirectionForBackslashMirror(dir) 
        : GetNextDirectionForSlashMirror(dir);

    private static GridDirection GetNextDirectionForBackslashMirror(GridDirection dir) => dir.Name switch
    {
        DirectionName.Up => GridDirection.Left,
        DirectionName.Right => GridDirection.Down,
        DirectionName.Down => GridDirection.Right,
        _ => GridDirection.Up,
    };
    
    private static GridDirection GetNextDirectionForSlashMirror(GridDirection dir) => dir.Name switch
    {
        DirectionName.Up => GridDirection.Right,
        DirectionName.Right => GridDirection.Up,
        DirectionName.Down => GridDirection.Left,
        _ => GridDirection.Down,
    };
}

public record Beam(Coord Position, GridDirection Direction);