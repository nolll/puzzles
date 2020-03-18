using System.Collections.Generic;
using System.Linq;
using Core.Tools;

namespace Core.DonutMaze
{
    public class RecursiveDonutMazeSolver
    {
        private IList<Matrix<char>> _map;
        public int ShortestStepCount { get; }

        public RecursiveDonutMazeSolver(string input)
        {
            ShortestStepCount = 0;
            BuildMap(input);
            
            //var portalConnections = FindPortalConnections(portals);
            //var stepCounts = StepCountsTo(portalConnections, "AA", "ZZ").OrderBy(o => o.Distance).ToList();
            //ShortestStepCount = stepCounts.First().Distance;
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

        private IList<DonutPortal> FindPortals(Matrix<char> matrix)
        {
            var portals = new List<DonutPortal>();
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
                matrix.MoveTo(portalAddress);
                matrix.WriteValue('P');
                var portal = new DonutPortal(name, portalAddress);
                portals.Add(portal);
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

        private void BuildMap(string input)
        {
            _map = new List<Matrix<char>>();
            var topMatrix = MatrixBuilder.BuildCharMatrix(input.Replace(' ', '#').Replace("_", ""));
            var portals = FindPortals(topMatrix);
            var subMatrix = topMatrix.Copy();
            _map.Add(topMatrix);
            _map.Add(subMatrix);
        }
    }
}