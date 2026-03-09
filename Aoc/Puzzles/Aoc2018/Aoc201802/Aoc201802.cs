using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201802;

[Name("Inventory Management System")]
public class Aoc201802 : AocPuzzle
{
    [Puzzle("e7ee8e8967be0ed8c2fe23ef3e7d765e")]
    public int Part1(string input) => new BoxChecksumPuzzle(input).Checksum;

    [Puzzle("dec3acac891412bfec2fff6435645abd")]
    public string Part2(string input) => new SimilarIdsPuzzle(input).CommonLetters;
}