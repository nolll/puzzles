using Common.Puzzles;

namespace Aquaq.Puzzles.Aquaq30;

public class Aquaq30 : AquaqPuzzle
{
    public override string Name => "Flip Out";

    protected override PuzzleResult Run()
    {
        // guessed: 10613

        var cardFlipper = new CardFlipper();
        var decks = InputFile.Split(Environment.NewLine);
        var sum = 0;
        var count = 1;
        foreach (var deck in decks)
        {
            var result = cardFlipper.CountValidStartingMoves(deck);
            var possibleStartpoints = deck.Count(o => o == '1');
            Console.WriteLine();
            Console.WriteLine($"Deck {count}: {deck} {possibleStartpoints} {result}");
            sum += result;
            count++;
        }

        return new PuzzleResult(sum);
    }
}