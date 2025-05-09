using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201615;

public class KineticSculpture
{
    public int TimeToPressButton { get; }

    public KineticSculpture(string input, bool addExtraDisc = false)
    {
        var discs = ParseDiscs(input);
        if(addExtraDisc)
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

        TimeToPressButton = time - 1;
    }

    private IList<KineticSculptureDisc> ParseDiscs(string input)
    {
        var rows = StringReader.ReadLines(input);
        return rows.Select(ParseDisc).ToList();
    }

    private KineticSculptureDisc ParseDisc(string s)
    {
        var parts = s.Replace(".", "").Split(' ');
        var position = int.Parse(parts[3]);
        var startPos = int.Parse(parts[11]);
        return new KineticSculptureDisc(position, startPos);
    }
}