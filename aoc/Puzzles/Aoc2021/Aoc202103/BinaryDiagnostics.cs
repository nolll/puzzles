using Puzzles.common.Strings;

namespace Puzzles.aoc.Puzzles.Aoc2021.Aoc202103;

public class BinaryDiagnostics
{
    public int GetFuelConsumption(string input)
    {
        var lines = StringReader.ReadLines(input);
        var charLists = lines.Select(o => o.ToCharArray()).ToList();

        var size = charLists.First().Length;
        var zeroCounts = new int[size];
        var oneCounts = new int[size];

        foreach (var chars in charLists)
        {
            for (var i = 0; i < size; i++)
            {
                var c = chars[i];
                if (c == '0')
                    zeroCounts[i]++;
                else
                    oneCounts[i]++;
            }
        }

        var resultA = new int[size];
        var resultB = new int[size];
        for (var i = 0; i < size; i++)
        {
            if (oneCounts[i] > zeroCounts[i])
                resultA[i] = 1;
            else
                resultB[i] = 1;
        }

        var sa = string.Join("", resultA.Select(o => o.ToString()));
        var sb = string.Join("", resultB.Select(o => o.ToString()));
        var a = Convert.ToInt32(sa, 2);
        var b = Convert.ToInt32(sb, 2);

        return a * b;
    }

    public int GetLifeSupportRating(string input)
    {
        var lines = StringReader.ReadLines(input);
        var charLists = lines.Select(o => o.ToCharArray()).ToList();
        var size = lines.First().Length;
        var oxygenGeneratorRating = charLists.ToList();
            
        for (var i = 0; i < size; i++)
        {
            var index = i;
            var oneCounts = oxygenGeneratorRating.Select(o => o[index]).Count(o => o == '1');
            var zeroCounts = oxygenGeneratorRating.Count - oneCounts;
            var charToKeep = oneCounts >= zeroCounts
                ? '1'
                : '0';

            oxygenGeneratorRating = oxygenGeneratorRating.Where(o => o[index] == charToKeep).ToList();

            if (oxygenGeneratorRating.Count == 1)
                break;
        }

        var co2ScrubberRating = charLists.ToList();

        for (var i = 0; i < size; i++)
        {
            var index = i;
            var oneCounts = co2ScrubberRating.Select(o => o[index]).Count(o => o == '1');
            var zeroCounts = co2ScrubberRating.Count - oneCounts;
            var charToKeep = oneCounts < zeroCounts
                ? '1'
                : '0';

            co2ScrubberRating = co2ScrubberRating.Where(o => o[index] == charToKeep).ToList();

            if (co2ScrubberRating.Count == 1)
                break;
        }

        var sa = string.Join("", oxygenGeneratorRating.First().Select(o => o.ToString()));
        var sb = string.Join("", co2ScrubberRating.First().Select(o => o.ToString()));
        var a = Convert.ToInt32(sa, 2);
        var b = Convert.ToInt32(sb, 2);

        return a * b;
    }
}