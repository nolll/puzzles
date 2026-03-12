using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202108;

[Name("Seven Segment Search")]
public class Aoc202108 : AocPuzzle
{
    [Puzzle("c5b4722b08a65550734c7c02f5531c8c")]
    public int Part1(string input) => new SevenSegmentDisplayDecoder(input).GetEasyNumbers();

    [Puzzle("95e5d901f00d91ced841dcf2c09f8fe9")]
    public int Part2(string input) => new SevenSegmentDisplayDecoder(input).GetDecodedSum();
}