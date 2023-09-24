using System.Collections.Generic;
using System.Linq;
using Common.Computers.IntCode;
using Common.CoordinateSystems.CoordinateSystem2D;

namespace Aoc.Puzzles.Aoc2019.Aoc201915;

public class RepairDroid
{
    private const int HitWall = 0;
    private const int Moved = 1;
    private const int Found = 2;

    private IntCodeComputer _computer;
    private readonly Matrix<char> _matrix;
    private readonly Queue<(MatrixAddress, MatrixDirection, IntCodeComputer)> _queue;
    private MatrixAddress _target = new MatrixAddress(0, 0);

    public RepairDroid(string program)
    {
        _computer = new IntCodeComputer(MemoryParser.Parse(program), ReadInput, WriteOutput);
        _matrix = new Matrix<char>(defaultValue: ' ');
        _queue = new Queue<(MatrixAddress, MatrixDirection, IntCodeComputer)>();
    }

    public (int, Matrix<char>) Run()
    {
        _computer.Start();

        while (_queue.Any())
        {
            var (address, direction, computer) = _queue.Dequeue();
            _matrix.MoveTo(address);
            _matrix.TurnTo(direction);
            _computer = computer;
            computer.Start();
        }

        _matrix.MoveTo(_matrix.StartAddress);

        var path = PathFinder.ShortestPathTo(_matrix, _matrix.StartAddress, _target);
        return (path.Count, _matrix);
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
                _matrix.MoveForward();
                _matrix.WriteValue('#');
                _matrix.MoveBackward();
                break;
            case Moved:
                _matrix.MoveForward();
                _matrix.WriteValue('.');
                break;
            case Found:
                _matrix.MoveForward();
                _matrix.WriteValue('X');
                _target = _matrix.Address;
                break;
        }

        var directions = FindUnvisitedDirections();
        _computer.Stop();
        foreach (var direction in directions)
        {
            _queue.Enqueue((_matrix.Address, direction, _computer.Clone()));
        }
        
        return false;
    }

    private IEnumerable<MatrixDirection> FindUnvisitedDirections()
    {
        var directions = new List<MatrixDirection>();
        
        _matrix.MoveForward();
        if (_matrix.ReadValue() == ' ')
            directions.Add(_matrix.Direction);
        _matrix.MoveBackward();
        _matrix.TurnRight();

        _matrix.MoveForward();
        if (_matrix.ReadValue() == ' ')
            directions.Add(_matrix.Direction);
        _matrix.MoveBackward();
        _matrix.TurnRight();

        _matrix.MoveForward();
        if (_matrix.ReadValue() == ' ')
            directions.Add(_matrix.Direction);
        _matrix.MoveBackward();
        _matrix.TurnRight();

        _matrix.MoveForward();
        if (_matrix.ReadValue() == ' ')
            directions.Add(_matrix.Direction);
        _matrix.MoveBackward();
        _matrix.TurnRight();

        return directions;
    }

    private DroidDirection GetDroidDirection()
    {
        if (_matrix.Direction.Equals(MatrixDirection.Right))
            return DroidDirection.East;
        if (_matrix.Direction.Equals(MatrixDirection.Down))
            return DroidDirection.South;
        if (_matrix.Direction.Equals(MatrixDirection.Left))
            return DroidDirection.West;
        return DroidDirection.North;
    }
}