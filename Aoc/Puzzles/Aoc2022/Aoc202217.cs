using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2022;

[Name("Pyroclastic Flow")]
public class Aoc202217 : AocPuzzle
{
    [Puzzle("cdc90a19ac724ffd4fa126a641706d13")]
    public long Part1(string input) => new Tetris().Run(input, 2022);

    [Puzzle("3a90eb3ba5f3fc471fa832e199a1b7f9")]
    public long Part2(string input) => new Tetris().Run(input, 1_000_000_000_000);

    public class Tetris
    {
        private static readonly TetrisShape[] Shapes =
        {
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

            var multiplier = rockCount / cycle.Length - 1;

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
            var grid = new Grid<char>(7, 1, '.');
            long rockIndex = 0;
            var moveIndex = 0;
            var lastShapeTop = 0;
            var highestTop = 0;
            var heightDiffs = new List<int>();

            while (rockIndex < rockCount)
            {
                var shapeBottomLeft = new Coord(2, highestTop - 3);
                var shapeIndex = rockIndex % Shapes.Length;
                var shape = Shapes[shapeIndex];
                grid.MoveTo(shapeBottomLeft);
                grid.MoveUp(shape.Height);
                var movedDown = true;
                var heightBefore = highestTop;

                while (movedDown)
                {
                    var move = moves[moveIndex % moves.Length];

                    if (move == Left && shape.CanMoveLeft(grid, shapeBottomLeft))
                        shapeBottomLeft = new Coord(shapeBottomLeft.X - 1, shapeBottomLeft.Y);
                    else if (move == Right && shape.CanMoveRight(grid, shapeBottomLeft))
                        shapeBottomLeft = new Coord(shapeBottomLeft.X + 1, shapeBottomLeft.Y);

                    if (shape.CanMoveDown(grid, shapeBottomLeft))
                        shapeBottomLeft = new Coord(shapeBottomLeft.X, shapeBottomLeft.Y + 1);
                    else
                        movedDown = false;

                    lastShapeTop = shapeBottomLeft.Y - shape.Height;
                    moveIndex++;
                }

                highestTop = Math.Min(highestTop, lastShapeTop);
                var heightAdded = highestTop - heightBefore;
                heightDiffs.Add(Math.Abs(heightAdded));
                shape.Paint(grid, shapeBottomLeft);
                rockIndex++;
            }

            return heightDiffs;
        }
    }
    
    public static class CycleFinder
    {
        public static RepeatCycle FindRepeatCycle(int[] numbers, int minLength = 0, int startSearchAt = 0)
        {
            var searchList = numbers.Skip(startSearchAt).ToArray();
            var repeatList = FindRepeatSequence(searchList, minLength);
            var repeatStart = FindCycleStart(numbers, repeatList);
            return repeatList.Length > 0
                ? new RepeatCycle(repeatStart, repeatList.Length) 
                : new RepeatCycle(0, 0);
        }

        private static int FindCycleStart(int[] numbers, int[] repeatList)
        {
            for (var i = 0; i < numbers.Length; i++)
            {
                var length = repeatList.Length;
                var compareList = numbers.Skip(i).Take(length);
                if (repeatList.SequenceEqual(compareList))
                    return i;
            }

            return 0;
        }

        private static int[] FindRepeatSequence(int[] numbers, int minLength = 0)
        {
            var repeatList = Array.Empty<int>();

            for (var length = minLength; length < numbers.Length; length++)
            {
                var list1 = numbers.Take(length);
                var list2 = numbers.Skip(length).Take(length);
                if (list1.SequenceEqual(list2))
                {
                    repeatList = list1.ToArray();
                    break;
                }
            }

            return repeatList;
        }
    }
    
    public class HorizontalLineShape : TetrisShape
    {
        private readonly Coord[] _shape = {
            new(0, 0),
            new(1, 0),
            new(2, 0),
            new(3, 0)
        };

