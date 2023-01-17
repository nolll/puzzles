namespace Core.Puzzles.Year2022.Day16;

public class ValveConnection
{
    public string Valve { get; }
    public int Cost { get; }

    public ValveConnection(string valve, int cost)
    {
        Valve = valve;
        Cost = cost;
    }
}