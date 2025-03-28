using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201802;

public class BoxChecksumPuzzle
{
    public int Checksum { get; }

    public BoxChecksumPuzzle(string input)
    {
        var ids = StringReader.ReadLines(input);
        var idCharacteristics = ids.Select(o => new IdCharacteristics(o.Trim())).ToList();
        var doubleCount = idCharacteristics.Count(o => o.HasDoubleChars);
        var tripleCount = idCharacteristics.Count(o => o.HasTripleChars);
        Checksum = doubleCount * tripleCount;
    }
}