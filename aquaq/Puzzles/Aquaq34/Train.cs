namespace Puzzles.Aquaq.Puzzles.Aquaq34;

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