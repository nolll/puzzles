using Pzl.Common;
using Pzl.Tools.Computers.IntCode;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2019;

[Name("Oxygen System")]
public class Aoc201915 : AocPuzzle
{
    [Puzzle("d20cf84c4da08d20e303bd7439d54765")]
    public int Part1(string input)
    {
        var (result, _) = Run(input);
        return result;
    }

    [Puzzle("d728ed642372031f836424a9f131f6f2")]
    public int Part2(string input)
    {
        var (_, map) = Run(input);
        return Fill(map);
    }

    private const int HitWall = 0;
    private const int Moved = 1;
    private const int Found = 2;

    private Coord _target = new(0, 0);

    private (int, Grid<char>) Run(string input)
    {
        var grid = new Grid<char>(defaultValue: ' ');
        var queue = new Queue<(Coord, GridDirection, IntCodeComputer)>();

        var container = new ComputerContainer();
        var computer = new IntCodeComputer(MemoryParser.Parse(input))
        {
            ReadInput = () => (int)GetDroidDirection(grid),
            WriteOutput = WriteOutput
        };
        container.Computer = computer;
        computer.Start();

        while (queue.Any())
        {
            var (address, direction, newComputer) = queue.Dequeue();
            grid.MoveTo(address);
            grid.TurnTo(direction);
            container.Computer = newComputer;
            newComputer.Start();
        }

        grid.MoveTo(grid.StartCoord);

        var path = PathFinder.ShortestPathTo(grid, grid.StartCoord, _target);
        return (path.Count(), grid);

        bool WriteOutput(long output)
        {
            switch (output)
            {
                case HitWall:
                    grid.MoveForward();
                    grid.WriteValue('#');
                    grid.MoveBackward();
                    break;
                case Moved:
                    grid.MoveForward();
                    grid.WriteValue('.');
                    break;
                case Found:
                    grid.MoveForward();
                    grid.WriteValue('X');
                    _target = grid.Coord;
                    break;
            }

            var directions = FindUnvisitedDirections(grid);
            container.Computer.Stop();
            foreach (var direction in directions)
            {
                queue.Enqueue((grid.Coord, direction, container.Computer.Clone()));
            }

            return false;
        }
    }

    private class ComputerContainer
    {
        public IntCodeComputer Computer { get; set; } = null!;
    }

    private IEnumerable<GridDirection> FindUnvisitedDirections(Grid<char> grid)
    {
        var directions = new List<GridDirection>();

        grid.MoveForward();
        if (grid.ReadValue() == ' ')
            directions.Add(grid.Direction);
        grid.MoveBackward();
        grid.TurnRight();

        grid.MoveForward();
        if (grid.ReadValue() == ' ')
            directions.Add(grid.Direction);
        grid.MoveBackward();
        grid.TurnRight();

        grid.MoveForward();
        if (grid.ReadValue() == ' ')
            directions.Add(grid.Direction);
        grid.MoveBackward();
        grid.TurnRight();

        grid.MoveForward();
        if (grid.ReadValue() == ' ')
            directions.Add(grid.Direction);
        grid.MoveBackward();
        grid.TurnRight();

        return directions;
    }

    private DroidDirection GetDroidDirection(Grid<char> grid)
    {
        if (grid.Direction.Equals(GridDirection.Right))
            return DroidDirection.East;
        if (grid.Direction.Equals(GridDirection.Down))
            return DroidDirection.South;
        if (grid.Direction.Equals(GridDirection.Left))
            return DroidDirection.West;
        return DroidDirection.North;
    }

    private enum DroidDirection
    {
        North = 1,
        South = 2,
        West = 3,
        East = 4
    }
    
    public int Fill(string map) => Fill(GridBuilder.BuildCharGrid(map.Replace(' ', '#'), ' '));

    public int Fill(Grid<char> grid)
    {
        grid.MoveTo(grid.StartCoord);
        grid.TurnTo(GridDirection.Up);
        var iterations = 0;
        var recentlyFilledAddresses = grid.FindCoords('X');
        while (grid.Values.Any(o => o == '.'))
        {
            var addressesToFill = new List<Coord>();
            foreach (var a in recentlyFilledAddresses)
            {
                var validAddresses = grid.OrthogonalAdjacentCoordsTo(a).Where(o => grid.ReadValueAt(o) == '.');
                addressesToFill.AddRange(validAddresses);
            }

            recentlyFilledAddresses.Clear();
            foreach (var atf in addressesToFill)
            {
                grid.WriteValueAt(atf, 'O');
                recentlyFilledAddresses.Add(atf);
            }

            iterations += 1;
        }

        return iterations;
    }
}