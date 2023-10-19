using Common.Puzzles;
using System.IO;

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
        var lines = input.Split(Environment.NewLine).ToArray();
        var dataLines = lines.Skip(1).ToArray();
        var trainNames = lines.First().Split(',').Skip(1).ToArray();
        var stationNames = lines.Skip(1).Select(o => o[..1]).ToArray();
        var stations = new List<Station>();
        var routeTimestamps = trainNames.Select(o => new List<int?>()).ToList();
        var trains = new Dictionary<int, Train>();

        for (var i = 0; i < dataLines.Length; i++)
        {
            var line = dataLines[i];
            var station = new Station(stationNames[i]);
            stations.Add(station);

            var timeData = line.Split(',').Skip(1).ToArray();
            for (var j = 0; j < timeData.Length; j++)
            {
                int? time = timeData[j].Length > 0 ? ParseMinutes(timeData[j]) : null;
                routeTimestamps[j].Add(time);
            }
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
        public Train? CurrentTrain = null;
        public int CurrentTrainTime = 0;
        
        public Station(string name)
        {
            Name = name;
        }
    }
    
    private class Train
    {
        public int StartTime { get; set; }
        public Station? StartStation { get; set; }
        public List<Leg> Legs { get; set; }
        public int TimeTravelled { get; set; }
        public int StationTimeLeft { get; set; }
        public Station? CurrentStation { get; set; }
        public bool ArrivedAtLastStation { get; set; }
    }

    private class Leg
    {
        public Station From { get; set; }
        public Station To { get; set; }
        public int Time { get; set; }
    }

    private class StationTimestamp
    {
        public string StationName { get; set; }
        public int Time { get; set; }
    }
}