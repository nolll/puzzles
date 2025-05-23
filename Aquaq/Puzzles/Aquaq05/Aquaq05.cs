using Pzl.Common;

namespace Pzl.Aquaq.Puzzles.Aquaq05;

[Name("Snake eyes")]
public class Aquaq05 : AquaqPuzzle
{
    public PuzzleResult Run(string input)
    {
        var sum = FindSumOfIndexesWithMatchingDice(input);

        return new PuzzleResult(sum, "618a2293fcd6600e06eb2d002758bd97");
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