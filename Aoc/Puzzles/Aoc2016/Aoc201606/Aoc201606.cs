using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201606;

[Name("Signals and Noise")]
public class Aoc201606 : AocPuzzle
{
    protected override PuzzleResult RunPart1(string input)
    {
        var reader = new RepetitionCodeReader();
        var messageMostCommon = reader.ReadMostCommon(input);
        return new PuzzleResult(messageMostCommon, "d501463dd43fdef3d85d722210ab3940");
    }

    protected override PuzzleResult RunPart2(string input)
    {
        var reader = new RepetitionCodeReader();
        var messageLeastCommon = reader.ReadLeastCommon(input);
        return new PuzzleResult(messageLeastCommon, "509675b487b1cf475001b9592fab4a95");
    }
}