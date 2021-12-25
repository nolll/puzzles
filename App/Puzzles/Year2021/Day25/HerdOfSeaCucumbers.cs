using System.Collections.Generic;
using System.Linq;
using App.Common.CoordinateSystems;

namespace App.Puzzles.Year2021.Day25;

public class HerdOfSeaCucumbers
{
    private readonly Matrix<char> _matrix;

    public HerdOfSeaCucumbers(string input)
    {
        _matrix = MatrixBuilder.BuildCharMatrix(input);
    }

    public int MoveUntilStop()
    {
        var steps = 0;
        var moved = true;
        while (moved)
        {
            moved = Move();
            steps++;
        }

        return steps;
    }

    private bool Move()
    {
        var cucumbersToMoveEast = FindCucumbersToMoveEast();
        MoveCucumberEast(cucumbersToMoveEast);

        var cucumbersToMoveSouth = FindCucumbersToMoveSouth();
        MoveCucumberSouth(cucumbersToMoveSouth);

        return cucumbersToMoveEast.Any() || cucumbersToMoveSouth.Any();
    }

    private List<MatrixAddress> FindCucumbersToMoveEast()
    {
        var cucumbersToMoveEast = new List<MatrixAddress>();
        for (var y = 0; y < _matrix.Height; y++)
        {
            for (var x = 0; x < _matrix.Width; x++)
            {
                _matrix.MoveTo(x, y);
                var current = _matrix.ReadValue();
                if (current == '>')
                {
                    var next = _matrix.TryMoveRight() ? _matrix.ReadValue() : _matrix.ReadValueAt(0, _matrix.Address.Y);
                    if (next == '.')
                        cucumbersToMoveEast.Add(new MatrixAddress(x, y));
                }
            }
        }

        return cucumbersToMoveEast;
    }

    private void MoveCucumberEast(List<MatrixAddress> cucumbersToMove)
    {
        foreach (var coord in cucumbersToMove)
        {
            _matrix.MoveTo(coord);
            _matrix.WriteValue('.');
            if (_matrix.TryMoveRight())
            {
                _matrix.WriteValue('>');
            }
            else
            {
                _matrix.MoveTo(0, _matrix.Address.Y);
                _matrix.WriteValue('>');
            }
        }
    }

    private List<MatrixAddress> FindCucumbersToMoveSouth()
    {
        var cucumbersToMoveSouth = new List<MatrixAddress>();
        for (var y = 0; y < _matrix.Height; y++)
        {
            for (var x = 0; x < _matrix.Width; x++)
            {
                _matrix.MoveTo(x, y);
                var current = _matrix.ReadValue();
                if (current == 'v')
                {
                    var next = _matrix.TryMoveDown() ? _matrix.ReadValue() : _matrix.ReadValueAt(_matrix.Address.X, 0);
                    if (next == '.')
                        cucumbersToMoveSouth.Add(new MatrixAddress(x, y));
                }
            }
        }

        return cucumbersToMoveSouth;
    }

    private void MoveCucumberSouth(List<MatrixAddress> cucumbersToMove)
    {
        foreach (var coord in cucumbersToMove)
        {
            _matrix.MoveTo(coord);
            _matrix.WriteValue('.');
            if (_matrix.TryMoveDown())
            {
                _matrix.WriteValue('v');
            }
            else
            {
                _matrix.MoveTo(_matrix.Address.X, 0);
                _matrix.WriteValue('v');
            }
        }
    }
}