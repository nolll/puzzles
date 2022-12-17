using System;
using System.Collections.Generic;
using System.Linq;
using Core.Common.CoordinateSystems.CoordinateSystem2D;
using Core.Puzzles.Year2022.Day02;

namespace Core.Puzzles.Year2022.Day17;

public class Tetris
{
    private const char Left = '<';
    private const char Right = '>';
    private const string ShapeData = """
####

.#.
###
.#.

..#
..#
###

#
#
#
#

##
##
""";

    //private TetrisShape ParseShape(IList<string> lines)
    //{
    //    if (lines.Count == 1)
    //        return TetrisShape.HorizontalLine;
    //    if (lines.Count == 2)
    //        return TetrisShape.Plus;
    //    if (lines.Count == 4)
    //        return TetrisShape.VerticalLine;
    //    if (lines.Count == 3 && lines[1] == "###")
    //        return TetrisShape.Plus;
    //    return TetrisShape.ReversedL;
    //}

    public long Run(string input, long rockCount)
    {
        var shapes = new[]
        {
            TetrisShape.HorizontalLine,
            TetrisShape.Plus,
            TetrisShape.ReversedL,
            TetrisShape.VerticalLine,
            TetrisShape.Square
        };

        var moves = input.ToCharArray();
        var matrix = new QuickDynamicMatrix<char>(7, 1, '.');
        long rockIndex = 0;
        var moveIndex = 0;
        var lastTopPos = 0;
        var highestTop = 0;

        long multiplier = 0;
        long repeatHeight = 0;
        var seen = new Dictionary<string, (long repeatIndex, int repeatHeight)>();
        var heightsAdded = new List<long>();

        while (rockIndex < rockCount)
        {
            var shapeBottomLeft = new MatrixAddress(2, highestTop - 3);
            var shapeIndex = rockIndex % shapes.Length;
            var shape = shapes[shapeIndex];
            matrix.MoveTo(shapeBottomLeft);
            matrix.MoveUp(shape.Height);
            var movedDown = true;
            var heightBefore = highestTop;

            while (movedDown)
            {
                var move = moves[moveIndex % moves.Length];

                if (move == Left)
                {
                    if (shape.CanMoveLeft(matrix, shapeBottomLeft))
                    {
                        shapeBottomLeft = new MatrixAddress(shapeBottomLeft.X - 1, shapeBottomLeft.Y);
                    }
                }
                else
                {
                    if (shape.CanMoveRight(matrix, shapeBottomLeft))
                    {
                        shapeBottomLeft = new MatrixAddress(shapeBottomLeft.X + 1, shapeBottomLeft.Y);
                    }
                }

                if (shape.CanMoveDown(matrix, shapeBottomLeft))
                {
                    shapeBottomLeft = new MatrixAddress(shapeBottomLeft.X, shapeBottomLeft.Y + 1);
                }
                else
                {
                    movedDown = false;
                }
                
                lastTopPos = shapeBottomLeft.Y - shape.Height;
                moveIndex++;
            }

            highestTop = Math.Min(highestTop, lastTopPos);

            var heightAdded = highestTop - heightBefore;
            heightsAdded.Add(heightAdded);

            shape.Paint(matrix, shapeBottomLeft);

            var cacheKey = GetCacheKey(shape.GetType(), moveIndex % moves.Length, shapeBottomLeft.X);
            if (seen.TryGetValue(cacheKey, out var tuple) && multiplier == 0)
            {
                var repeatLength = rockIndex - tuple.repeatIndex;
                long added = 0;
                var ii = 0;
                for (var i = (int)tuple.repeatIndex; i < rockIndex; i++)
                {
                    ii = i;
                    added += Math.Abs(heightsAdded[i]);
                }
                
                repeatHeight = added;//matrix.YMax - highestTop - tuple.repeatHeight;
                multiplier = rockCount / repeatLength;
                rockIndex = multiplier * repeatLength;

                var offset = rockCount - rockIndex;
                long theRest = 0;
                for (var i = ii; i < ii + offset + 2; i++)
                {
                    theRest += Math.Abs(heightsAdded[i % heightsAdded.Count]);
                }

                return added * multiplier + theRest - 1;
            }
            else
            {
                seen.TryAdd(cacheKey, (rockIndex, matrix.YMax - highestTop));
            }

            rockIndex++;
        }

        var result = matrix.YMax - highestTop;
        
        return result + multiplier * repeatHeight;
    }

    private string PrintTempMatrix(IMatrix<char> matrix, TetrisShape shape, MatrixAddress bottomLeft)
    {
        var copy = matrix.Copy();
        shape.Paint(copy, bottomLeft);
        return copy.Print();
    }

    private string GetCacheKey(Type type, int moveIndex, int x)
    {
        return $"{type.Name}|{moveIndex}|{x}";
    }
}