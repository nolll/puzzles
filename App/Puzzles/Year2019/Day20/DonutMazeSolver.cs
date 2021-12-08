using System.Collections.Generic;
using System.Linq;
using App.Common.CoordinateSystems;

namespace App.Puzzles.Year2019.Day20
{
    public class DonutMazeSolver
    {
        private Matrix<char> _map;
        public int ShortestStepCount { get; }

        public DonutMazeSolver(string input)
        {
            ShortestStepCount = 0;
            BuildMap(input);
            var portals = FindPortals();
            var portalConnections = FindPortalConnections(portals);
            var stepCounts = StepCountsTo(portalConnections, "AA", "ZZ").OrderBy(o => o.Distance).ToList();
            ShortestStepCount = stepCounts.First().Distance;
        }

        private IList<PortalPath> StepCountsTo(IDictionary<string, int> portalConnections, string startPortal, string targetPortal)
        {
            var completePaths = new List<PortalPath>();
            var queue = new List<PortalPath> {new PortalPath(0, startPortal, new List<string> {"AA"})};
            while (queue.Any())
            {
                var path = queue.First();
                queue.RemoveAt(0);

                var possibleConnections = portalConnections.Keys.Where(o => o.Contains(path.FromPortal));
                foreach (var connection in possibleConnections)
                {
                    var otherId = connection.Replace(path.FromPortal, "").Replace("-", "");
                    if (!path.PassedPortals.Contains(otherId))
                    {
                        if (otherId == targetPortal)
                        {
                            var distance = path.Distance + portalConnections[connection];
                            var newPath = new PortalPath(distance, otherId, path.PassedPortals.Concat(new List<string> { otherId }).ToList());
                            completePaths.Add(newPath);
                        }
                        else
                        {
                            var distance = path.Distance + portalConnections[connection] + 1;
                            var newPath = new PortalPath(distance, otherId, path.PassedPortals.Concat(new List<string> { otherId }).ToList());
                            queue.Add(newPath);
                        }

                    }
                }
            }

            return completePaths;
        }

        private class PortalPath
        {
            public int Distance { get; }
            public string FromPortal { get; }
            public IList<string> PassedPortals { get; }

            public PortalPath(int distance, string fromPortal, IList<string> passedPortals = null)
            {
                Distance = distance;
                FromPortal = fromPortal;
                PassedPortals = passedPortals ?? new List<string>();
            }
        }

        private IDictionary<string, int> FindPortalConnections(IList<DonutPortalAddress> portals)
        {
            var connections = new Dictionary<string, int>();

            foreach (var a in portals)
            {
                foreach (var b in portals)
                {
                    if (a.Name != b.Name)
                    {
                        var id = GetPortalDistanceId(a, b);
                        if (!connections.ContainsKey(id))
                        {
                            var distance = PathFinder.StepCountTo(_map, a.Address, b.Address);
                            if (distance > 0)
                            {
                                connections[id] = distance - 2;
                            }
                        }
                    }
                }
            }

            return connections;
        }

        private static string GetPortalDistanceId(DonutPortalAddress a, DonutPortalAddress b)
        {
            return GetPortalDistanceId(a.Name, b.Name);
        }

        public static string GetPortalDistanceId(string a, string b)
        {
            return string.Join('-', new[] { a, b }.OrderBy(o => o));
        }

        private IList<DonutPortalAddress> FindPortals()
        {
            var portals = new List<DonutPortalAddress>();
            var letterCoords = FindLetterCoords().ToList();
            while (letterCoords.Count > 0)
            {
                var currentCoords = letterCoords.First();
                letterCoords.RemoveAt(0);
                _map.MoveTo(currentCoords);
                var secondsLetterCoords = _map.PerpendicularAdjacentCoords.First(o => IsLetter(_map.ReadValueAt(o)));
                var firstLetter = _map.ReadValueAt(currentCoords);
                var secondLetter = _map.ReadValueAt(secondsLetterCoords);
                letterCoords.Remove(secondsLetterCoords);
                _map.MoveTo(currentCoords);
                _map.WriteValue('#');
                _map.MoveTo(secondsLetterCoords);
                _map.WriteValue('#');
                var secondLetterHasAdjacentCorridor = _map.PerpendicularAdjacentValues.Any(o => o == '.');
                _map.MoveTo(currentCoords);
                var name = string.Concat(firstLetter, secondLetter);
                var portalAddress = secondLetterHasAdjacentCorridor ? secondsLetterCoords : currentCoords;
                _map.MoveTo(portalAddress);
                _map.WriteValue('.');
                var portal = new DonutPortalAddress(name, portalAddress);
                portals.Add(portal);
            }
            return portals;
        }

        private IEnumerable<MatrixAddress> FindLetterCoords()
        {
            for (var y = 0; y < _map.Height; y++)
            {
                for (var x = 0; x < _map.Width; x++)
                {
                    _map.MoveTo(x, y);
                    var value = _map.ReadValue();
                    if(IsLetter(value))
                        yield return _map.Address;
                }
            }
        }

        private bool IsLetter(char c)
        {
            return c != '#' && c != '.';
        }

        private void BuildMap(string input)
        {
            _map = MatrixBuilder.BuildCharMatrix(input.Replace(' ', '#').Replace("_", ""));
        }
    }
}