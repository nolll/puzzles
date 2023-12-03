namespace Puzzles.Aoc.Puzzles.Aoc2015.Aoc201509;

public class Distance
{
    public string From { get; }
    public string To { get; }
    public int Dist { get; }

    public Distance(string from, string to, int dist)
    {
        From = @from;
        To = to;
        Dist = dist;
    }
}