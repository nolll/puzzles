namespace Pzl.Aquaq.Puzzles.Aquaq08;

public class Day
{
    public DateTime DateTime { get; }
    public int Milk { get; }
    public int Cereal { get; }

    public Day(DateTime dateTime, int milk, int cereal)
    {
        DateTime = dateTime;
        Milk = milk;
        Cereal = cereal;
    }
}