using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202108;

[Name("Seven Segment Search")]
public class Aoc202108 : AocPuzzle
{
    [Puzzle("c5b4722b08a65550734c7c02f5531c8c")]
    public PuzzleResult Part1(string input)
    {
        var decoder = new SevenSegmentDisplayDecoder(input);
        var result = decoder.GetEasyNumbers();
        return new PuzzleResult(result);
    }

    [Puzzle("95e5d901f00d91ced841dcf2c09f8fe9")]
    public PuzzleResult Part2(string input)
    {
        var decoder = new SevenSegmentDisplayDecoder(input);
        var result = decoder.GetDecodedSum();
        return new PuzzleResult(result);
    }
}