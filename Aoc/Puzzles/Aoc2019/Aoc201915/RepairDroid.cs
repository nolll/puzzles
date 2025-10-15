using Pzl.Tools.Computers.IntCode;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201915;

public class RepairDroid
{
    private const int HitWall = 0;
    private const int Moved = 1;
    private const int Found = 2;

    private IntCodeComputer _computer;
    private readonly Grid<char> _grid;
    private readonly Queue<(Coord, GridDirection, IntCodeComputer)> _queue;
    private Coord _target = new Coord(0, 0);

    public RepairDroid(string program)
    {
        _computer = new IntCodeComputer(MemoryParser.Parse(program), ReadInput, WriteOutput);
        _grid = new Grid<char>(defaultValue: ' ');
        _queue = new Queue<(Coord, GridDirection, IntCodeComputer)>();
    }

    public (int, Grid<char>) Run()
    {
        _computer.Start();

        while (_queue.Any())
        {
            var (address, direction, computer) = _queue.Dequeue();
            _grid.MoveTo(address);
            _grid.TurnTo(direction);
            _computer = computer;
            computer.Start();
        }

        _grid.MoveTo(_grid.StartCoord);

        var path = PathFinder.ShortestPathTo(_grid, _grid.StartCoord, _target);
        return (path.Count(), _grid);
    }

    private long ReadInput()
    {
        return (int)GetDroidDirection();
    }

    private bool WriteOutput(long output)
    {
        switch (output)
        {
            case HitWall:
                _grid.MoveForward();
                _grid.WriteValue('#');
                _grid.MoveBackward();
                break;
            case Moved:
                _grid.MoveForward();
                _grid.WriteValue('.');
                break;
            case Found:
                _grid.MoveForward();
                _grid.WriteValue('X');
                _target = _grid.Coord;
                break;
        }

        var directions = FindUnvisitedDirections();
        _computer.Stop();
        foreach (var direction in directions)
        {
            _queue.Enqueue((_grid.Coord, direction, _computer.Clone()));
        }
        
        return false;
    }

    private IEnumerable<GridDirection> FindUnvisitedDirections()
    {
        var directions = new List<GridDirection>();
        
        _grid.MoveForward();
        if (_grid.ReadValue() == ' ')
            directions.Add(_grid.Direction);
        _grid.MoveBackward();
        _grid.TurnRight();

        _grid.MoveForward();
        if (_grid.ReadValue() == ' ')
            directions.Add(_grid.Direction);
        _grid.MoveBackward();
        _grid.TurnRight();

        _grid.MoveForward();
        if (_grid.ReadValue() == ' ')
            directions.Add(_grid.Direction);
        _grid.MoveBackward();
        _grid.TurnRight();

        _grid.MoveForward();
        if (_grid.ReadValue() == ' ')
            directions.Add(_grid.Direction);
        _grid.MoveBackward();
        _grid.TurnRight();

        return directions;
    }

    private DroidDirection GetDroidDirection()
    {
        if (_grid.Direction.Equals(GridDirection.Right))
            return DroidDirection.East;
        if (_grid.Direction.Equals(GridDirection.Down))
            return DroidDirection.South;
        if (_grid.Direction.Equals(GridDirection.Left))
            return DroidDirection.West;
        return DroidDirection.North;
    }
}