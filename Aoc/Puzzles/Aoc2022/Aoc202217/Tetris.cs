using Puzzles.Common.CoordinateSystems.CoordinateSystem2D;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202217;

public class Tetris
{
    private static readonly TetrisShape[] Shapes = {
        TetrisShape.HorizontalLine,
        TetrisShape.Plus,
        TetrisShape.ReversedL,
        TetrisShape.VerticalLine,
        TetrisShape.Square
    };

    private const char Left = '<';
    private const char Right = '>';
    
    public long Part1(string input, long rockCount)
    {
        var heightDiffs = GetHeightDiffs(input, rockCount);
        return heightDiffs.Sum();
    }

    public long Run(string input, long rockCount)
    {
        var inputLength = input.Length;
        var rockCountUntilRepeat = inputLength * Shapes.Length;
        var heightDiffs = GetHeightDiffs(input, rockCountUntilRepeat).ToArray();
        var cycle = CycleFinder.FindRepeatCycle(heightDiffs, 50, inputLength / 2);

        var startCount = cycle.Index;
        var middleCount = cycle.Length;
        var startItems = heightDiffs.Take(startCount);
        var middleItems = heightDiffs.Skip(startCount).Take(middleCount);
        
        var multiplier = rockCount / cycle.Length-1;
        
        var endCount = Math.Abs(rockCount - startCount - middleCount * multiplier);
        var totalCount = startCount + middleCount * multiplier + endCount;
        if (totalCount > rockCount)
            endCount -= cycle.Length;
        var endItems = heightDiffs.Skip(startCount + middleCount).Take((int)endCount);

        var startSum = startItems.Sum();
        var middleSum = middleItems.Sum();
        var endSum = endItems.Sum();

        return startSum + multiplier * middleSum + endSum;
    }

    private static List<int> GetHeightDiffs(string input, long rockCount)
    {
        var moves = input.ToCharArray();
        var matrix = new Matrix<char>(7, 1, '.');
        long rockIndex = 0;
        var moveIndex = 0;
        var lastShapeTop = 0;
        var highestTop = 0;
        var heightDiffs = new List<int>();

        while (rockIndex < rockCount)
        {
            var shapeBottomLeft = new MatrixAddress(2, highestTop - 3);
            var shapeIndex = rockIndex % Shapes.Length;
            var shape = Shapes[shapeIndex];
            matrix.MoveTo(shapeBottomLeft);
            matrix.MoveUp(shape.Height);
            var movedDown = true;
            var heightBefore = highestTop;

            while (movedDown)
            {
                var move = moves[moveIndex % moves.Length];

                if (move == Left && shape.CanMoveLeft(matrix, shapeBottomLeft))
                    shapeBottomLeft = new MatrixAddress(shapeBottomLeft.X - 1, shapeBottomLeft.Y);
                else if (move == Right && shape.CanMoveRight(matrix, shapeBottomLeft))
                    shapeBottomLeft = new MatrixAddress(shapeBottomLeft.X + 1, shapeBottomLeft.Y);

                if (shape.CanMoveDown(matrix, shapeBottomLeft))
                    shapeBottomLeft = new MatrixAddress(shapeBottomLeft.X, shapeBottomLeft.Y + 1);
                else
                    movedDown = false;
                
                lastShapeTop = shapeBottomLeft.Y - shape.Height;
                moveIndex++;
            }

            highestTop = Math.Min(highestTop, lastShapeTop);
            var heightAdded = highestTop - heightBefore;
            heightDiffs.Add(Math.Abs(heightAdded));
            shape.Paint(matrix, shapeBottomLeft);
            rockIndex++;
        }

        return heightDiffs;
    }
}