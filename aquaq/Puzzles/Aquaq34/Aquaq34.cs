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

            trains.Add(train);
            trainId++;
        }

        //foreach (var train in trains)
        //{
        //    Console.WriteLine(train.Name);
        //    foreach (var leg in train.Legs)
        //    {
        //        Console.WriteLine($"{leg.DepartureTimeStr}-{leg.ArrivalTimeStr}");
        //    }
        //    Console.WriteLine();
        //    Console.WriteLine();
        //}

        var notFinishedTrains = trains.ToList();

        var elapsed = 0;
        while (notFinishedTrains.Any())
        {
            // AT STATION -> TRAVELLING OR FINISHED
            var atStation = notFinishedTrains.Where(o => o.State == TrainState.AtStation);
            foreach (var train in atStation)
            {
                if (train.TimeLeftAtStation == 0)
                {
                    train.State = TrainState.Travelling;
                    train.CurrentStation = null;
                    if (!train.Legs.Any())
                    {
                        train.State = TrainState.Finished;
                        train.ArrivalTime = elapsed;
                    }
                    else
                    {
                        train.TimeLeftToDestination = train.Legs.First().TravelTime;
                    }
                }
                else
                {
                    train.TimeLeftAtStation--;
                }
            }

            // NOT STARTED -> WAITING
            var notStarted = notFinishedTrains.Where(o => o.State == TrainState.NotStarted);
            foreach (var train in notStarted)
            {
                if (train.StartTime == elapsed)
                {
                    train.State = TrainState.Waiting;
                    train.CurrentStation = train.StartStation;
                }
            }

            // TRAVELLING -> WAITING
            var travelling = notFinishedTrains.Where(o => o.State == TrainState.Travelling);
            foreach (var train in travelling)
            {
                if (train.TimeLeftToDestination == 0)
                {
                    train.State = TrainState.Waiting;
                    train.LastStation = train.Legs.First().From;
                    train.CurrentStation = train.Legs.First().To;
                    train.Legs = train.Legs.Skip(1).ToList();
                }
                else
                {
                    train.TimeLeftToDestination--;
                }
            }

            // WAITING -> AT STATION
            var waiting = notFinishedTrains.Where(o => o.State == TrainState.Waiting)
                .OrderBy(o => o.LastStation is null ? "a" : "b")
                .ThenBy(o => o.LastStation?.Name ?? "")
                .ThenBy(o => o.Name)
                .ToList();
            
            //foreach (var train in waiting)
            //{
            //    if (!notFinishedTrains.Any(o => o.State == TrainState.AtStation && o.CurrentStation!.Name == train.CurrentStation!.Name))
            //    {
            //        var first = waiting
            //            .First(o => o.CurrentStation?.Name == train.CurrentStation?.Name);

            //        if (train.Name == first.Name)
            //        {
            //            train.State = TrainState.AtStation;
            //            train.TimeLeftAtStation = 4;
            //        }
            //    }
            //}

            var trainsInStation = notFinishedTrains.Where(o => o.State == TrainState.AtStation).ToList();
            foreach (var station in stations)
            {
                var trainInStation = trainsInStation.FirstOrDefault(o => o.CurrentStation!.Name == station.Name);
                if(trainInStation is not null)
                    continue;

                var firstInLine = waiting
                    .Where(o => o.CurrentStation?.Name == station.Name)
                    .OrderBy(o => o.LastStation is null ? "a" : "b")
                    .ThenBy(o => o.LastStation?.Name ?? "")
                    .ThenBy(o => o.Name)
                    .FirstOrDefault();

                if (firstInLine is not null)
                {
                    firstInLine.State = TrainState.AtStation;
                    firstInLine.TimeLeftAtStation = 4;
                }
            }

            elapsed++;
            notFinishedTrains = notFinishedTrains.Where(o => o.State != TrainState.Finished).ToList();
        }

        //foreach (var train in trains)
        //{
        //    Console.WriteLine($"{train.Name} {train.TimeTravelled}. {train.StartTimeStr}");
        //}

        var longestTime = trains.Select(o => o.TimeTravelled).Max();

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