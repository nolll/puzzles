using System.Collections.Generic;
using System.Linq;
using Core.Tools;

namespace Core.AirDuct
{
    public class AirDuctNavigator
    {
        private IList<AirDuctLocation> _locations;
        private Matrix<char> _matrix;
        private readonly IDictionary<(char, char), AirDuctPath> _paths;
        private readonly IDictionary<string, int> _cache;
        private AirDuctRobot _robot;

        public int ShortestPath { get; private set; }
        public int ShortestPathBackToStart { get; private set; }

        public AirDuctNavigator(string input)
        {
            _paths = new Dictionary<(char, char), AirDuctPath>();
            _cache = new Dictionary<string, int>();
            Init(input);
            MapPaths();
        }

        public void Run()
        {
            FindShortestPath();
        }

        private void FindShortestPath()
        {
            var allPaths = GetAllPaths(_robot.Address);
            var startPaths = GetStartPaths(allPaths);
            var stepCounts = new List<int>();
            
            foreach (var path in startPaths)
            {
                var stepCount = FollowPath(path, new List<AirDuctLocation>());
                stepCounts.Add(stepCount);
            }

            var totalStepCount = stepCounts.Any() ? stepCounts.Min() : 0;

            ShortestPath = totalStepCount;
            //var stepsBackToStart = 
            ShortestPathBackToStart = 0;
        }

        private int FindShortestPathFrom(AirDuctLocation currentLocation, IList<AirDuctLocation> collectedKeys)
        {
            var stepCounts = new List<int>();
            var pathsToFollow = new List<AirDuctPath>();
            var remainingKeys = GetRemainingLocations(collectedKeys);
            foreach (var key in remainingKeys)
            {
                if (key.Id != currentLocation.Id)
                {
                    var path = _paths[(currentLocation.Id, key.Id)];
                    pathsToFollow.Add(path);
                }
            }

            pathsToFollow = pathsToFollow.OrderBy(o => o.StepCount).Take(1).ToList();
            
            foreach (var path in pathsToFollow)
            {
                var stepCount = FollowPath(path, collectedKeys);
                stepCounts.Add(stepCount);
            }

            return stepCounts.Any() ? stepCounts.Min() : 0;
        }

        private IEnumerable<AirDuctLocation> GetRemainingLocations(IList<AirDuctLocation> visitedLocations)
        {
            return _locations.Where(location => visitedLocations.All(o => o.Id != location.Id));
        }

        private int FollowPath(AirDuctPath path, IList<AirDuctLocation> visitedLocations)
        {
            var stepCount = path.StepCount;
            var newVisitedLocations = new List<AirDuctLocation> {path.Target};
            newVisitedLocations.AddRange(visitedLocations);
            if(newVisitedLocations.Count < _locations.Count)
            {
                var cacheKey = GetCacheKey(path.Target.Id, visitedLocations);
                if (!_cache.TryGetValue(cacheKey, out var cachedStepCount))
                {
                    cachedStepCount = FindShortestPathFrom(path.Target, newVisitedLocations);
                    _cache.Add(cacheKey, cachedStepCount);
                }

                stepCount += cachedStepCount;
            }
            return stepCount;
        }

        private string GetCacheKey(char key, IList<AirDuctLocation> visitedLocations)
        {
            var joinedKeys = string.Join('-', visitedLocations.OrderBy(o => o.Id).Select(o => o.Id));
            return $"{key}.{joinedKeys}";
        }

        private void Init(string input)
        {
            _locations = new List<AirDuctLocation>();
            _matrix = new Matrix<char>();
            var rows = PuzzleInputReader.Read(input);
            var y = 0;
            foreach (var row in rows)
            {
                var x = 0;
                var chars = row.Trim().ToCharArray();
                foreach (var c in chars)
                {
                    var address = new MatrixAddress(x, y);
                    _matrix.MoveTo(address);
                    var charToWrite = c;

                    if (char.IsNumber(c))
                    {
                        charToWrite = '.';
                        if(c == '0')
                            _robot = new AirDuctRobot(address);
                        else
                            _locations.Add(new AirDuctLocation(c, address));
                    }

                    _matrix.WriteValue(charToWrite);

                    x += 1;
                }

                y += 1;
            }
        }

        private IList<AirDuctPath> GetStartPaths(IList<AirDuctPath> allPaths)
        {
            var paths = new List<AirDuctPath>();

            foreach (var path in allPaths)
            {
                paths.Add(path);
            }

            return paths;
        }

        private IList<AirDuctPath> GetAllPaths(MatrixAddress startAddress)
        {
            var paths = new List<AirDuctPath>();

            foreach (var key in _locations)
            {
                var coords = PathFinder.ShortestPathTo(_matrix, startAddress, key.Address);
                if(coords.Count > 0)
                    paths.Add(new AirDuctPath(key, coords));
            }

            return paths;
        }

        private void MapPaths()
        {
            foreach (var key in _locations)
            {
                var otherKeys = _locations.Where(o => o.Id != key.Id);
                foreach (var otherKey in otherKeys)
                {
                    var coords = PathFinder.ShortestPathTo(_matrix, key.Address, otherKey.Address);
                    var path = new AirDuctPath(otherKey, coords);
                    _paths.Add((key.Id, otherKey.Id), path);
                }
            }
        }
    }
}