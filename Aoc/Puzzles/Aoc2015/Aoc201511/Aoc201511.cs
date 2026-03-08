using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201511;

[Name("Corporate Policy")]
public class Aoc201511 : AocPuzzle
{
    [Puzzle("cbfa97a52cf7d437b49df9f708d401ec")]
    public string Part1(string input) => CorporatePasswordValidator.FindNextPassword(input);

    [Puzzle("604b8c33c454d9dbcc19b86576a16f1c")]
    public string Part2(string input) => 
        CorporatePasswordValidator.FindNextPassword(CorporatePasswordValidator.FindNextPassword(input));
}