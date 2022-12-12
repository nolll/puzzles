using System.Collections.Generic;
using System.Linq;
using Core.Common.CoordinateSystems;
using Core.Common.CoordinateSystems.CoordinateSystem2D;
using Core.Common.Strings;

namespace Core.Puzzles.Year2016.Day24;

public class AirDuctNavigator
{
    private IList<AirDuctLocation> _locations;
    private DynamicMatrix<char> _matrix;
    private readonly IDictionary<(char, char), AirDuctPath> _paths;
    private readonly IDictionary<string, int> _cache;
    private AirDuctRobot _robot;

    public AirDuctNavigator(string input)
    {
        _paths = new Dictionary<(char, char), AirDuctPath>();
        _cache = new Dictionary<string, int>();
        Init(input);
        MapPaths();
    }

    public int Run(bool goBackToStartWhenDone)
    {
        return FindShortestPath(goBackToStartWhenDone);
    }

    private int FindShortestPath(bool goBackToStartWhenDone)
    {
        var allPaths = GetAllPaths(_robot.Address);
        var startPaths = GetStartPaths(allPaths);
        var stepCounts = new List<int>();
            
        foreach (var path in startPaths)
        {
            var stepCount = FollowPath(path, new List<AirDuctLocation>(), goBackToStartWhenDone);
            stepCounts.Add(stepCount);
        }

        return stepCounts.Any() ? stepCounts.Min() : 0;
    }

    private int FindShortestPathFrom(AirDuctLocation currentLocation, IList<AirDuctLocation> visitedLocations, bool goBackToStartWhenDone)
    {
        var stepCounts = new List<int>();
        var pathsToFollow = new List<AirDuctPath>();
        var remainingLocations = GetRemainingLocations(visitedLocations);
        foreach (var location in remainingLocations)
        {
            if (location.Id != currentLocation.Id)
            {
                var path = _paths[(currentLocation.Id, location.Id)];
                pathsToFollow.Add(path);
            }
        }

        foreach (var path in pathsToFollow)
        {
            var stepCount = FollowPath(path, visitedLocations, goBackToStartWhenDone);
            stepCounts.Add(stepCount);
        }

        return stepCounts.Any() ? stepCounts.Min() : 0;
    }

    private IEnumerable<AirDuctLocation> GetRemainingLocations(IList<AirDuctLocation> visitedLocations)
    {
        return _locations.Where(location => visitedLocations.All(o => o.Id != location.Id));
    }

    private int FollowPath(AirDuctPath path, IList<AirDuctLocation> visitedLocations, bool goBackToStartWhenDone)
    {
        var stepCount = path.StepCount;
        var newVisitedLocations = visitedLocations.Select(o => o).ToList();
        newVisitedLocations.Add(path.Target);

        if (newVisitedLocations.Count < _locations.Count)
        {
            var cacheKey = GetCacheKey(path.Target.Id, visitedLocations);
            if (!_cache.TryGetValue(cacheKey, out var cachedStepCount))
            {
                cachedStepCount = FindShortestPathFrom(path.Target, newVisitedLocations, goBackToStartWhenDone);
                _cache.Add(cacheKey, cachedStepCount);
            }

            stepCount += cachedStepCount;
        }
        else if(goBackToStartWhenDone)
        {
            var stepCountBackToStart = _paths[(path.Target.Id, '0')].StepCount;
            stepCount += stepCountBackToStart;
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
        _matrix = new DynamicMatrix<char>();
        var rows = PuzzleInputReader.ReadLines(input);
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

        foreach (var location in _locations)
        {
            var coords = PathFinder.ShortestPathTo(_matrix, startAddress, location.Address);
            if (coords.Count > 0)
            {
                paths.Add(new AirDuctPath(location, coords.Count));
            }
        }

        return paths;
    }

    private void MapPaths()
    {
        var homeLocation = new AirDuctLocation('0', _robot.Address);
        var locationIncludingHomeLocation = _locations.Select(o => o).ToList();
        locationIncludingHomeLocation.Add(homeLocation);
        foreach (var location in locationIncludingHomeLocation)
        {
            var otherKeys = locationIncludingHomeLocation.Where(o => o.Id != location.Id);
            foreach (var otherLocation in otherKeys)
            {
                if(_paths.ContainsKey((location.Id, otherLocation.Id)) || _paths.ContainsKey((otherLocation.Id, location.Id)))
                    continue;
                    
                var stepCountToLocation = PathFinder.QuickStepCountTo(_matrix, location.Address, otherLocation.Address);
                var pathToLocation = new AirDuctPath(otherLocation, stepCountToLocation);
                var pathBack = new AirDuctPath(location, stepCountToLocation);
                _paths.Add((location.Id, otherLocation.Id), pathToLocation);
                _paths.Add((otherLocation.Id, location.Id), pathBack);
            }
        }
    }
}