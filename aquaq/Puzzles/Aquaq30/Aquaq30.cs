using Common.Puzzles;

namespace Aquaq.Puzzles.Aquaq30;

public class Aquaq30 : AquaqPuzzle
{
    public override string Name => "Flip Out";

    protected override PuzzleResult Run()
    {
        var cardFlipper = new CardFlipper();
        var decks = InputFile.Split(Environment.NewLine);
        var sum = decks.Sum(cardFlipper.CountValidStartingMoves);

        return new PuzzleResult(sum, "7cc5a75432e9a547200e3668c3761ae7");
    }
}