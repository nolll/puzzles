using Pzl.Tools.Puzzles;
using Pzl.Tools.Strings;

namespace Pzl.Aquaq.Puzzles.Aquaq30;

public class Aquaq30 : AquaqPuzzle
{
    public override string Name => "Flip Out";

    protected override PuzzleResult Run()
    {
        var cardFlipper = new CardFlipper();
        var decks = StringReader.ReadLines(InputFile);
        var sum = decks.Sum(cardFlipper.CountValidStartingMoves);

        return new PuzzleResult(sum, "a7ac2d6ffdd2d7759b9d51599832deae");
    }
}