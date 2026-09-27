using System.Diagnostics;
using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aquaq.Puzzles;

[Name("Train in Vain")]
public class Aquaq34 : AquaqPuzzle
{
    private const int TimeAtStation = 5;
    private static readonly IComparer<Train> TrainComparer = new WaitingTrainComparer();

    [Puzzle("7730ffba6665d8cc2f907ff7ea6fe6ea")]
    public int Solve(string input)
    {
        var lines = input.Split(LineBreaks.Single);
        var dataLines = lines.Skip(1).ToArray();
        var trainNames = lines.First().Split(',').Skip(1).ToArray();
        var stationNames = lines.Skip(1).Select(o => o[..1]).ToArray();
        var stations = new List<Station>();
        var routeTimestamps = trainNames.Select(_ => new List<int?>()).ToList();

        for (var i = 0; i < dataLines.Length; i++)
        {
            var line = dataLines[i];
            var station = new Station($"Station {stationNames[i]}");
            stations.Add(station);

            var timeData = line.Split(',').Skip(1).ToArray();
            for (var j = 0; j < timeData.Length; j++)
            {
                int? timestamp = timeData[j].Length > 0 ? ParseMinutes(timeData[j]) : null;
                routeTimestamps[j].Add(timestamp);
            }
        }

        var trains = new List<Train>();
        var trainId = 1;
        foreach (var timestamps in routeTimestamps)
        {
            var train = new Train
            {
                RouteId = trainId,
                State = TrainState.NotStarted
            };

            for (var i = 0; i < timestamps.Count; i++)
            {
                var timestamp = timestamps[i];
                if(timestamp is null)
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
            trainId++;
        }

        var elapsed = 0;
        while (trains.Any(o => o.State != TrainState.Finished))
        {
            // AT STATION -> TRAVELLING OR FINISHED
            var atStation = trains.Where(o => o.State == TrainState.AtStation);
            foreach (var train in atStation)
            {
                train.TimeLeftAtStation--;
                if (train.TimeLeftAtStation == 0)
                {
                    train.CurrentStation = null;
                    if (!train.Legs.Any())
                    {
                        train.State = TrainState.Finished;
                        train.ArrivalTime = elapsed;
                    }
                    else
                    {
                        train.State = TrainState.Travelling;
                        train.TimeLeftToDestination = train.Legs.First().TravelTime;
                    }
                }
            }

            // NOT STARTED -> WAITING
            var notStarted = trains.Where(o => o.State == TrainState.NotStarted);
            foreach (var train in notStarted)
            {
                if (train.StartTime == elapsed)
                {
                    train.State = TrainState.Waiting;
                    train.CurrentStation = train.StartStation;
                    train.TimeWaited = 1;
                }
            }

            // TRAVELLING -> WAITING
            var travelling = trains.Where(o => o.State == TrainState.Travelling);
            foreach (var train in travelling)
            {
                if (train.TimeLeftToDestination == 0)
                {
                    train.State = TrainState.Waiting;
                    var currentLeg = train.Legs.First();
                    train.LastStation = currentLeg.From;
                    train.CurrentStation = currentLeg.To;
                    train.Legs.RemoveAt(0);
                    train.TimeWaited = 1;
                }
                else
                {
                    train.TimeLeftToDestination--;
                }
            }

            // WAITING -> AT STATION
            foreach (var station in stations)
            {
                var trainIsInStation = trains.Any(o => o.State == TrainState.AtStation && o.CurrentStation?.Name == station.Name);
                if(trainIsInStation)
                    continue;

                var waiting = trains
                    .Where(o => o.State == TrainState.Waiting && o.CurrentStation?.Name == station.Name)
                    .Order(TrainComparer)
                    .ToList();
                
                var firstInLine = waiting.FirstOrDefault();
                if (firstInLine is not null)
                {
                    firstInLine.State = TrainState.AtStation;
                    firstInLine.TimeLeftAtStation = TimeAtStation;
                }

                foreach (var train in waiting.Skip(1))
                {
                    train.TimeWaited += 1;
                }
            }

            elapsed++;
        }

        return trains.Max(o => o.TimeTravelled);
    }

    private static int ParseMinutes(string time)
    {
        var parts = time.Split(':');
        int.TryParse(parts[0].TrimStart('0'), out var hours);
        int.TryParse(parts[1].TrimStart('0'), out var minutes);
        return hours * 60 + minutes;
    }
    
    public class Leg
    {
        public Station? From { get; init; }
        public Station? To { get; init; }
        public int DepartureTime { get; init; }
        public int ArrivalTime { get; init; }
        public int TravelTime => ArrivalTime - DepartureTime;
    }
    
    [DebuggerDisplay("{Name}")]
    public record Station(string Name);
    
    public class Train
    {
        public TrainState State { get; set; }
        public int RouteId { get; init; }
        public int StartTime { get; set; }
        public int ArrivalTime { get; set; }
        public Station? StartStation { get; set; }
        public Station? CurrentStation { get; set; }
        public Station? LastStation { get; set; }
        public List<Leg> Legs { get; } = new();
        public int TimeTravelled => ArrivalTime - StartTime;
        public int TimeLeftAtStation { get; set; }
        public int TimeLeftToDestination { get; set; }
        public int TimeWaited { get; set; }
    }
    
    public enum TrainState
    {
        NotStarted,
        Waiting,
        AtStation,
        Travelling,
        Finished
    }

    private class WaitingTrainComparer : IComparer<Train>
    {
        public int Compare(Train? a, Train? b)
        {
            if (a is null || b is null)
                return 0;

            if (a.LastStation is null || b.LastStation is null)
                return CompareOriginatingTrains(a, b);

            return CompareOtherTrains(a, b);
        }

        private static int CompareOriginatingTrains(Train a, Train b)
        {
            if (a.LastStation is null && b.LastStation is not null)
                return -1;

            if (a.LastStation is not null && b.LastStation is null)
                return 1;

            var startStationCompare = string.Compare(a.StartStation?.Name, b.StartStation?.Name, StringComparison.Ordinal);
        
            return startStationCompare != 0 
                ? startStationCompare 
                : a.RouteId.CompareTo(b.RouteId);
        }

        private static int CompareOtherTrains(Train a, Train b)
        {
            var lastStationCompare = string.Compare(a.LastStation?.Name, b.LastStation?.Name, StringComparison.Ordinal);
        
            return lastStationCompare != 0 
                ? lastStationCompare 
                : b.TimeWaited.CompareTo(a.TimeWaited);
        }
    }
}