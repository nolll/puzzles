using Common.Puzzles;

namespace Aquaq.Puzzles.Aquaq17;

public class Aquaq17 : AquaqPuzzle
{
    public override string Name => "The Beautiful Shame";

    protected override PuzzleResult Run()
    {
        return new PuzzleResult(Run(InputFile));
    }

    public static string Run(string input)
    {
        var lines = input.Split(Environment.NewLine);

        return "";
    }
}