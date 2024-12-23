namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201610;

public class OutputGiver : IGiver
{
    private readonly Dictionary<int, int> _outputs;
    private readonly int _id;

    public OutputGiver(Dictionary<int, int> outputs, int id)
    {
        _outputs = outputs;
        _id = id;
    }

    public void Give(int v)
    {
        _outputs[_id] = v;
    }
}