        private readonly Coord[] _left = {
            new(-1, 0)
        };

        private readonly Coord[] _right =
        {
            new(4, 0)
        };

        private readonly Coord[] _down =
        {
            new(0, 1),
            new(1, 1),
            new(2, 1),
            new(3, 1)
        };

        public HorizontalLineShape() : base(4, 1)
        {
        }

        public override bool CanMoveLeft(Grid<char> grid, Coord bottomLeft)
        {
            return CheckCoords(grid, bottomLeft, _left);
        }

        public override bool CanMoveRight(Grid<char> grid, Coord bottomLeft)
        {
            return CheckCoords(grid, bottomLeft, _right);
        }

        public override bool CanMoveDown(Grid<char> grid, Coord bottomLeft)
        {
            return CheckCoords(grid, bottomLeft, _down);
        }

        public override void Paint(Grid<char> grid, Coord bottomLeft)
        {
            Paint(grid, bottomLeft, _shape);
        }
    }
    
    public class PlusShape : TetrisShape
    {
        private readonly Coord[] _shape = {
            new(1, 0),
            new(1, -1),
            new(1, -2),
            new(0, -1),
            new(2, -1)
        };

        private readonly Coord[] _left = {
            new(0, -2),
            new(-1, -1),
            new(0, 0)
        };

        private readonly Coord[] _right =
        {
            new(2, -2),
            new(3, -1),
            new(2, 0)
        };

        private readonly Coord[] _down =
        {
            new(0, 0),
            new(1, 1),
            new(2, 0)
        };

        public PlusShape() : base(3, 3)
        {
        }

        public override bool CanMoveLeft(Grid<char> grid, Coord bottomLeft)
        {
            return CheckCoords(grid, bottomLeft, _left);
        }

        public override bool CanMoveRight(Grid<char> grid, Coord bottomLeft)
        {
            return CheckCoords(grid, bottomLeft, _right);
        }

        public override bool CanMoveDown(Grid<char> grid, Coord bottomLeft)
        {
            return CheckCoords(grid, bottomLeft, _down);
        }

        public override void Paint(Grid<char> grid, Coord bottomLeft)
        {
            Paint(grid, bottomLeft, _shape);
        }
    }
    
    public class RepeatCycle
    {
        public int Index { get; }
        public int Length { get; }

        public RepeatCycle(int index, int length)
        {
            Index = index;
            Length = length;
        }
    }
    
    public class ReversedLShape : TetrisShape
    {
        private readonly Coord[] _shape = {
            new(0, 0),
            new(1, 0),
            new(2, 0),
            new(2, -1),
            new(2, -2)
        };

        private readonly Coord[] _left = {
            new(-1, 0),
            new(1, -1),
            new(1, -2)
        };

        private readonly Coord[] _right =
        {
            new(3, 0),
            new(3, -1),
            new(3, -2)
        };

        private readonly Coord[] _down =
        {
            new(0, 1),
            new(1, 1),
            new(2, 1),
        };

        public ReversedLShape() : base(3, 3)
        {
        }

        public override bool CanMoveLeft(Grid<char> grid, Coord bottomLeft)
        {
            return CheckCoords(grid, bottomLeft, _left);
        }

        public override bool CanMoveRight(Grid<char> grid, Coord bottomLeft)
        {
            return CheckCoords(grid, bottomLeft, _right);
        }

        public override bool CanMoveDown(Grid<char> grid, Coord bottomLeft)
        {
            return CheckCoords(grid, bottomLeft, _down);
        }

        public override void Paint(Grid<char> grid, Coord bottomLeft)
        {
            Paint(grid, bottomLeft, _shape);
        }
    }
    
    public class SquareShape : TetrisShape
    {
        private readonly Coord[] _shape = {
            new(0, 0),
            new(0, -1),
            new(1, 0),
            new(1, -1)
        };

        private readonly Coord[] _left = {
            new(-1, 0),
            new(-1, -1)
        };

