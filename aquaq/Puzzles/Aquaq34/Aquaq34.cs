using System.Data;
using Common.Puzzles;
using System.IO;
using System.Transactions;

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

        var trains = new List<Train>();
        foreach (var timestamps in routeTimestamps)
        {
            var train = new Train();

            for (var i = 0; i < timestamps.Count; i++)
            {
                var timestamp = timestamps[i];
                if(timestamp == null)
                    continue;

                var station = stations[i];

                if (train.StartStation is null)
                {
                    train.StartStation = station;
                    train.StartTime = timestamp.Value;
                }
                else
                {
                    var from = train.Legs.Any() 
                        ? train.Legs.Last().To 
                        : train.StartStation;

                    var departureTime = train.Legs.Any()
                        ? train.Legs.Last().ArrivalTime
                        : train.StartTime;

                    var arrivalTime = timestamp.Value;

                    var leg = new Leg
                    {
                        From = from,
                        To = station,
                        DepartureTime = departureTime,
                        ArrivalTime = arrivalTime
                    };

                    train.Legs.Add(leg);
                }
            }

            trains.Add(train);
        }

        var elapsed = 0;
        while (trains.Any(o => o.State != TrainState.Finished) && elapsed < 1000)
        {
            var atStation = trains.Where(o => o.State == TrainState.AtStation);
            foreach (var train in atStation)
            {
                if (train.TimeLeftAtStation == 0)
                {
                    train.State = TrainState.Travelling;
                    train.CurrentStation = null;
                    train.TimeLeftToDestination = train.Legs.First().TravelTime;
                }
                else
                {
                    train.TimeLeftAtStation--;
                }
            }

            var travelling = trains.Where(o => o.State == TrainState.Travelling);
            foreach (var train in travelling)
            {
                if (train.TimeLeftToDestination == 0)
                {
                    train.State = TrainState.Waiting;
                }
                else
                {
                    train.TimeLeftToDestination--;
                }
            }

            var notStarted = trains.Where(o => o.State == TrainState.NotStarted);
            foreach (var train in notStarted)
            {
                if (train.StartTime == elapsed)
                {
                    train.State = TrainState.Waiting;
                    train.CurrentStation = train.StartStation;
                }
            }

            var waitingNotStarted = trains.Where(o => o.State == TrainState.Waiting && o.StartStation?.Name == o.CurrentStation?.Name);
            foreach (var train in waitingNotStarted)
            {
                if (!trains.Any(o => o.State == TrainState.AtStation && o.CurrentStation?.Name == train.CurrentStation?.Name))
                {
                    train.State = TrainState.AtStation;
                    train.TimeLeftAtStation = 5;
                    train.Legs = train.Legs.Skip(1).ToList();
                    if (!train.Legs.Any())
                    {
                        train.State = TrainState.Finished;
                        train.ArrivalTime = elapsed;
                    }
                }
            }

            var waiting = trains.Where(o => o.State == TrainState.Waiting).ToList();
            foreach (var train in waiting)
            {
                if (!trains.Any(o => o.State == TrainState.AtStation && o.CurrentStation?.Name == train.CurrentStation?.Name))
                {
                    train.State = TrainState.AtStation;
                    train.TimeLeftAtStation = 5;
                    train.Legs = train.Legs.Skip(1).ToList();
                    if (!train.Legs.Any())
                    {
                        train.State = TrainState.Finished;
                        train.ArrivalTime = elapsed;
                    }
                }
            }

            elapsed++;
        }

        var longestTime = trains.Select(o => o.ArrivalTime - o.StartTime).Max();

        return longestTime;
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
        public List<Leg> Legs { get; set; } = new List<Leg>();
        public int TimeTravelled { get; set; }
        public Station? CurrentStation { get; set; }
        public int TimeLeftAtStation { get; set; }
        public int TimeLeftToDestination { get; set; }
        public int ArrivalTime { get; set; }
        public TrainState State { get; set; }
    }

    private enum TrainState
    {
        NotStarted,
        Waiting,
        AtStation,
        Travelling,
        Finished
    }

    private class Leg
    {
        public Station? From { get; set; }
        public Station To { get; set; }
        public int DepartureTime { get; set; }
        public int ArrivalTime { get; set; }
        public int TravelTime => ArrivalTime - DepartureTime;
    }
}