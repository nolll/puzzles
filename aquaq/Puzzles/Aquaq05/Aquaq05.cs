using Common.Puzzles;

namespace Aquaq.Puzzles.Aquaq05;

public class Aquaq05 : AquaqPuzzle
{
    public override string Name => "Snake eyes";

    protected override PuzzleResult Run()
    {
        var sum = FindSumOfIndexesWithMatchingDice(InputFile);

        return new PuzzleResult(sum, "dacb283d1182b49af03528f6f02eccd7");
    }

    public static int FindSumOfIndexesWithMatchingDice(string input)
    {
        var dices = new Dice[] { new(1, 2, 3), new(1, 3, 2) };
        var rotations = input.ToCharArray();
        var sum = 0;

        for (var i = 0; i < rotations.Length; i++)
        {
            var rotation = rotations[i];
            switch (rotation)
            {
                case 'U':
                {
                    foreach (var dice in dices)
                    {
                        dice.RotateUp();
                    }

                    break;
                }
                case 'R':
                {
                    foreach (var dice in dices)
                    {
                        dice.RotateRight();
                    }

                    break;
                }
                case 'D':
                {
                    foreach (var dice in dices)
                    {
                        dice.RotateDown();
                    }

                    break;
                }
                case 'L':
                {
                    foreach (var dice in dices)
                    {
                        dice.RotateLeft();
                    }

                    break;
                }
            }

            if (dices[0].Front == dices[1].Front)
                sum += i;
        }

        return sum;
    }
}