using System.Collections.Generic;
using System.Linq;
using App.Common.CoordinateSystems;
using NUnit.Framework;

namespace App.Puzzles.Year2021.Day25;

public class Year2021Day25Tests
{
    [Test]
    public void Part1()
    {
        var herd = new HerdOfSeaCucumbers(Input);
        var result = herd.MoveUntilStop();

        Assert.That(result, Is.EqualTo(58));
    }

    [Test]
    public void Part2()
    {
        var result = 0;

        Assert.That(result, Is.EqualTo(0));
    }

    private const string Input = @"
v...>>.vv>
.vv>>.vv..
>>.>v>...v
>>v>>.>.v.
v>v.vv.v..
>.>>..v...
.vv..>.>v.
v.v..>>v.v
....v..v.>";
}

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
                    _matrix.MoveTo(x, y);
                    if(next == '.')
                        cucumbersToMoveEast.Add(_matrix.Address);
                }
            }
        }

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
                    _matrix.MoveTo(x, y);
                    if (next == '.')
                        cucumbersToMoveSouth.Add(_matrix.Address);
                }
            }
        }

        foreach (var coord in cucumbersToMoveEast)
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

        foreach (var coord in cucumbersToMoveEast)
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
            }
        }

        return cucumbersToMoveEast.Any() || cucumbersToMoveSouth.Any();
    }
}