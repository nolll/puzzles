namespace Puzzles.Aoc.Puzzles.Aoc2016.Aoc201615;

public class KineticSculptureDisc
{
    private readonly int _positions;
    private readonly int _startPos;

    public KineticSculptureDisc(in int positions, int startPos)
    {
        _positions = positions;
        _startPos = startPos;
    }

    public bool Passed(in int time)
    {
        return (time + _startPos) % _positions == 0;
    }
}