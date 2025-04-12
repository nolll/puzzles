using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201511;

[Name("Corporate Policy")]
public class Aoc201511 : AocPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var password = CorporatePasswordValidator.FindNextPassword(input);       
        return new PuzzleResult(password, "cbfa97a52cf7d437b49df9f708d401ec");
    }

    public PuzzleResult Part2(string input)
    {
        var pwd2 = CorporatePasswordValidator.FindNextPassword(CorporatePasswordValidator.FindNextPassword(input));
        return new PuzzleResult(pwd2, "604b8c33c454d9dbcc19b86576a16f1c");
    }
}