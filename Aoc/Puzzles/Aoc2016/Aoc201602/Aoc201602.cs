using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201602;

[Name("Bathroom Security")]
public class Aoc201602 : AocPuzzle
{
    [Puzzle("bc6c7825d96d5406ad3776a37c342187")]
    public string Part1(string input) => new SquareKeyCodeFinder().Find(input);
    

    [Puzzle("e0e405db166ec0ceae706cf925ff34a9")]
    public string Part2(string input) => new DiamondKeyCodeFinder().Find(input);
}