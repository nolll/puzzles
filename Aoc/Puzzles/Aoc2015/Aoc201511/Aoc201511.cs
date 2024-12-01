using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201511;

[Name("Corporate Policy")]
public class Aoc201511 : AocPuzzle
{
    private CorporatePasswordValidator? _validator;
    private string? _firstPassword;

    private CorporatePasswordValidator Validator => _validator ??= new CorporatePasswordValidator();
    private string FirstPassword(string input) => _firstPassword ??= Validator.FindNextPassword(input);

    public PuzzleResult RunPart1(string input)
    {
        return new PuzzleResult(FirstPassword(input), "cbfa97a52cf7d437b49df9f708d401ec");
    }

    public PuzzleResult RunPart2(string input)
    {
        var pwd2 = Validator.FindNextPassword(FirstPassword(input));
        return new PuzzleResult(pwd2, "604b8c33c454d9dbcc19b86576a16f1c");
    }
}