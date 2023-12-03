using Puzzles.common.Puzzles;
using Puzzles.common.Strings;

namespace Puzzles.aquaq.Puzzles.Aquaq34;

public class Aquaq34 : AquaqPuzzle
{
    public override string Name => "Train in Vain";

    private const int TimeAtStation = 5;
    private static readonly IComparer<Train> WaitingTrainComparer = new WaitingTrainComparer();

    protected override PuzzleResult Run()
    {
        var result = LongestRouteTime(InputFile);

        return new PuzzleResult(result, "7730ffba6665d8cc2f907ff7ea6fe6ea");
    }

    public static int LongestRouteTime(string input)
    {
        var lines = StringReader.ReadLines(input).ToArray();
        var dataLines = lines.Skip(1).ToArray();
        var trainNames = lines.First().Split(',').Skip(1).ToArray();
        var stationNames = lines.Skip(1).Select(o => o[..1]).ToArray();
        var stations = new List<Station>();
        var routeTimestamps = trainNames.Select(o => new List<int?>()).ToList();

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
                    .Order(WaitingTrainComparer)
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
}