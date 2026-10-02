using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2016;

[Name("Timing is Everything")]
public class Aoc201615 : AocPuzzle
{
    [Puzzle("c2b25510c1da608c5f3a22a5d84c55dd")]
    public int Part1(string input) => Run(input);

    [Puzzle("7e078d8dabad268a34def302abd59ce8")]
    public int Part2(string input) => Run(input, true);

    private int Run(string input, bool addExtraDisc = false)
    {
        var discs = ParseDiscs(input);
        if (addExtraDisc)
            discs.Add(new KineticSculptureDisc(11, 0));
        var time = 0;

        while (true)
        {
            var passed = true;
            var discCount = 0;
            foreach (var disc in discs)
            {
                if (!disc.Passed(time + discCount))
                {
                    passed = false;
                    break;
                }

                discCount++;
            }

            if (passed)
                break;

            time++;
        }

        return time - 1;
    }

    private static IList<KineticSculptureDisc> ParseDiscs(string input) =>
        input.Split(LineBreaks.Single).Select(ParseDisc).ToList();

    private static KineticSculptureDisc ParseDisc(string s)
    {
        var parts = s.Replace(".", "").Split(' ');
        var position = int.Parse(parts[3]);
        var startPos = int.Parse(parts[11]);
        return new KineticSculptureDisc(position, startPos);
    }
    
    public class KineticSculptureDisc(in int positions, int startPos)
    {
        private readonly int _positions = positions;

        public bool Passed(in int time)
        {
            return (time + startPos) % _positions == 0;
        }
    }
}
