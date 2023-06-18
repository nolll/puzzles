using System;
using System.Collections.Generic;
using System.Linq;
using Aoc.Common.CoordinateSystems.CoordinateSystem2D;

namespace Aoc.Puzzles.Year2019.Day20;

public class RecursiveDonutMazeSolver
{
    private static class Chars
    {
        public const char Path = '.';
        public const char Wall = '#';
        public const char Space = ' ';
    }

    private IList<Matrix<char>> _map;
    public int ShortestStepCount { get; }
    private MatrixAddress _startAddress;
    private MatrixAddress _endAddress;
    private Matrix<char> _matrix;
    private IDictionary<(int, int), DonutPortal> _portals;
    private IDictionary<(int, int), IList<MatrixAddress>> _outerAdjacentCache;
    private IDictionary<(int, int), IList<MatrixAddress>> _innerAdjacentCache;

    private Matrix<char> GetMatrix(int depth)
    {
        if (_map.Count <= depth)
            _map.Add(_matrix.Copy());
        return _map[depth];
    }

    public RecursiveDonutMazeSolver(string input)
    {
        ShortestStepCount = 0;
        Setup(input);
        ShortestStepCount = StepCountTo(_startAddress, _endAddress);
    }

    private void Setup(string input)
    {
        var matrix = MatrixBuilder.BuildCharMatrix(input.Replace(Chars.Space, Chars.Wall));
        var portalAddresses = new List<DonutPortalAddress>();
        var letterCoords = FindLetterCoords(matrix).ToList();
        while (letterCoords.Count > 0)
        {
            var currentCoords = letterCoords.First();
            letterCoords.RemoveAt(0);
            matrix.MoveTo(currentCoords);
            var secondLetterCoords = matrix.PerpendicularAdjacentCoords.First(o => IsLetter(matrix.ReadValueAt(o)));
            var firstLetter = matrix.ReadValueAt(currentCoords);
            var secondLetter = matrix.ReadValueAt(secondLetterCoords);
            letterCoords.Remove(secondLetterCoords);
            matrix.MoveTo(currentCoords);
            matrix.WriteValue(Chars.Wall);
            matrix.MoveTo(secondLetterCoords);
            matrix.WriteValue(Chars.Wall);
            var secondLetterHasAdjacentCorridor = matrix.PerpendicularAdjacentValues.Any(o => o == Chars.Path);
            matrix.MoveTo(currentCoords);
            var name = string.Concat(firstLetter, secondLetter);
            var letterAddress = secondLetterHasAdjacentCorridor ? secondLetterCoords : currentCoords;
            matrix.MoveTo(letterAddress);
            var portalAddress = matrix.PerpendicularAdjacentCoords.First(o => matrix.ReadValueAt(o) == Chars.Path);
            if (name == "AA")
            {
                _startAddress = portalAddress;
                continue;
            }
            if (name == "ZZ")
            {
                _endAddress = portalAddress;
                continue;
            }
            matrix.MoveTo(portalAddress);
            matrix.WriteValue(Chars.Path);
            var portal = new DonutPortalAddress(name, portalAddress);
            portalAddresses.Add(portal);
        }

        var portals = new Dictionary<(int, int), DonutPortal>();
        var orderedPortalAddresses = portalAddresses.OrderBy(o => o.Name).ToList();
        var topMatrix = matrix.Copy();

        while (orderedPortalAddresses.Any())
        {
            var a = orderedPortalAddresses.First();
            orderedPortalAddresses.RemoveAt(0);
            var b = orderedPortalAddresses.First();
            orderedPortalAddresses.RemoveAt(0);

            var aIsOuter = IsOuterPortal(matrix, a.Address);
            var outer = aIsOuter ? a : b;
            var inner = aIsOuter ? b : a;

            var innerPortal = new InnerDonutPortal(inner.Name, inner.Address, outer.Address);
            portals.Add(inner.Address.Tuple, innerPortal);
            var outerPortal = new OuterDonutPortal(outer.Name, outer.Address, inner.Address);
            portals.Add(outer.Address.Tuple, outerPortal);
            topMatrix.MoveTo(outer.Address);
            topMatrix.WriteValue(Chars.Wall);
        }

        _matrix = matrix;
        _portals = portals;
        _outerAdjacentCache = BuildAdjacentCache(topMatrix);
        _innerAdjacentCache = BuildAdjacentCache(matrix);
        _map = new List<Matrix<char>> { topMatrix };
    }

