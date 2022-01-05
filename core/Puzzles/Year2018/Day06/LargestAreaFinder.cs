using System.Collections.Generic;
using System.Linq;
using Core.Common.CoordinateSystems;

namespace Core.Puzzles.Year2018.Day06;

public class LargestAreaFinder
{
    private Matrix<int> _matrix;

    private IList<MatrixAddress> _coords;
    private readonly IList<int> _ids;
    private readonly IList<int> _markers;

    public LargestAreaFinder(string input)
    {
        _coords = GetCoords(input);
        _ids = new List<int>();
        _markers = new List<int>();
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
        for (var y = 0; y < _matrix.Height; y++)
        {
            for (var x = 0; x < _matrix.Width; x++)
            {
                var address = new MatrixAddress(x, y);
                var sumOfdistances = _coords.Select(o => o.ManhattanDistanceTo(address)).Sum();
                if (sumOfdistances < distanceLimit)
                    centralAreaCount += 1;
            }
        }

        return centralAreaCount;
    }

    private IList<int> GetNonEdgeMasters(IList<int> edgeMarkers)
    {
        return _matrix.Values.Where(o => o != 0 && !edgeMarkers.Contains(o)).ToList();
    }

    private IList<int> FindEdgeMarkers()
    {
        _matrix.MoveTo(0, 0);
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

            if (_matrix.Address.X == 0 && _matrix.Address.Y == 0)
                done = true;
        }

        return markers;
    }

    private void FillMatrix(IList<MatrixAddress> coords)
    {
        for (var y = 0; y < _matrix.Height; y++)
        {
            for (var x = 0; x < _matrix.Width; x++)
            {
                _matrix.MoveTo(x, y);
                if(_matrix.ReadValue() != -1)
                    continue;

                var coordsOrderedByDistance = coords.OrderBy(o => _matrix.Address.ManhattanDistanceTo(o)).ToList();
                var coord1 = coordsOrderedByDistance[0];
                var coord2 = coordsOrderedByDistance[1];
                var distance1 = _matrix.Address.ManhattanDistanceTo(coord1);
                var distance2 = _matrix.Address.ManhattanDistanceTo(coord2);
                var c = distance1 == distance2
                    ? 0
                    : _matrix.ReadValueAt(coord1) + 1000;
                if(c != 0)
                    _markers.Add(c);
                _matrix.WriteValue(c);
            }
        }
    }

    private void BuildMatrix(IList<MatrixAddress> coords)
    {
        var width = coords.Max(o => o.X) + 1;
        var height = coords.Max(o => o.Y) + 1;

        _matrix = new Matrix<int>(width, height, -1);

        var c = 1;
        foreach (var coord in coords)
        {
            _matrix.MoveTo(coord);
            _matrix.WriteValue(c);
            _ids.Add(c);
            c += 1;
        }
    }

    private IList<MatrixAddress> GetCoords(string input)
    {
        var strCoords = input.Trim().Split('\n');
        var coords = new List<MatrixAddress>();
        foreach (var str in strCoords)
        {
            var list = str.Trim().Split(',').Select(int.Parse).ToArray();
            coords.Add(new MatrixAddress(list[0], list[1]));
        }

        return coords;
    }
}