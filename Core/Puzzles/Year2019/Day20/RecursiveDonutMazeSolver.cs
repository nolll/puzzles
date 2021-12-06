using System.Collections.Generic;
using System.Linq;
using Core.Common.CoordinateSystems;

namespace Core.Puzzles.Year2019.Day20
{
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
        private IDictionary<MatrixAddress, DonutPortal> _portals;

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
            var matrix = MatrixBuilder.BuildCharMatrix(input.Replace(Chars.Space, Chars.Wall).Replace("_", ""));
            var portalAddresses = new List<DonutPortalAddress>();
            var letterCoords = FindLetterCoords(matrix).ToList();
            while (letterCoords.Count > 0)
            {
                var currentCoords = letterCoords.First();
                letterCoords.RemoveAt(0);
                matrix.MoveTo(currentCoords);
                var secondsLetterCoords = matrix.PerpendicularAdjacentCoords.First(o => IsLetter(matrix.ReadValueAt(o)));
                var firstLetter = matrix.ReadValueAt(currentCoords);
                var secondLetter = matrix.ReadValueAt(secondsLetterCoords);
                letterCoords.Remove(secondsLetterCoords);
                matrix.MoveTo(currentCoords);
                matrix.WriteValue(Chars.Wall);
                matrix.MoveTo(secondsLetterCoords);
                matrix.WriteValue(Chars.Wall);
                var secondLetterHasAdjacentCorridor = matrix.PerpendicularAdjacentValues.Any(o => o == Chars.Path);
                matrix.MoveTo(currentCoords);
                var name = string.Concat(firstLetter, secondLetter);
                var letterAddress = secondLetterHasAdjacentCorridor ? secondsLetterCoords : currentCoords;
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

            var center = matrix.Center;
            var portals = new Dictionary<MatrixAddress, DonutPortal>();
            var orderedPortalAddresses = portalAddresses.OrderBy(o => o.Name).ToList();
            var topMatrix = matrix.Copy();
            while (orderedPortalAddresses.Any())
            {
                var a = orderedPortalAddresses.First();
                orderedPortalAddresses.RemoveAt(0);
                var b = orderedPortalAddresses.First();
                orderedPortalAddresses.RemoveAt(0);

                var aIsOuter = IsOuterPortal(matrix.Width, matrix.Height, a.Address);
                var outer = aIsOuter ? a : b;
                var inner = aIsOuter ? b : a;

                var innerPortal = new InnerDonutPortal(inner.Name, inner.Address, outer.Address);
                portals.Add(inner.Address, innerPortal);
                var outerPortal = new OuterDonutPortal(outer.Name, outer.Address, inner.Address);
                portals.Add(outer.Address, outerPortal);
                topMatrix.MoveTo(outer.Address);
                topMatrix.WriteValue(Chars.Wall);
            }

            _matrix = matrix;
            _portals = portals;
            _map = new List<Matrix<char>> { topMatrix };
        }

        private bool IsOuterPortal(int width, int height, MatrixAddress address)
        {
            const int distance = 3;
            var xIsOnEdge = address.X == distance || width - address.X - 1 == distance;
            var yIsOnEdge = address.Y == distance || height - address.Y - 1 == distance;
            return xIsOnEdge || yIsOnEdge;
        }

        private IEnumerable<MatrixAddress> FindLetterCoords(Matrix<char> matrix)
        {
            for (var y = 0; y < matrix.Height; y++)
            {
                for (var x = 0; x < matrix.Width; x++)
                {
                    matrix.MoveTo(x, y);
                    var value = matrix.ReadValue();
                    if (IsLetter(value))
                        yield return matrix.Address;
                }
            }
        }

        private static bool IsLetter(char c)
        {
            return c != Chars.Wall && c != Chars.Path;
        }

        private int StepCountTo(MatrixAddress from, MatrixAddress to)
        {
            var coordCounts = GetCoordCounts(from, to);
            var goal = coordCounts.FirstOrDefault(o => o.Depth == 0 && o.X == from.X && o.Y == from.Y);
            return goal?.Count ?? 0;
        }

        private IList<CoordCount> GetCoordCounts(MatrixAddress from, MatrixAddress to)
        {
            var queue = new List<CoordCount> { new CoordCount(0, to.X, to.Y, 0) };
            var index = 0;
            while (index < queue.Count && !queue.Any(o => o.Depth == 0 && o.X == from.X && o.Y == from.Y))
            {
                var next = queue[index];
                var depth = next.Depth;
                var matrix = GetMatrix(next.Depth);
                matrix.MoveTo(next.X, next.Y);
                var localDepth = depth;
                var adjacentCoords = matrix.PerpendicularAdjacentCoords
                    .Where(o => matrix.ReadValueAt(o) == Chars.Path && !queue.Any(q => q.Depth == localDepth && q.X == o.X && q.Y == o.Y))
                    .ToList();
                var newCoordCounts = adjacentCoords.Select(o => new CoordCount(depth, o.X, o.Y, next.Count + 1)).ToList();
                if (_portals.TryGetValue(matrix.Address, out var portal))
                {
                    depth = next.Depth + portal.DepthChange;
                    var portalCoordCount = new CoordCount(next.Depth + portal.DepthChange, portal.Target.X, portal.Target.Y, next.Count + 1);
                    newCoordCounts.Add(portalCoordCount);
                }
                
                queue.AddRange(newCoordCounts);
                index++;
            }

            return queue;
        }

        private class CoordCount
        {
            public int Depth { get; }
            public int X { get; }
            public int Y { get; }
            public int Count { get; }

            public CoordCount(int depth, int x, int y, int count)
            {
                Depth = depth;
                X = x;
                Y = y;
                Count = count;
            }
        }
    }
}