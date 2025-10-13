using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202125;

public class HerdOfSeaCucumbers
{
    private readonly Grid<char> _grid;

    public HerdOfSeaCucumbers(string input)
    {
        _grid = GridBuilder.BuildCharGrid(input);
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
        for (var y = 0; y < _grid.Height; y++)
        {
            for (var x = 0; x < _grid.Width; x++)
            {
                _grid.MoveTo(x, y);
                var current = _grid.ReadValue();
                if (current == '>')
                {
                    var next = _grid.TryMoveRight() ? _grid.ReadValue() : _grid.ReadValueAt(0, _grid.Address.Y);
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
            _grid.MoveTo(coord);
            _grid.WriteValue('.');
            if (_grid.TryMoveRight())
            {
                _grid.WriteValue('>');
            }
            else
            {
                _grid.MoveTo(0, _grid.Address.Y);
                _grid.WriteValue('>');
            }
        }
    }

    private List<Coord> FindCucumbersToMoveSouth()
    {
        var cucumbersToMoveSouth = new List<Coord>();

        foreach (var coord in _grid.Coords)
        {
            _grid.MoveTo(coord);
            var current = _grid.ReadValue();
            if (current == 'v')
            {
                var next = _grid.TryMoveDown() ? _grid.ReadValue() : _grid.ReadValueAt(_grid.Address.X, 0);
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
            _grid.MoveTo(coord);
            _grid.WriteValue('.');
            if (_grid.TryMoveDown())
            {
                _grid.WriteValue('v');
            }
            else
            {
                _grid.MoveTo(_grid.Address.X, 0);
                _grid.WriteValue('v');
            }
        }
    }
}