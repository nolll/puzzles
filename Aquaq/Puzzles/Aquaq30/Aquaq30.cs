using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aquaq.Puzzles.Aquaq30;

[Name("Flip Out")]
public class Aquaq30 : AquaqPuzzle
{
    [Puzzle("a7ac2d6ffdd2d7759b9d51599832deae")]
    public PuzzleResult Solve(string input)
    {
        var cardFlipper = new CardFlipper();
        var decks = input.Split(LineBreaks.Single);
        var sum = decks.Sum(cardFlipper.CountValidStartingMoves);

        return new PuzzleResult(sum);
    }
}