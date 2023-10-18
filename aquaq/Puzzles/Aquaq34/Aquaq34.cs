using Common.Puzzles;

namespace Aquaq.Puzzles.Aquaq34;

public class Aquaq34 : AquaqPuzzle
{
    public override string Name => "Train in Vain";

    protected override PuzzleResult Run()
    {
        var result = LongestRouteTime(InputFile);

        return new PuzzleResult(result);
    }

    public static int LongestRouteTime(string input)
    {
        var lines = input.Split(Environment.NewLine);
        var stations = new Dictionary<string, Station>();
        var firstLineParts = lines.First().Split(',').Skip(1).ToList();
        var routes = firstLineParts.Select(o => new Route(o)).ToArray();
        var trains = firstLineParts.Select(o => new Train(o)).ToArray();
        foreach (var line in lines.Skip(1))
        {
            var parts = line.Split(',');
            var stationName = parts[0];
            stations.Add(stationName, new Station(stationName));

            var times = parts.Skip(1).ToArray();
            for (var i = 0; i < times.Length; i++)
            {
                var time = times[i];
                if (time.Length == 0)
                    continue;

                var route = routes[i];
                var timetableTime = ParseMinutes(time);
                var minutesSinceLast = route.Stops.Any()
                    ? timetableTime - route.Stops.Last().TimetableTime
                    : timetableTime;

                route.Stops.Add(new Stop(stationName, minutesSinceLast, timetableTime));
            }
        }

        var elapsed = 0;
        var travellingTrains = trains.ToList();
        while (travellingTrains.Any())
        {

            travellingTrains = travellingTrains.Where(o => !o.Arrived).ToList();
            elapsed++;
        }

        return 0;
    }

    private static int ParseMinutes(string time)
    {
        var parts = time.Split(':');
        int.TryParse(parts[0].TrimStart('0'), out var hours);
        int.TryParse(parts[1].TrimStart('0'), out var minutes);
        return hours * 60 + minutes;
    }

    private class Station
    {
        public string Name { get; }
        public List<Train> Waiting { get; } = new();
        
        public Station(string name)
        {
            Name = name;
        }
    }

    private class Route
    {
        public string Name { get; }
        public List<Stop> Stops { get; } = new();

        public Route(string name)
        {
            Name = name;
        }
    }

    private class Stop
    {
        public string StationName { get; }
        public int TravelTime { get; }
        public int TimetableTime { get; }

        public Stop(string stationName, int travelTime, int timetableTime)
        {
            StationName = stationName;
            TravelTime = travelTime;
            TimetableTime = timetableTime;
        }
    }

    private class Train
    {
        public string Route { get; }
        public Station? LastStation { get; set; }
        public int TimeTravelled { get; set; } = 0;
        public bool Arrived { get; set; }

        public Train(string route)
        {
            Route = route;
        }
    }
}