using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202111;

public class OctopusFlasher
{
    private readonly Matrix<int> _matrix;
    private readonly IList<Coord> _coords;

    public OctopusFlasher(string input)
    {
        _matrix = MatrixBuilder.BuildIntMatrixFromNonSeparated(input);
        _coords = _matrix.Coords.ToList();
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
                _matrix.MoveTo(flashCoord);
                _matrix.WriteValue(0);
                flashed.Add(flashCoord);

                foreach (var adjacentCoord in _matrix.AllAdjacentCoords)
                {
                    if (flashed.Contains(adjacentCoord))
                        continue;

                    _matrix.MoveTo(adjacentCoord);
                    var adjacentValue = _matrix.ReadValue();
                    var newAdjacentValue = adjacentValue + 1;
                    _matrix.WriteValue(newAdjacentValue);
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
        return _coords.Where(o => _matrix.ReadValueAt(o) > 9).ToList();
    }

    private void IncrementAll()
    {
        foreach (var coord in _coords)
        {
            _matrix.MoveTo(coord);
            var v = _matrix.ReadValue();
            var newValue = v + 1;
            _matrix.WriteValue(newValue);
        }
    }
}