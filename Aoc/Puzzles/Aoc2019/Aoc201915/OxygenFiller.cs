using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201915;

public class OxygenFiller
{
    private readonly Grid<char> _grid;

    public OxygenFiller(Grid<char> grid)
    {
        grid.MoveTo(grid.StartAddress);
        grid.TurnTo(GridDirection.Up);
        _grid = grid;
    }

    public OxygenFiller(string map)
        : this(GridBuilder.BuildCharGrid(map.Replace(' ', '#'), ' '))
    {
    }

    public int Fill()
    {
        var iterations = 0;
        var recentlyFilledAddresses = _grid.FindAddresses('X');
        while (_grid.Values.Any(o => o == '.'))
        {
            var addressesToFill = new List<Coord>();
            foreach (var a in recentlyFilledAddresses)
            {
                var validAddresses = _grid.OrthogonalAdjacentCoordsTo(a).Where(o => _grid.ReadValueAt(o) == '.');
                addressesToFill.AddRange(validAddresses);
            }

            recentlyFilledAddresses.Clear();
            foreach (var atf in addressesToFill)
            {
                _grid.WriteValueAt(atf, 'O');
                recentlyFilledAddresses.Add(atf);
            }

            iterations += 1;
        }

        return iterations;
    }
}