    private IDictionary<(int, int), IList<MatrixAddress>> BuildAdjacentCache(Matrix<char> matrix)
    {
        var dictionary = new Dictionary<(int, int), IList<MatrixAddress>>();
        foreach (var coord in matrix.Coords)
        {
            var coords = matrix
                .PerpendicularAdjacentCoordsTo(coord)
                .Where(o => matrix.ReadValueAt(o) == Chars.Path)
                .ToList();
            dictionary.Add(coord.Tuple, coords);
        }

        return dictionary;
    }

    private static bool IsOuterPortal(Matrix<char> matrix, MatrixAddress address)
    {
        const int distance = 2;
        var xIsOnEdge = matrix.XMin + distance == address.X || matrix.XMax - distance == address.X;
        var yIsOnEdge = matrix.YMin + distance == address.Y || matrix.YMax - distance == address.Y;
        return xIsOnEdge || yIsOnEdge;
    }

    private static IEnumerable<MatrixAddress> FindLetterCoords(Matrix<char> matrix)
    {
        return matrix.Coords.Where(o => IsLetter(matrix.ReadValueAt(o)));
    }

    private static bool IsLetter(char c)
    {
        return c != Chars.Wall && c != Chars.Path;
    }

    private int StepCountTo(MatrixAddress from, MatrixAddress to)
    {
        var coordCounts = GetCoordCountsNew(from, to);
        var goal = coordCounts.FirstOrDefault(o => o.Depth == 0 && o.Coord.X == from.X && o.Coord.Y == from.Y);
        return goal?.Count ?? 0;
    }

    private IList<MatrixAddress> GetAdjacentCoords(MatrixAddress coord, int depth)
    {
        return GetAdjacentCache(depth)[coord.Tuple];
    }

    private IDictionary<(int, int), IList<MatrixAddress>> GetAdjacentCache(int depth)
    {
        return depth == 0
            ? _outerAdjacentCache
            : _innerAdjacentCache;
    }

    private IList<CoordCount> GetCoordCountsNew(MatrixAddress from, MatrixAddress to)
    {
        var queue = new List<CoordCount> { new(0, to, 0) };
        var seen = new HashSet<(int, int, int)>();
        var index = 0;
        while (index < queue.Count && !seen.Contains((0, from.X, from.Y)))
        {
            var next = queue[index];
            var adjacentCoords = GetAdjacentCoords(next.Coord, next.Depth)
                .Where(o => !seen.Contains((next.Depth, o.X, o.Y)))
                .ToList();

            foreach (var adjacentCoord in adjacentCoords)
            {
                var newCoordCount = new CoordCount(next.Depth, adjacentCoord, next.Count + 1);
                queue.Add(newCoordCount);
                seen.Add((newCoordCount.Depth, newCoordCount.Coord.X, newCoordCount.Coord.Y));
            }

            if (_portals.TryGetValue((next.Coord.X, next.Coord.Y), out var portal))
            {
                var portalCoordCount = new CoordCount(next.Depth + portal.DepthChange, portal.Target, next.Count + 1);
                queue.Add(portalCoordCount);
                seen.Add((portalCoordCount.Depth, portalCoordCount.Coord.X, portalCoordCount.Coord.Y));
            }

            index++;
        }
        
        return queue;
    }

    private class CoordCount
    {
        public int Depth { get; }
        public MatrixAddress Coord { get; }
        public int Count { get; }

        public CoordCount(int depth, MatrixAddress coord, int count)
        {
            Depth = depth;
            Coord = coord;
            Count = count;
        }
    }
}