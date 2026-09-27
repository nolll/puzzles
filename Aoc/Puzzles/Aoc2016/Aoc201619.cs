using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2016;

[Name("An Elephant Named Joseph")]
public class Aoc201619 : AocPuzzle
{
    [Puzzle("0ff6e8f1eb200db98926c54e1a1fac6a")]
    public int Part1(string input) => new WhiteElephantParty(int.Parse(input)).StealFromNextElf();

    [Puzzle("b67fd31a59ecdb3e94d0fbdfc778e61f")]
    public int Part2(string input) => new WhiteElephantParty(int.Parse(input)).StealFromElfAcrossCircle();
    
    public class WhiteElephantParty(in int elfCount)
    {
        private readonly int _elfCount = elfCount;

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

    public record PartyElf(int Id);
}