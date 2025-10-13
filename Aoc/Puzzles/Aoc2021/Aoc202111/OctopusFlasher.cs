using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202111;

public class OctopusFlasher
{
    private readonly Grid<int> _grid;
    private readonly IList<Coord> _coords;

    public OctopusFlasher(string input)
    {
        _grid = GridBuilder.BuildIntGridFromNonSeparated(input);
        _coords = _grid.Coords.ToList();
    }

    public int Run(int? maxSteps = null)
    {
        var flashCount = 0;

        var i = 0;
        while(true)
        {
            var flashed = new HashSet<Coord>();

            IncrementAll();
            var coordsToFlash = GetCoordsToFlash();

            while (coordsToFlash.Any())
            {
                var flashCoord = coordsToFlash.First();
                _grid.MoveTo(flashCoord);
                _grid.WriteValue(0);
                flashed.Add(flashCoord);

                foreach (var adjacentCoord in _grid.AllAdjacentCoords)
                {
                    if (flashed.Contains(adjacentCoord))
                        continue;

                    _grid.MoveTo(adjacentCoord);
                    var adjacentValue = _grid.ReadValue();
                    var newAdjacentValue = adjacentValue + 1;
                    _grid.WriteValue(newAdjacentValue);
                }

                coordsToFlash = GetCoordsToFlash();
            }
                
            flashCount += flashed.Count;

            if (i >= maxSteps - 1)
                return flashCount;

            i++;

            if (flashed.Count == _coords.Count)
                return i;
        }
    }

    private IList<Coord> GetCoordsToFlash()
    {
        return _coords.Where(o => _grid.ReadValueAt(o) > 9).ToList();
    }

    private void IncrementAll()
    {
        foreach (var coord in _coords)
        {
            _grid.MoveTo(coord);
            var v = _grid.ReadValue();
            var newValue = v + 1;
            _grid.WriteValue(newValue);
        }
    }
}