        private readonly Coord[] _right =
        {
            new(2, 0),
            new(2, -1)
        };

        private readonly Coord[] _down =
        {
            new(0, 1),
            new(1, 1)
        };

        public SquareShape() : base(2, 2)
        {
        }

        public override bool CanMoveLeft(Grid<char> grid, Coord bottomLeft)
        {
            return CheckCoords(grid, bottomLeft, _left);
        }

        public override bool CanMoveRight(Grid<char> grid, Coord bottomLeft)
        {
            return CheckCoords(grid, bottomLeft, _right);
        }

        public override bool CanMoveDown(Grid<char> grid, Coord bottomLeft)
        {
            return CheckCoords(grid, bottomLeft, _down);
        }

        public override void Paint(Grid<char> grid, Coord bottomLeft)
        {
            Paint(grid, bottomLeft, _shape);
        }
    }
    
    public abstract class TetrisShape
    {
        public int Width { get; }
        public int Height { get; }

        protected TetrisShape(int width, int height)
        {
            Width = width;
            Height = height;
        }

        private static IEnumerable<Coord> TranslateCoords(Coord baseCoord, IEnumerable<Coord> deltas)
        {
            return deltas.Select(o => new Coord(baseCoord.X + o.X, baseCoord.Y + o.Y));
        }

        protected static bool CheckCoords(Grid<char> grid, Coord bottomLeft, IEnumerable<Coord> deltas)
        {
            var coords = deltas.Select(o => new Coord(bottomLeft.X + o.X, bottomLeft.Y + o.Y));
            return coords.All(o => !grid.IsOutOfRange(o) && grid.ReadValueAt(o) == '.');
        }

        public abstract bool CanMoveLeft(Grid<char> grid, Coord bottomLeft);
        public abstract bool CanMoveRight(Grid<char> grid, Coord bottomLeft);
        public abstract bool CanMoveDown(Grid<char> grid, Coord bottomLeft);
        public abstract void Paint(Grid<char> grid, Coord bottomLeft);

        protected static void Paint(Grid<char> grid, Coord bottomLeft, IEnumerable<Coord> deltas)
        {
            var coords = TranslateCoords(bottomLeft, deltas);
            foreach (var coord in coords)
            {
                grid.WriteValueAt(coord, '#');
            }
        }

        public static readonly TetrisShape VerticalLine = new VerticalLineShape();
        public static readonly TetrisShape Plus = new PlusShape();
        public static readonly TetrisShape ReversedL = new ReversedLShape();
        public static readonly TetrisShape HorizontalLine = new HorizontalLineShape();
        public static readonly TetrisShape Square = new SquareShape();
    }
    
    public class VerticalLineShape : TetrisShape
    {
        private readonly Coord[] _shape = {
            new(0, 0),
            new(0, -1),
            new(0, -2),
            new(0, -3)
        };

        private readonly Coord[] _left = {
            new(-1, 0),
            new(-1, -1),
            new(-1, -2),
            new(-1, -3)
        };

        private readonly Coord[] _right =
        {
            new(1, 0),
            new(1, -1),
            new(1, -2),
            new(1, -3)
        };

        private readonly Coord[] _down =
        {
            new(0, 1)
        };

        public VerticalLineShape() : base(1, 4)
        {
        }

        public override bool CanMoveLeft(Grid<char> grid, Coord bottomLeft)
        {
            return CheckCoords(grid, bottomLeft, _left);
        }

        public override bool CanMoveRight(Grid<char> grid, Coord bottomLeft)
        {
            return CheckCoords(grid, bottomLeft, _right);
        }

        public override bool CanMoveDown(Grid<char> grid, Coord bottomLeft)
        {
            return CheckCoords(grid, bottomLeft, _down);
        }

        public override void Paint(Grid<char> grid, Coord bottomLeft)
        {
            Paint(grid, bottomLeft, _shape);
        }
    }
}   