using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2021;

[Name("Dumbo Octopus")]
public class Aoc202111 : AocPuzzle
{
    [Puzzle("4aec5027d57e852d3dc2c0fa275d9d7a")]
    public int Part1(string input) => new OctopusFlasher(input).Run(100);

    [Puzzle("ffd6657cda58c97fce2c4c27d8fd43a9")]
    public int Part2(string input) => new OctopusFlasher(input).Run();
    
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
}