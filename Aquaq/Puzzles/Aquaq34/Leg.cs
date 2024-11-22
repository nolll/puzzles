namespace Pzl.Aquaq.Puzzles.Aquaq34;

public class Leg
{
    public Station? From { get; init; }
    public Station? To { get; init; }
    public int DepartureTime { get; init; }
    public int ArrivalTime { get; init; }
    public int TravelTime => ArrivalTime - DepartureTime;
}