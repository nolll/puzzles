using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201801;

[Name("Chronal Calibration")]
public class Aoc201801 : AocPuzzle
{
    [Puzzle("6161dde7fc767cd20548aa2a500b6af4")]
    public int Part1(string input) => new FrequencyPuzzle(input).ResultingFrequency;

    [Puzzle("fba794668dca2e1a271d8ead203f36d2")]
    public int Part2(string input) => new FrequencyRepeatPuzzle(input).FirstRepeatedFrequency ?? 0;
}