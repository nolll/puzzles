using Puzzles.common.Puzzles;

namespace Puzzles.aoc.Puzzles.Aoc2015.Aoc201511;

public class Aoc201511: AocPuzzle
{
    private CorporatePasswordValidator? _validator;
    private string? _firstPassword;

    private CorporatePasswordValidator Validator => _validator ??= new CorporatePasswordValidator();
    private string FirstPassword => _firstPassword ??= Validator.FindNextPassword(Input);

    public override string Name => "Corporate Policy";

    protected override PuzzleResult RunPart1()
    {
        return new PuzzleResult(FirstPassword, "cbfa97a52cf7d437b49df9f708d401ec");
    }

    protected override PuzzleResult RunPart2()
    {
        var pwd2 = Validator.FindNextPassword(FirstPassword);
        return new PuzzleResult(pwd2, "604b8c33c454d9dbcc19b86576a16f1c");
    }

    private const string Input = "hxbxwxba";
}