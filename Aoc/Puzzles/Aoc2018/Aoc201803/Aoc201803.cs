using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201803;

[Name("No Matter How You Slice It")]
public class Aoc201803 : AocPuzzle
{
    [Puzzle("06a186fe1ad0ea2861a42fd9809e491e")]
    public int Part1(string input) => new ClaimsOverlapCountPuzzle(input).OverlapCount;

    [Puzzle("442af765a98dc2465a7db5a4e92167a4")]
    public int Part2(string input) => new ClaimThatDoesNotOverlapPuzzle(input).ClaimId;
}