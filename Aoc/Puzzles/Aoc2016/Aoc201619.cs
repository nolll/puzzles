using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2016;

[Name("An Elephant Named Joseph")]
public class Aoc201619 : AocPuzzle
{
    [Puzzle("0ff6e8f1eb200db98926c54e1a1fac6a")]
    public int Part1(string input) => StealFromNextElf(input);

    [Puzzle("b67fd31a59ecdb3e94d0fbdfc778e61f")]
    public int Part2(string input) => StealFromElfAcrossCircle(input);

    public int StealFromNextElf(string input)
    {
        var elfCount = int.Parse(input);
        var circle = BuildCircle(elfCount);
        var current = circle.First;

        while (circle.Count > 1)
        {
            var next = current!.NextOrFirst();
            circle.Remove(next);
            current = current!.NextOrFirst();
        }

        return current!.Value.Id;
    }

    public int StealFromElfAcrossCircle(string input)
    {
        var elfCount = int.Parse(input);
        var circle = BuildCircle(elfCount);
        var current = circle.First;
        var victim = circle.First;
        var halfWay = (int)Math.Floor((double)circle.Count / 2);
        for (var i = 0; i < halfWay; i++)
            victim = victim!.NextOrFirst();

        var elvesLeft = elfCount;
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

    private static LinkedList<PartyElf> BuildCircle(int elfCount)
    {
        var circle = new LinkedList<PartyElf>();
        for (var i = 1; i <= elfCount; i++)
        {
            circle.AddLast(new PartyElf(i));
        }

        return circle;
    }

    private record PartyElf(int Id);
}