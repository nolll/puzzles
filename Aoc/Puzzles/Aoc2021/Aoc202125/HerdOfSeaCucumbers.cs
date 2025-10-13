using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202125;

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

    private List<Coord> FindCucumbersToMoveEast()
    {
        var cucumbersToMoveEast = new List<Coord>();
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
                        cucumbersToMoveEast.Add(new Coord(x, y));
                }
            }
        }

        return cucumbersToMoveEast;
    }

    private void MoveCucumberEast(List<Coord> cucumbersToMove)
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

    private List<Coord> FindCucumbersToMoveSouth()
    {
        var cucumbersToMoveSouth = new List<Coord>();

        foreach (var coord in _matrix.Coords)
        {
            _matrix.MoveTo(coord);
            var current = _matrix.ReadValue();
            if (current == 'v')
            {
                var next = _matrix.TryMoveDown() ? _matrix.ReadValue() : _matrix.ReadValueAt(_matrix.Address.X, 0);
                if (next == '.')
                    cucumbersToMoveSouth.Add(coord);
            }
        }
        
        return cucumbersToMoveSouth;
    }

    private void MoveCucumberSouth(List<Coord> cucumbersToMove)
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