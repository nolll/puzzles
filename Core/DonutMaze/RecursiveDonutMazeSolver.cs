using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.Tools;

namespace Core.DonutMaze
{
    public class RecursiveDonutMazeSolver
    {
        private IList<Matrix<char>> _map;
        public int ShortestStepCount { get; }
        private MatrixAddress _startAddress;
        private MatrixAddress _endAddress;
        private Matrix<char> _matrix;
        private IDictionary<MatrixAddress, DonutPortal> _portals;

        private Matrix<char> GetMatrix(int depth)
        {
            if (_map.Count < depth + 1)
                _map.Add(_matrix.Copy());
            return _map[0];
        }

        public RecursiveDonutMazeSolver(string input)
        {
            ShortestStepCount = 0;
            _map = new List<Matrix<char>>();
            _matrix = MatrixBuilder.BuildCharMatrix(input.Replace(' ', '#').Replace("_", ""));
            _portals = FindPortalAddresses(_matrix);

            //var portalConnections = FindPortalConnections(portals);
            //var stepCounts = StepCountsTo(portalConnections, "AA", "ZZ").OrderBy(o => o.Distance).ToList();
            ShortestStepCount = StepCountTo(_startAddress, _endAddress);
        }

        private IDictionary<MatrixAddress, DonutPortal> FindPortalAddresses(Matrix<char> matrix)
        {
            var portalAddresses = new List<DonutPortalAddress>();
            var letterCoords = FindLetterCoords(matrix).ToList();
            while (letterCoords.Count > 0)
            {
                var currentCoords = letterCoords.First();
                letterCoords.RemoveAt(0);
                matrix.MoveTo(currentCoords);
                var secondsLetterCoords = matrix.Adjacent4Coords.First(o => IsLetter(matrix.ReadValueAt(o)));
                var firstLetter = matrix.ReadValueAt(currentCoords);
                var secondLetter = matrix.ReadValueAt(secondsLetterCoords);
                letterCoords.Remove(secondsLetterCoords);
                matrix.MoveTo(currentCoords);
                matrix.WriteValue('#');
                matrix.MoveTo(secondsLetterCoords);
                matrix.WriteValue('#');
                var secondLetterHasAdjacentCorridor = matrix.Adjacent4.Any(o => o == '.');
                matrix.MoveTo(currentCoords);
                var name = string.Concat(firstLetter, secondLetter);
                var letterAddress = secondLetterHasAdjacentCorridor ? secondsLetterCoords : currentCoords;
                matrix.MoveTo(letterAddress);
                var portalAddress = matrix.Adjacent4Coords.First(o => matrix.ReadValueAt(o) == '.');
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
                matrix.WriteValue('.');
                var portal = new DonutPortalAddress(name, portalAddress);
                portalAddresses.Add(portal);
            }

            var center = matrix.Center;
            var portals = new Dictionary<MatrixAddress, DonutPortal>();
            var orderedPortalAddresses = portalAddresses.OrderBy(o => o.Name).ThenBy(o => o.Address.ManhattanDistanceTo(center)).ToList();
            while (orderedPortalAddresses.Any())
            {
                var inner = orderedPortalAddresses.First();
                orderedPortalAddresses.RemoveAt(0);
                var outer = orderedPortalAddresses.First();
                orderedPortalAddresses.RemoveAt(0);
                var innerPortal = new DonutPortal(inner.Name, outer.Address, 1);
                portals.Add(inner.Address, innerPortal);
                var outerPortal = new DonutPortal(outer.Name, inner.Address, -1);
                portals.Add(outer.Address, outerPortal);
            }

            return portals;
        }

        private IEnumerable<MatrixAddress> FindLetterCoords(Matrix<char> matrix)
        {
            for (var y = 0; y < matrix.Height; y++)
            {
                for (var x = 0; x < matrix.Width; x++)
                {
                    matrix.MoveTo(x, y);
                    var value = matrix.ReadValue();
                    if(IsLetter(value))
                        yield return matrix.Address;
                }
            }
        }

        private static bool IsLetter(char c)
        {
            return c != '#' && c != '.';
        }

        private int StepCountTo(MatrixAddress from, MatrixAddress to)
        {
            var coordCounts = GetCoordCounts(from, to);
            var goal = coordCounts.FirstOrDefault(o => o.X == from.X && o.Y == from.Y);
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
                if (_portals.TryGetValue(matrix.Address, out var portal))
                {
                    depth = next.Depth + portal.DepthChange;
                    matrix = GetMatrix(depth);
                    matrix.MoveTo(portal.Target);
                }
                var adjacentCoords = matrix.Adjacent4Coords
                    .Where(o => matrix.ReadValueAt(o) == '.' && !queue.Any(q => q.X == o.X && q.Y == o.Y))
                    .ToList();
                var newCoordCounts = adjacentCoords.Select(o => new CoordCount(depth, o.X, o.Y, next.Count + 1));
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