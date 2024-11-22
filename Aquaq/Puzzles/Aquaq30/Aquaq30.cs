using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aquaq.Puzzles.Aquaq30;

[Name("Flip Out")]
public class Aquaq30(string input) : AquaqPuzzle
{
    protected override PuzzleResult Run()
    {
        var cardFlipper = new CardFlipper();
        var decks = StringReader.ReadLines(input);
        var sum = decks.Sum(cardFlipper.CountValidStartingMoves);

        return new PuzzleResult(sum, "a7ac2d6ffdd2d7759b9d51599832deae");
    }
}