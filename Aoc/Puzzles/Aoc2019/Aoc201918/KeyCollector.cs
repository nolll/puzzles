using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201918;

public class KeyCollector
{
    private IList<VaultKey> _keys = new List<VaultKey>();
    private IList<VaultDoor> _doors = new List<VaultDoor>();
    private Matrix<char> _matrix = new();
    private readonly IDictionary<(char, char), VaultPath> _paths;
    private readonly IDictionary<string, int> _cache;
    private readonly IList<VaultRobot> _robots;

    public int ShortestPath { get; private set; }

    public KeyCollector(string input, bool useFourRobots = false)
    {
        _paths = new Dictionary<(char, char), VaultPath>();
        _cache = new Dictionary<string, int>();
        _robots = new List<VaultRobot>();
        Init(input, useFourRobots);
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
            var reachableKeys = allPaths.Select(o => o.Target).ToList();
            var keysFoundByOtherRobots = GetKeysFoundByOtherRobots(reachableKeys);
            var startPaths = GetStartPaths(allPaths, reachableKeys);
            var stepCounts = new List<int>();

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
        var newCollectedKeys = new List<VaultKey> { path.Target };
        newCollectedKeys.AddRange(collectedKeys);
        if (newCollectedKeys.Count < _keys.Count)
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

    private void Init(string input, bool useFourRobots)
    {
        var rows = input.Trim().Split('\n');
        var width = rows.First().Length;
        var height = rows.Length;
        _keys = new List<VaultKey>();
        _doors = new List<VaultDoor>();
        _matrix = new Matrix<char>(width, height);
        var y = _matrix.YMin;
        var robotLocation = _matrix.StartAddress;
        foreach (var row in rows)
        {
            var x = _matrix.XMin;
            var chars = row.Trim().ToCharArray();
            foreach (var c in chars)
            {
                var address = new MatrixAddress(x, y);
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
                    robotLocation = address;
                    charToWrite = '@';
                }

                _matrix.WriteValueAt(address, charToWrite);

                x += 1;
            }

            y += 1;
        }

        if (useFourRobots)
        {
            _matrix.WriteValueAt(robotLocation.X, robotLocation.Y - 1, '#');
            _matrix.WriteValueAt(robotLocation.X - 1, robotLocation.Y, '#');
            _matrix.WriteValueAt(robotLocation, '#');
            _matrix.WriteValueAt(robotLocation.X + 1, robotLocation.Y, '#');
            _matrix.WriteValueAt(robotLocation.X, robotLocation.Y + 1, '#');

            var robot1Location = new MatrixAddress(robotLocation.X - 1, robotLocation.Y - 1);
            _matrix.WriteValueAt(robot1Location, '.'); 
            var robot1 = new VaultRobot(robot1Location);
            _robots.Add(robot1);

            var robot2Location = new MatrixAddress(robotLocation.X + 1, robotLocation.Y - 1);
            _matrix.WriteValueAt(robot2Location, '.');
            var robot2 = new VaultRobot(robot2Location);
            _robots.Add(robot2);

            var robot3Location = new MatrixAddress(robotLocation.X - 1, robotLocation.Y + 1);
            _matrix.WriteValueAt(robot3Location, '.'); 
            var robot3 = new VaultRobot(robot3Location);
            _robots.Add(robot3);

            var robot4Location = new MatrixAddress(robotLocation.X + 1, robotLocation.Y + 1);
            _matrix.WriteValueAt(robot4Location, '.'); 
            var robot4 = new VaultRobot(robot4Location);
            _robots.Add(robot4);
        }
        else
        {
            var robot = new VaultRobot(robotLocation);
            _matrix.WriteValueAt(robotLocation, '.');
            _robots.Add(robot);
        }
    }

    private IList<VaultPath> GetStartPaths(IList<VaultPath> allPaths, List<VaultKey> reachableKeys)
    {
        var paths = new List<VaultPath>();

        foreach (var path in allPaths)
        {
            var blockingDoors = FilterDoors(FindBlockingDoors(path.Coords), reachableKeys);
            if (!blockingDoors.Any())
                paths.Add(path);
        }

        return paths;
    }

    private IList<VaultDoor> FilterDoors(IEnumerable<VaultDoor> blockingDoors, IList<VaultKey> reachableKeys)
    {
        var foundByOthers = new List<VaultDoor>();
        foreach (var door in blockingDoors)
        {
            if (reachableKeys.Any(o => o.Id == char.ToLower(door.Id)))
                foundByOthers.Add(door);
        }
        return foundByOthers;
    }

    private IList<VaultPath> GetAllPaths(MatrixAddress startAddress)
    {
        var paths = new List<VaultPath>();

        foreach (var key in _keys)
        {
            var coords = PathFinder.ShortestPathTo(_matrix, startAddress, key.Address);
            if (coords.Count > 0)
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