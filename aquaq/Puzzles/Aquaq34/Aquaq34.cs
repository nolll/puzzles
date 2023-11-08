using Common.Puzzles;
using System.Diagnostics;

namespace Aquaq.Puzzles.Aquaq34;

public class Aquaq34 : AquaqPuzzle
{
    public override string Name => "Train in Vain";

    protected override PuzzleResult Run()
    {
        var result = LongestRouteTime(InputFile);

        return new PuzzleResult(result, (string?)null);
    }

    public static int LongestRouteTime(string input)
    {
        var lines = input.Split(Environment.NewLine).ToArray();
        var dataLines = lines.Skip(1).ToArray();
        var trainNames = lines.First().Split(',').Skip(1).ToArray();
        var stationNames = lines.Skip(1).Select(o => o[..1]).ToArray();
        var stations = new List<Station>();
        var routeTimestamps = trainNames.Select(o => new List<RouteTimestamp>()).ToList();

        for (var i = 0; i < dataLines.Length; i++)
        {
            var line = dataLines[i];
            var station = new Station($"Station {stationNames[i]}");
            stations.Add(station);

            var timeData = line.Split(',').Skip(1).ToArray();
            for (var j = 0; j < timeData.Length; j++)
            {
                int? time = timeData[j].Length > 0 ? ParseMinutes(timeData[j]) : null;
                var timestamp = new RouteTimestamp
                {
                    Numeric = time,
                    Textual = timeData[j]
                };
                routeTimestamps[j].Add(timestamp);
            }
        }

        var trains = new List<Train>();
        var trainId = 1;
        foreach (var timestamps in routeTimestamps)
        {
            var strId = trainId.ToString().PadLeft(4, '0');
            var train = new Train
            {
                Name = $"Train {strId}"
            };

            for (var i = 0; i < timestamps.Count; i++)
            {
                var timestamp = timestamps[i];
                if(timestamp.Numeric == null)
                    continue;

                var station = stations[i];

                if (train.StartStation is null)
                {
                    train.StartStation = station;
                    train.StartTime = timestamp.Numeric.Value;
                    train.StartTimeStr = timestamp.Textual;
                }
                else
                {
                    var from = train.Legs.Any() 
                        ? train.Legs.Last().To 
                        : train.StartStation;

                    var departureTime = train.Legs.Any()
                        ? train.Legs.Last().ArrivalTime
                        : train.StartTime;

                    var departureTimeStr = train.Legs.Any()
                        ? train.Legs.Last().ArrivalTimeStr
                        : train.StartTimeStr;

                    var arrivalTime = timestamp.Numeric.Value;
                    var arrivalTimeStr = timestamp.Textual;

                    var leg = new Leg
                    {
                        From = from,
                        To = station,
                        DepartureTime = departureTime,
                        DepartureTimeStr = departureTimeStr,
                        ArrivalTime = arrivalTime,
                        ArrivalTimeStr = arrivalTimeStr
                    };

                    train.Legs.Add(leg);
                }
            }

            train.LegCount = train.Legs.Count;
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
                else
                {
                    train.TimeLeftAtStation--;
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
                }
                else
                {
                    train.TimeLeftToDestination--;
                }
            }

            // WAITING -> AT STATION
            foreach (var station in stations)
            {
                var trainIsInStation = trains.Any(o => o.State == TrainState.AtStation && o.CurrentStation!.Name == station.Name);
                if(trainIsInStation)
                    continue;

                var waiting = trains
                    .Where(o => o.State == TrainState.Waiting && o.CurrentStation?.Name == station.Name)
                    .OrderBy(o => o.LastStation?.Name ?? "")
                    .ThenBy(o => o.Name)
                    .ToList();
                
                var firstInLine = waiting.FirstOrDefault();

                if (firstInLine is not null)
                {
                    firstInLine.State = TrainState.AtStation;
                    firstInLine.TimeLeftAtStation = 4;
                }
            }

            elapsed++;
        }

        trains = trains.OrderByDescending(o => o.TimeTravelled).ToList();
        var longestTime = trains.First().TimeTravelled;

        return longestTime;
    }

    private static int ParseMinutes(string time)
    {
        var parts = time.Split(':');
        int.TryParse(parts[0].TrimStart('0'), out var hours);
        int.TryParse(parts[1].TrimStart('0'), out var minutes);
        return hours * 60 + minutes;
    }

    [DebuggerDisplay("{Name}")]
    private class Station
    {
        public string Name { get; }
        
        public Station(string name)
        {
            Name = name;
        }
    }
    
    private class Train
    {
        public string Name { get; set; }
        public int StartTime { get; set; }
        public string StartTimeStr { get; set; }
        public Station? StartStation { get; set; }
        public List<Leg> Legs { get; set; } = new List<Leg>();
        public int LegCount { get; set; }
        public int TimeTravelled => ArrivalTime - StartTime;
        public Station? CurrentStation { get; set; }
        public Station? LastStation { get; set; }
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
        public string DepartureTimeStr { get; set; }
        public int ArrivalTime { get; set; }
        public string ArrivalTimeStr { get; set; }
        public int TravelTime => ArrivalTime - DepartureTime;
    }

    private class RouteTimestamp
    {
        public int? Numeric { get; set; }
        public string Textual { get; set; }
    }
}