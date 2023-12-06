using Pzl.Tools.Lists;

namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201619;

public class WhiteElephantParty
{
    private readonly int _elfCount;

    public WhiteElephantParty(in int elfCount)
    {
        _elfCount = elfCount;
    }

    public int StealFromNextElf()
    {
        var circle = BuildCircle();
        var current = circle.First;

        while (circle.Count > 1)
        {
            var next = current!.NextOrFirst();
            circle.Remove(next);
            current = current!.NextOrFirst();
        }

        return current!.Value.Id;
    }

    public int StealFromElfAcrossCircle()
    {
        var circle = BuildCircle();
        var current = circle.First;
        var victim = circle.First;
        var halfWay = (int)Math.Floor((double)circle.Count / 2);
        for (var i = 0; i < halfWay; i++)
            victim = victim!.NextOrFirst();

        var elvesLeft = _elfCount;
        while (circle.Count > 1)
        {
            var nextVictim = elvesLeft % 2 == 1 ? victim!.NextOrFirst().NextOrFirst() : victim!.NextOrFirst();
            circle.Remove(victim!);
            current = current!.NextOrFirst();
            victim = nextVictim;
            elvesLeft--;
        }

        return current!.Value.Id;
    }

    private LinkedList<PartyElf> BuildCircle()
    {
        var circle = new LinkedList<PartyElf>();
        for (var i = 1; i <= _elfCount; i++)
        {
            circle.AddLast(new PartyElf(i));
        }

        return circle;
    }
}