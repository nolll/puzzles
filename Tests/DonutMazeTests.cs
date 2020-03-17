using System.Collections.Generic;
using System.Linq;
using Core.Tools;
using NUnit.Framework;

namespace Tests
{
    public class DonutMazeTests
    {
        [Test]
        public void FindsShortestRoute()
        {
            const string input = @"
_                      _
_          A           _
_          A           _
_   #######.#########  _
_   #######.........#  _
_   #######.#######.#  _
_   #######.#######.#  _
_   #######.#######.#  _
_   #####  B    ###.#  _
_ BC...##  C    ###.#  _
_   ##.##       ###.#  _
_   ##...DE  F  ###.#  _
_   #####    G  ###.#  _
_   #########.#####.#  _
_ DE..#######...###.#  _
_   #.#########.###.#  _
_ FG..#########.....#  _
_   ###########.#####  _
_              Z       _
_              Z       _
_                      _";

            var solver = new DonutMazeSolver(input);

            Assert.That(solver.ShortestStepCount, Is.EqualTo(23));
        }
    }

    public class DonutMazeSolver
    {
        private Matrix<char> _map;
        public int ShortestStepCount { get; }

        public DonutMazeSolver(string input)
        {
            ShortestStepCount = 0;
            BuildMap(input);
            var portals = FindPortals();
            var portalDistances = FindPortalDistances(portals);
            var portalPaths = FindPortalPathsFromAaToZz(portals, portalDistances);
        }

        private IList<IList<DonutPortal>> FindPortalPathsFromAaToZz(IList<DonutPortal> portals, IDictionary<string, int> portalDistances)
        {
            var distancesFromAa = portalDistances.Keys.Where(o => o.Contains("AA"));
            foreach (var distance in distancesFromAa)
            {
                foreach (var portal in portals)
                {
                    var id = 
                }
            }
        }

        private IDictionary<string, int> FindPortalDistances(IList<DonutPortal> portals)
        {
            var distances = new Dictionary<string, int>();

            foreach (var a in portals)
            {
                foreach (var b in portals)
                {
                    if (a.Name != b.Name)
                    {
                        var id = GetPortalDistanceId(a, b);
                        if (!distances.ContainsKey(id))
                        {
                            var distance = PathFinder.StepCountTo(_map, a.Address, b.Address);
                            if (distance > 0)
                            {
                                distances[id] = distance - 2;
                            }
                        }
                    }
                }
            }

            return distances;
        }

        private string GetPortalDistanceId(DonutPortal a, DonutPortal b)
        {
            return string.Join('-', new[] {a.Name, b.Name}.OrderBy(o => o));
        }

        private IList<DonutPortal> FindPortals()
        {
            var portals = new List<DonutPortal>();
            var letterCoords = FindLetterCoords().ToList();
            while (letterCoords.Count > 0)
            {
                var currentCoords = letterCoords.First();
                letterCoords.RemoveAt(0);
                _map.MoveTo(currentCoords);
                var secondsLetterCoords = _map.Adjacent4Coords.First(o => IsLetter(_map.ReadValueAt(o)));
                var firstLetter = _map.ReadValueAt(currentCoords);
                var secondLetter = _map.ReadValueAt(secondsLetterCoords);
                letterCoords.Remove(secondsLetterCoords);
                _map.MoveTo(currentCoords);
                _map.WriteValue('#');
                _map.MoveTo(secondsLetterCoords);
                _map.WriteValue('#');
                var secondLetterHasAdjacentCorridor = _map.Adjacent4.Any(o => o == '.');
                _map.MoveTo(currentCoords);
                var name = string.Concat(firstLetter, secondLetter);
                var portalAddress = secondLetterHasAdjacentCorridor ? secondsLetterCoords : currentCoords;
                _map.MoveTo(portalAddress);
                _map.WriteValue('.');
                var portal = new DonutPortal(name, portalAddress);
                portals.Add(portal);
            }
            return portals;
        }

        private IEnumerable<MatrixAddress> FindLetterCoords()
        {
            for (var y = 0; y < _map.Height; y++)
            {
                for (var x = 0; x < _map.Height; x++)
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

    public class DonutPortal
    {
        public string Name { get; }
        public MatrixAddress Address { get; }

        public DonutPortal(string name, MatrixAddress address)
        {
            Name = name;
            Address = address;
        }
    }
}