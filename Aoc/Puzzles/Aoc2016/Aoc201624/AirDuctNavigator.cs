using Pzl.Tools.Grids.Grids2d;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201624;

public class AirDuctNavigator
{
    private List<AirDuctLocation> _locations = [];
    private Grid<char> _grid = new();
    private readonly Dictionary<(char, char), AirDuctPath> _paths = new();
    private readonly Dictionary<string, int> _cache = new();
    private AirDuctRobot _robot = new(new Coord(0, 0));

    public AirDuctNavigator(string input)
    {
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
        var stepCounts = startPaths.Select(path => FollowPath(path, [], goBackToStartWhenDone)).ToList();

        return stepCounts.Count > 0 ? stepCounts.Min() : 0;
    }

    private int FindShortestPathFrom(AirDuctLocation currentLocation, IList<AirDuctLocation> visitedLocations, bool goBackToStartWhenDone)
    {
        var remainingLocations = GetRemainingLocations(visitedLocations);
        var stepCounts = remainingLocations.Where(o => o.Id != currentLocation.Id)
            .Select(o => _paths[(currentLocation.Id, o.Id)])
            .Select(path => FollowPath(path, visitedLocations, goBackToStartWhenDone)).ToList();

        return stepCounts.Count > 0 ? stepCounts.Min() : 0;
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

    private static string GetCacheKey(char key, IList<AirDuctLocation> visitedLocations)
    {
        var joinedKeys = string.Join('-', visitedLocations.OrderBy(o => o.Id).Select(o => o.Id));
        return $"{key}.{joinedKeys}";
    }

    private void Init(string input)
    {
        _locations = [];
        _grid = new Grid<char>();
        var rows = StringReader.ReadLines(input);
        var y = 0;
        foreach (var row in rows)
        {
            var x = 0;
            var chars = row.Trim().ToCharArray();
            foreach (var c in chars)
            {
                var address = new Coord(x, y);
                _grid.MoveTo(address);
                var charToWrite = c;

                if (char.IsNumber(c))
                {
                    charToWrite = '.';
                    if(c == '0')
                        _robot = new AirDuctRobot(address);
                    else
                        _locations.Add(new AirDuctLocation(c, address));
                }

                _grid.WriteValue(charToWrite);

                x += 1;
            }

            y += 1;
        }
    }

    private static IList<AirDuctPath> GetStartPaths(IList<AirDuctPath> allPaths) => allPaths.ToList();

    private IList<AirDuctPath> GetAllPaths(Coord startAddress)
    {
        var paths = new List<AirDuctPath>();

        foreach (var location in _locations)
        {
            var coords = PathFinder.ShortestPathTo(_grid, startAddress, location.Address);
            if (coords.Count > 0) 
                paths.Add(new AirDuctPath(location, coords.Count));
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
                    
                var stepCountToLocation = PathFinder.ShortestPathTo(_grid, location.Address, otherLocation.Address).Count;
                var pathToLocation = new AirDuctPath(otherLocation, stepCountToLocation);
                var pathBack = new AirDuctPath(location, stepCountToLocation);
                _paths.Add((location.Id, otherLocation.Id), pathToLocation);
                _paths.Add((otherLocation.Id, location.Id), pathBack);
            }
        }
    }
}