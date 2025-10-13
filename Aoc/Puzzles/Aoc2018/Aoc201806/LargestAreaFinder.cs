using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201806;

public class LargestAreaFinder
{
    private Matrix<int> _matrix = new();

    private readonly IList<Coord> _coords;
    private readonly IList<int> _ids;

    public LargestAreaFinder(string input)
    {
        _coords = GetCoords(input);
        _ids = new List<int>();
        BuildMatrix(_coords);
        FillMatrix(_coords);
    }

    public int GetSizeOfLargestArea()
    {
        var edgeMarkers = FindEdgeMarkers();
        var nonEdgeMarkers = GetNonEdgeMasters(edgeMarkers);
        var mostCommonMarker = nonEdgeMarkers.GroupBy(o => o).OrderByDescending(o => o.Count()).First().Key;
        return nonEdgeMarkers.Count(o => o == mostCommonMarker) + 1;
    }

    public int GetSizeOfCentralArea(int distanceLimit)
    {
        var centralAreaCount = 0;
        foreach (var coord in _matrix.Coords)
        {
            var sumOfdistances = _coords.Select(o => o.ManhattanDistanceTo(coord)).Sum();
            if (sumOfdistances < distanceLimit)
                centralAreaCount += 1;
        }

        return centralAreaCount;
    }

    private IList<int> GetNonEdgeMasters(IList<int> edgeMarkers)
    {
        return _matrix.Values.Where(o => o != 0 && !edgeMarkers.Contains(o)).ToList();
    }

    private IList<int> FindEdgeMarkers()
    {
        _matrix.MoveTo(_matrix.XMin, _matrix.YMin);
        _matrix.TurnTo(MatrixDirection.Right);
        var markers = new List<int>();
        var done = false;
        while (!done)
        {
            var val = _matrix.ReadValue();
            if(val != 0 && !markers.Contains(val) && !_ids.Contains(val))
                markers.Add(val);

            if (!_matrix.TryMoveForward())
            {
                _matrix.TurnRight();
                _matrix.MoveForward();
            }

            if (_matrix.Address.X == _matrix.XMin && _matrix.Address.Y == _matrix.YMin)
                done = true;
        }

        return markers;
    }

    private void FillMatrix(IList<Coord> coords)
    {
        foreach (var coord in _matrix.Coords)
        {
            _matrix.MoveTo(coord);
            if (_matrix.ReadValue() != -1)
                continue;

            var coordsOrderedByDistance = coords.OrderBy(o => _matrix.Address.ManhattanDistanceTo(o)).ToList();
            var coord1 = coordsOrderedByDistance[0];
            var coord2 = coordsOrderedByDistance[1];
            var distance1 = _matrix.Address.ManhattanDistanceTo(coord1);
            var distance2 = _matrix.Address.ManhattanDistanceTo(coord2);
            var c = distance1 == distance2
                ? 0
                : _matrix.ReadValueAt(coord1) + 1000;
            _matrix.WriteValue(c);
        }
    }

    private void BuildMatrix(IList<Coord> coords)
    {
        var width = coords.Max(o => o.X) + 1;
        var height = coords.Max(o => o.Y) + 1;

        _matrix = new Matrix<int>(width, height, -1);

        var c = 1;
        foreach (var coord in coords)
        {
            _matrix.WriteValueAt(coord, c);
            _ids.Add(c);
            c += 1;
        }
    }

    private static IList<Coord> GetCoords(string input)
    {
        var strCoords = input.Trim().Split('\n');
        var coords = new List<Coord>();
        foreach (var str in strCoords)
        {
            var list = str.Trim().Split(',').Select(int.Parse).ToArray();
            coords.Add(new Coord(list[0], list[1]));
        }

        return coords;
    }
}