using Common.Puzzles;

namespace Aquaq.Puzzles.Aquaq35;

public class Aquaq35 : AquaqPuzzle
{
    public override string Name => "Columns";

    protected override PuzzleResult Run()
    {
        var words = TextFile("Alphabet.txt").Split(Environment.NewLine);
        var input = InputFile;

        return PuzzleResult.Empty;
    }
}