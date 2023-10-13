using Common.Puzzles;

namespace Aquaq.Puzzles.Aquaq30;

public class Aquaq30 : AquaqPuzzle
{
    public override string Name => "Flip Out";

    protected override PuzzleResult Run()
    {
        var decks = InputFile.Split(Environment.NewLine);
        var result = decks.Sum(CountValidStartingMoves);

        return new PuzzleResult(result);
    }

    public static int CountValidStartingMoves(string input)
    {
        Console.WriteLine();
        Console.WriteLine(input);
        var count = 0;
        var cardFlipper = new CardFlipper();
        for (var i = 0; i < input.Length; i++)
        {
            if (input[i] == '1')
            {
                var flipped = cardFlipper.Flip(input, i);
                var canBeSolved = cardFlipper.CanBeSolved(flipped.ToCharArray());
                if (canBeSolved)
                    count++;
            }
        }

        return count;
    }
}