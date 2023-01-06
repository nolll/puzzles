using System;
using System.Collections.Generic;
using System.Linq;
using Core.Common.Computers.IntCode;
using Core.Common.CoordinateSystems.CoordinateSystem2D;

namespace Core.Puzzles.Year2019.Day15;

public class RepairDroid
{
    private readonly ComputerInterface _computer;
    private readonly IMatrix<char> _matrix;
    private int _steps;
    private DroidDirection NextDirection => GetDroidDirection();
    private readonly Random _random;

    public RepairDroid(string program)
    {
        _computer = new ComputerInterface(program, ReadInput, WriteOutput);
        _matrix = new Matrix<char>();
        _random = new Random();
    }

    public int Run()
    {
        _steps = 0;
        _computer.Start();
        return _steps;
    }

    private long ReadInput()
    {
        return (int)NextDirection;
    }

    private void WriteOutput(long output)
    {
        switch (output)
        {
            case 0:
                _matrix.MoveForward();
                _matrix.WriteValue('#');
                _matrix.MoveBackward();
                TurnToUnvisitedDirection();
                break;
            case 1:
                _matrix.MoveForward();
                _matrix.WriteValue('.');
                TurnToUnvisitedDirection();
                break;
            case 2:
                _matrix.MoveForward();
                _matrix.WriteValue('X');
                break;
        }
    }

    private void TurnToUnvisitedDirection()
    {
        var directions = FindUnvisitedDirections();
        if (!directions.Any())
        {
            directions = new List<MatrixDirection>
            {
                MatrixDirection.Up,
                MatrixDirection.Right,
                MatrixDirection.Down,
                MatrixDirection.Left
            };
        }
        var rnd = _random.Next(directions.Count);
        _matrix.TurnTo(directions[rnd]);
    }

    private IList<MatrixDirection> FindUnvisitedDirections()
    {
        var directions = new List<MatrixDirection>();

        _matrix.MoveForward();
        if (_matrix.ReadValue() == '\0')
            directions.Add(_matrix.Direction);
        _matrix.MoveBackward();
        _matrix.TurnRight();

        _matrix.MoveForward();
        if (_matrix.ReadValue() == '\0')
            directions.Add(_matrix.Direction);
        _matrix.MoveBackward();
        _matrix.TurnRight();

        _matrix.MoveForward();
        if (_matrix.ReadValue() == '\0')
            directions.Add(_matrix.Direction);
        _matrix.MoveBackward();
        _matrix.TurnRight();

        _matrix.MoveForward();
        if (_matrix.ReadValue() == '\0')
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