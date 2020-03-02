using System.Collections.Generic;
using System.Linq;
using Core.Tools;

namespace Core.UndergroundVault
{
    public class KeyCollector
    {
        private IList<VaultKey> _keys;
        private IList<VaultDoor> _doors;
        private Matrix<char> _matrix;
        private readonly IDictionary<(char, char), VaultPath> _paths;
        private readonly IDictionary<string, int> _cache;
        private readonly IList<VaultRobot> _robots;

        public int ShortestPath { get; private set; }

        public KeyCollector(string input)
        {
            _paths = new Dictionary<(char, char), VaultPath>();
            _cache = new Dictionary<string, int>();
            _robots = new List<VaultRobot>();
            Init(input);
            MapPaths();
        }

        public void Run()
        {
            ShortestPath = FindShortestPath();
        }

        private int FindShortestPath()
        {
            var totalStepCount = 0;

            foreach (var robot in _robots)
            {
                var allPaths = GetAllPaths(robot.Address);
                var startPaths = GetStartPaths(robot.Address);
                var stepCounts = new List<int>();
                var reachableKeys = allPaths.Select(o => o.Target).ToList();
                var keysFoundByOtherRobots = GetKeysFoundByOtherRobots(reachableKeys);

                foreach (var path in startPaths)
                {
                    var stepCount = FollowPath(path, keysFoundByOtherRobots);
                    stepCounts.Add(stepCount);
                }

                totalStepCount += stepCounts.Any() ? stepCounts.Min() : 0;
            }

            return totalStepCount;
        }

        private IList<VaultKey> GetKeysFoundByOtherRobots(IList<VaultKey> reachableKeys)
        {
            var foundByOthers = new List<VaultKey>();
            foreach (var key in _keys)
            {
                if (reachableKeys.All(o => o.Id != key.Id))
                    foundByOthers.Add(key);
            }
            return foundByOthers;
        }

        private int FindShortestPathFrom(VaultKey currentKey, IList<VaultKey> collectedKeys)
        {
            var stepCounts = new List<int>();
            var pathsToFollow = new List<VaultPath>();
            var remainingKeys = GetRemainingKeys(collectedKeys);
            var isAllPathsOpen = true;
            foreach (var key in remainingKeys)
            {
                if (key.Id != currentKey.Id)
                {
                    var path = _paths[(currentKey.Id, key.Id)];
                    if (path.IsOpen(collectedKeys))
                    {
                        pathsToFollow.Add(path);
                    }
                    else
                    {
                        isAllPathsOpen = false;
                    }
                }
            }

            if (isAllPathsOpen)
            {
                pathsToFollow = pathsToFollow.OrderBy(o => o.StepCount).Take(1).ToList();
            }
            
            foreach (var path in pathsToFollow)
            {
                var stepCount = FollowPath(path, collectedKeys);
                stepCounts.Add(stepCount);
            }

            return stepCounts.Any() ? stepCounts.Min() : 0;
        }

        private IEnumerable<VaultKey> GetRemainingKeys(IList<VaultKey> collectedKeys)
        {
            return _keys.Where(key => collectedKeys.All(o => o.Id != key.Id));
        }

        private int FollowPath(VaultPath path, IList<VaultKey> collectedKeys)
        {
            var stepCount = path.StepCount;
            var newCollectedKeys = new List<VaultKey>{path.Target};
            newCollectedKeys.AddRange(collectedKeys);
            if(newCollectedKeys.Count < _keys.Count)
            {
                var cacheKey = GetCacheKey(path.Target.Id, collectedKeys);
                if (!_cache.TryGetValue(cacheKey, out var cachedStepCount))
                {
                    cachedStepCount = FindShortestPathFrom(path.Target, newCollectedKeys);
                    _cache.Add(cacheKey, cachedStepCount);
                }

                stepCount += cachedStepCount;
            }
            return stepCount;
        }

        private string GetCacheKey(char key, IList<VaultKey> collectedKeys)
        {
            var joinedKeys = string.Join('-', collectedKeys.OrderBy(o => o.Id).Select(o => o.Id));
            return $"{key}.{joinedKeys}";
        }

        private void Init(string input)
        {
            _keys = new List<VaultKey>();
            _doors = new List<VaultDoor>();
            _matrix = new Matrix<char>();
            var rows = input.Trim().Split('\n');
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

                    if (char.IsLower(c))
                    {
                        charToWrite = '.';
                        _keys.Add(new VaultKey(c, address));
                    }
                    else if (char.IsUpper(c))
                    {
                        charToWrite = '.';
                        _doors.Add(new VaultDoor(c, address));
                    }
                    else if (c == '@')
                    {
                        var robot = new VaultRobot(address);
                        _robots.Add(robot);
                        charToWrite = '.';
                    }

                    _matrix.WriteValue(charToWrite);

                    x += 1;
                }

                y += 1;
            }
        }

        private IList<VaultPath> GetStartPaths(MatrixAddress startAddress)
        {
            var paths = new List<VaultPath>();

            foreach (var key in _keys)
            {
                var coords = PathFinder.ShortestPathTo(_matrix, startAddress, key.Address);
                var blockingDoors = FindBlockingDoors(coords);
                if (!blockingDoors.Any())
                    paths.Add(new VaultPath(key, coords, new List<char>()));
            }

            return paths;
        }

        private IList<VaultPath> GetAllPaths(MatrixAddress startAddress)
        {
            var paths = new List<VaultPath>();

            foreach (var key in _keys)
            {
                var coords = PathFinder.ShortestPathTo(_matrix, startAddress, key.Address);
                if(coords.Count > 0)
                    paths.Add(new VaultPath(key, coords, new List<char>()));
            }

            return paths;
        }

        private void MapPaths()
        {
            foreach (var key in _keys)
            {
                var otherKeys = _keys.Where(o => o.Id != key.Id);
                foreach (var otherKey in otherKeys)
                {
                    var coords = PathFinder.ShortestPathTo(_matrix, key.Address, otherKey.Address);
                    var blockingDoors = FindBlockingDoors(coords);
                    var keysNeeded = blockingDoors.Select(o => char.ToLower(o.Id)).ToList();
                    var path = new VaultPath(otherKey, coords, keysNeeded);
                    _paths.Add((key.Id, otherKey.Id), path);
                }
            }
        }

        private IEnumerable<VaultDoor> FindBlockingDoors(IEnumerable<MatrixAddress> coords)
        {
            foreach (var coord in coords)
            {
                foreach (var door in _doors)
                {
                    if (door.Address.Equals(coord))
                    {
                        yield return door;
                    }
                }
            }
        }
    }

    public class VaultPath
    {
        private readonly IList<char> _keysNeeded;
        
        public int StepCount { get; }
        public VaultKey Target { get; }

        public VaultPath(VaultKey target, IList<MatrixAddress> coords, IList<char> keysNeeded)
        {
            Target = target;
            StepCount = coords.Count;
            _keysNeeded = keysNeeded;
        }

        public bool IsOpen(IList<VaultKey> collectedKeys)
        {
            return _keysNeeded.All(key => collectedKeys.Any(o => o.Id == key));
        }
    }

    public class VaultRobot
    {
        public MatrixAddress Address { get; }

        public VaultRobot(MatrixAddress address)
        {
            Address = address;
        }
    }
}