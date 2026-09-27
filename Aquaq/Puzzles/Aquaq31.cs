using System.Text;
using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aquaq.Puzzles;

[Name("Brandless Combination Cubes")]
public class Aquaq31 : AquaqPuzzle
{
    [Puzzle("a5034749df5937c49bba3b06acc7119c")]
    public int Solve(string input)
    {
        var cube = new Cube();
        cube.Rotate(input);
        return cube.Front.Product;
    }

    public class CubeSolver(Cube cube)
    {
        public Cube Cube { get; } = cube;

        public void BringToFront(char color) => BringToFace(Cube.Front, color, FrontBackSearchRotations);
        public void BringToUp(char color) => BringToFace(Cube.Up, color, UpDownSearchRotations);
        public void BringToDown(char color) => BringToFace(Cube.Down, color, UpDownSearchRotations);

        private static readonly string[] FrontBackSearchRotations = ["X", "X", "X", "X", "XY", "YY"];
        private static readonly string[] UpDownSearchRotations = ["X", "X", "X", "X", "XZ", "ZZ"];

        private void BringToFace(CubeFace face, char color, string[] rotations)
        {
            foreach (var rotation in rotations)
            {
                if (face.Center == color)
                    return;

                Cube.Rotate(rotation);
            }
        }
    }

    public class Cube
    {
        public CubeFace Front { get; } = new(CubeColors.Blue);
        public CubeFace Up { get; } = new(CubeColors.White);
        public CubeFace Left { get; } = new(CubeColors.Red);
        public CubeFace Right { get; } = new(CubeColors.Orange);
        public CubeFace Down { get; } = new(CubeColors.Yellow);
        public CubeFace Back { get; } = new(CubeColors.Green);

        private readonly CubeFace[] _faces;

        public CubeFace BlueFace => _faces.First(o => o.Center == CubeColors.Blue);
        public CubeFace WhiteFace => _faces.First(o => o.Center == CubeColors.White);
        public CubeFace RedFace => _faces.First(o => o.Center == CubeColors.Red);
        public CubeFace OrangeFace => _faces.First(o => o.Center == CubeColors.Orange);
        public CubeFace YellowFace => _faces.First(o => o.Center == CubeColors.Yellow);
        public CubeFace GreenFace => _faces.First(o => o.Center == CubeColors.Green);

        public Cube()
        {
            _faces = [Front, Up, Left, Right, Down, Back];
        }

        public void Rotate(string instructions)
        {
            var rotations = ParseInstructions(instructions);
            foreach (var rotation in rotations)
            {
                var rotateFunc = GetRotateFunc(rotation);
                rotateFunc();
            }
        }

        private Action GetRotateFunc(string instruction) => instruction switch
        {
            CubeRotations.Front => RotateFront,
            CubeRotations.FrontPrime => RotateFrontPrime,
            CubeRotations.Up => RotateUp,
            CubeRotations.UpPrime => RotateUpPrime,
            CubeRotations.Left => RotateLeft,
            CubeRotations.LeftPrime => RotateLeftPrime,
            CubeRotations.Right => RotateRight,
            CubeRotations.RightPrime => RotateRightPrime,
            CubeRotations.Down => RotateDown,
            CubeRotations.DownPrime => RotateDownPrime,
            CubeRotations.Back => RotateBack,
            CubeRotations.BackPrime => RotateBackPrime,
            CubeRotations.CubeX => RotateX,
            CubeRotations.CubeXPrime => RotateXPrime,
            CubeRotations.CubeY => RotateY,
            CubeRotations.CubeYPrime => RotateYPrime,
            CubeRotations.CubeZ => RotateZ,
            CubeRotations.CubeZPrime => RotateZPrime,
            _ => throw new Exception("Unknown rotation")
        };

        public void RotateFront()
        {
            Front.RotateRight();
            var fromUp = Up.ReadBottomRow();
            var fromLeft = Left.ReadRightColumn();
            var fromRight = Right.ReadLeftColumn();
            var fromDown = Down.ReadTopRow();
            Up.WriteBottomRow(fromLeft.Reverse());
            Left.WriteRightColumn(fromDown);
            Right.WriteLeftColumn(fromUp);
            Down.WriteTopRow(fromRight.Reverse());
        }

        public void RotateFrontPrime()
        {
            Front.RotateLeft();
            var fromUp = Up.ReadBottomRow();
            var fromLeft = Left.ReadRightColumn();
            var fromRight = Right.ReadLeftColumn();
            var fromDown = Down.ReadTopRow();
            Up.WriteBottomRow(fromRight);
            Left.WriteRightColumn(fromUp.Reverse());
            Right.WriteLeftColumn(fromDown.Reverse());
            Down.WriteTopRow(fromLeft);
        }

        public void RotateUp()
        {
            Up.RotateRight();
            var fromFront = Front.ReadTopRow();
            var fromLeft = Left.ReadTopRow();
            var fromBack = Back.ReadTopRow();
            var fromRight = Right.ReadTopRow();
            Front.WriteTopRow(fromRight);
            Left.WriteTopRow(fromFront);
            Right.WriteTopRow(fromBack);
            Back.WriteTopRow(fromLeft);
        }

        public void RotateUpPrime()
        {
            Up.RotateLeft();
            var fromFront = Front.ReadTopRow();
            var fromLeft = Left.ReadTopRow();
            var fromBack = Back.ReadTopRow();
            var fromRight = Right.ReadTopRow();
            Front.WriteTopRow(fromLeft);
            Left.WriteTopRow(fromBack);
            Right.WriteTopRow(fromFront);
            Back.WriteTopRow(fromRight);
        }

        public void RotateLeft()
        {
            Left.RotateRight();
            var fromFront = Front.ReadLeftColumn();
            var fromUp = Up.ReadLeftColumn();
            var fromDown = Down.ReadLeftColumn();
            var fromBack = Back.ReadRightColumn();
            Front.WriteLeftColumn(fromUp);
            Up.WriteLeftColumn(fromBack.Reverse());
            Down.WriteLeftColumn(fromFront);
            Back.WriteRightColumn(fromDown.Reverse());
        }

        public void RotateLeftPrime()
        {
            Left.RotateLeft();
            var fromFront = Front.ReadLeftColumn();
            var fromUp = Up.ReadLeftColumn();
            var fromDown = Down.ReadLeftColumn();
            var fromBack = Back.ReadRightColumn();
            Front.WriteLeftColumn(fromDown);
            Up.WriteLeftColumn(fromFront);
            Down.WriteLeftColumn(fromBack.Reverse());
            Back.WriteRightColumn(fromUp.Reverse());
        }

        public void RotateRight()
        {
            Right.RotateRight();
            var fromFront = Front.ReadRightColumn();
            var fromUp = Up.ReadRightColumn();
            var fromDown = Down.ReadRightColumn();
            var fromBack = Back.ReadLeftColumn();
            Up.WriteRightColumn(fromFront);
            Front.WriteRightColumn(fromDown);
            Down.WriteRightColumn(fromBack.Reverse());
            Back.WriteLeftColumn(fromUp.Reverse());
        }

        public void RotateRightPrime()
        {
            Right.RotateLeft();
            var fromFront = Front.ReadRightColumn();
            var fromUp = Up.ReadRightColumn();
            var fromDown = Down.ReadRightColumn();
            var fromBack = Back.ReadLeftColumn();
            Front.WriteRightColumn(fromUp);
            Up.WriteRightColumn(fromBack.Reverse());
            Down.WriteRightColumn(fromFront);
            Back.WriteLeftColumn(fromDown.Reverse());
        }

        public void RotateDown()
        {
            Down.RotateRight();
            var fromFront = Front.ReadBottomRow();
            var fromLeft = Left.ReadBottomRow();
            var fromRight = Right.ReadBottomRow();
            var fromBack = Back.ReadBottomRow();
            Front.WriteBottomRow(fromLeft);
            Left.WriteBottomRow(fromBack);
            Right.WriteBottomRow(fromFront);
            Back.WriteBottomRow(fromRight);
        }

        public void RotateDownPrime()
        {
            Down.RotateLeft();
            var fromFront = Front.ReadBottomRow();
            var fromLeft = Left.ReadBottomRow();
            var fromRight = Right.ReadBottomRow();
            var fromBack = Back.ReadBottomRow();
            Front.WriteBottomRow(fromRight);
            Left.WriteBottomRow(fromFront);
            Right.WriteBottomRow(fromBack);
            Back.WriteBottomRow(fromLeft);
        }

        public void RotateBack()
        {
            Back.RotateRight();
            var fromUp = Up.ReadTopRow();
            var fromLeft = Left.ReadLeftColumn();
            var fromDown = Down.ReadBottomRow();
            var fromRight = Right.ReadRightColumn();
            Left.WriteLeftColumn(fromUp.Reverse());
            Down.WriteBottomRow(fromLeft);
            Right.WriteRightColumn(fromDown.Reverse());
            Up.WriteTopRow(fromRight);
        }

        public void RotateBackPrime()
        {
            Back.RotateLeft();
            var fromUp = Up.ReadTopRow();
            var fromLeft = Left.ReadLeftColumn();
            var fromDown = Down.ReadBottomRow();
            var fromRight = Right.ReadRightColumn();
            Left.WriteLeftColumn(fromDown);
            Down.WriteBottomRow(fromRight.Reverse());
            Right.WriteRightColumn(fromUp);
            Up.WriteTopRow(fromLeft.Reverse());
        }

        public void RotateX()
        {
            Left.RotateLeft();
            Right.RotateRight();
            var front = Front.ReadAll();
            var up = Up.ReadAll();
            var back = Back.ReadAll();
            var down = Down.ReadAll();
            Front.WriteAll(down);
            Up.WriteAll(front);
            Down.WriteAll(back);
            Down.RotateLeft();
            Down.RotateLeft();
            Back.WriteAll(up);
            Back.RotateLeft();
            Back.RotateLeft();
        }

        public void RotateXPrime()
        {
            Left.RotateRight();
            Right.RotateLeft();
            var front = Front.ReadAll();
            var up = Up.ReadAll();
            var back = Back.ReadAll();
            var down = Down.ReadAll();
            Front.WriteAll(up);
            Up.WriteAll(back);
            Up.RotateLeft();
            Up.RotateLeft();
            Down.WriteAll(front);
            Back.WriteAll(down);
            Back.RotateLeft();
            Back.RotateLeft();
        }

        public void RotateY()
        {
            Up.RotateRight();
            Down.RotateLeft();
            var front = Front.ReadAll();
            var left = Left.ReadAll();
            var right = Right.ReadAll();
            var back = Back.ReadAll();
            Front.WriteAll(right);
            Left.WriteAll(front);
            Right.WriteAll(back);
            Back.WriteAll(left);
        }

        public void RotateYPrime()
        {
            Up.RotateLeft();
            Down.RotateRight();
            var front = Front.ReadAll();
            var left = Left.ReadAll();
            var right = Right.ReadAll();
            var back = Back.ReadAll();
            Front.WriteAll(left);
            Left.WriteAll(back);
            Right.WriteAll(front);
            Back.WriteAll(right);
        }

        public void RotateZ()
        {
            Back.RotateLeft();
            Front.RotateRight();
            var left = Left.ReadAll();
            var up = Up.ReadAll();
            var right = Right.ReadAll();
            var down = Down.ReadAll();
            Up.WriteAll(left);
            Up.RotateRight();
            Left.WriteAll(down);
            Left.RotateRight();
            Right.WriteAll(up);
            Right.RotateRight();
            Down.WriteAll(right);
            Down.RotateRight();
        }

        public void RotateZPrime()
        {
            Back.RotateRight();
            Front.RotateLeft();
            var left = Left.ReadAll();
            var up = Up.ReadAll();
            var right = Right.ReadAll();
            var down = Down.ReadAll();
            Up.WriteAll(right);
            Up.RotateLeft();
            Left.WriteAll(up);
            Left.RotateLeft();
            Right.WriteAll(down);
            Right.RotateLeft();
            Down.WriteAll(left);
            Down.RotateLeft();
        }

        public string PrintFlat()
        {
            var s = new StringBuilder();
            s.AppendLine(Front.PrintFlat());
            s.AppendLine(Up.PrintFlat());
            s.AppendLine(Left.PrintFlat());
            s.AppendLine(Right.PrintFlat());
            s.AppendLine(Down.PrintFlat());
            s.AppendLine(Back.PrintFlat());

            return s.ToString().Trim();
        }

        public string Print3d()
        {
            var pm = new Grid<char>(9, 12, '.');
            var frontGrid = Front.Grid;
            var upGrid = Up.Grid;
            var leftGrid = Left.Grid;
            var rightGrid = Right.Grid;
            var downGrid = Down.Grid;
            var backGrid = Back.Grid.RotateLeft().RotateLeft();

            ApplyToPrintGrid(pm, upGrid, new Coord(3, 0));
            ApplyToPrintGrid(pm, leftGrid, new Coord(0, 3));
            ApplyToPrintGrid(pm, frontGrid, new Coord(3, 3));
            ApplyToPrintGrid(pm, rightGrid, new Coord(6, 3));
            ApplyToPrintGrid(pm, downGrid, new Coord(3, 6));
            ApplyToPrintGrid(pm, backGrid, new Coord(3, 9));

            return pm.Print();
        }

        /// <summary>
        /// Prints front, up, left, right, down, back
        /// </summary>
        public string Print()
        {
            var pm = new Grid<char>(23, 3, ' ');
            var frontGrid = Front.Grid;
            var upGrid = Up.Grid;
            var leftGrid = Left.Grid;
            var rightGrid = Right.Grid;
            var downGrid = Down.Grid;
            var backGrid = Back.Grid;

            ApplyToPrintGrid(pm, frontGrid, new Coord(0, 0));
            ApplyToPrintGrid(pm, upGrid, new Coord(4, 0));
            ApplyToPrintGrid(pm, leftGrid, new Coord(8, 0));
            ApplyToPrintGrid(pm, rightGrid, new Coord(12, 0));
            ApplyToPrintGrid(pm, downGrid, new Coord(16, 0));
            ApplyToPrintGrid(pm, backGrid, new Coord(20, 0));

            return pm.Print();
        }

        private void ApplyToPrintGrid(Grid<char> printGrid, Grid<char> faceGrid, Coord startAddress)
        {
            foreach (var coord in faceGrid.Coords)
            {
                printGrid.WriteValueAt(startAddress.X + coord.X, startAddress.Y + coord.Y, faceGrid.ReadValueAt(coord));
            }
        }

        public void Scramble(int rotationsCount = 100)
        {
            var rotations = CubeRotations.Random(rotationsCount);
            foreach (var rotation in rotations)
            {
                Rotate(rotation);
            }
        }

        private static IEnumerable<string> ParseInstructions(string s)
        {
            var instructions = new List<string>();
            foreach (var c in s)
            {
                if (c == '\'')
                    instructions[^1] += c;
                else
                    instructions.Add(c.ToString());
            }

            return instructions;
        }
    }
    
    public static class CubeColors
    {
        public const char Blue = 'b';
        public const char White = 'w';
        public const char Red = 'r';
        public const char Orange = 'o';
        public const char Yellow = 'y';
        public const char Green = 'g';
    }

    public class CubeFace
    {
        private const int Size = 3;
        private Grid<char> _grid;

        public CubeFace(char initial)
        {
            _grid = new(Size, Size, initial);
        }

        public char TopLeft => _grid.ReadValueAt(0, 0);
        public char Top => _grid.ReadValueAt(1, 0);
        public char TopRight => _grid.ReadValueAt(2, 0);
        public char Left => _grid.ReadValueAt(1, 0);
        public char Center => _grid.ReadValueAt(1, 1);
        public char Right => _grid.ReadValueAt(1, 2);
        public char BottomLeft => _grid.ReadValueAt(0, 2);
        public char Bottom => _grid.ReadValueAt(1, 2);
        public char BottomRight => _grid.ReadValueAt(2, 2);

        public char[] ReadAll() => _grid.Values.ToArray();
        public char[] ReadLeftColumn() => ReadColumn(0);
        public char[] ReadRightColumn() => ReadColumn(2);
        private char[] ReadColumn(int x) => Enumerable.Range(0, Size).Select(o => _grid.ReadValueAt(x, o)).ToArray();

        public char[] ReadTopRow() => ReadRow(0);
        public char[] ReadBottomRow() => ReadRow(2);
        private char[] ReadRow(int y) => Enumerable.Range(0, Size).Select(o => _grid.ReadValueAt(o, y)).ToArray();

        public Grid<char> Grid => _grid.Clone();

        public void WriteAll(IEnumerable<char> chars)
        {
            var charArray = chars.ToArray();
            var coordsArray = _grid.Coords.ToArray();
            for (var i = 0; i < coordsArray.Length; i++)
            {
                _grid.WriteValueAt(coordsArray[i], charArray[i]);
            }
        }

        public void WriteTopRow(IEnumerable<char> values) => WriteRow(0, values);
        public void WriteBottomRow(IEnumerable<char> values) => WriteRow(2, values);

        private void WriteRow(int y, IEnumerable<char> values)
        {
            var x = 0;
            foreach (var value in values)
            {
                _grid.WriteValueAt(x, y, value);
                x++;
            }
        }

        public void WriteLeftColumn(IEnumerable<char> values) => WriteColumn(0, values);
        public void WriteRightColumn(IEnumerable<char> values) => WriteColumn(2, values);

        private void WriteColumn(int x, IEnumerable<char> values)
        {
            var y = 0;
            foreach (var value in values)
            {
                _grid.WriteValueAt(x, y, value);
                y++;
            }
        }

        public void RotateRight() => _grid = _grid.RotateRight();
        public void RotateLeft() => _grid = _grid.RotateLeft();
        public string PrintFlat() => string.Join("", _grid.Values);
        public string Print() => _grid.Print();
        public int Product => _grid.Values.Select(GetColorValue).Aggregate(1, (a, b) => a * b);

        private static int GetColorValue(char c) => c switch
        {
            CubeColors.Blue => 1,
            CubeColors.White => 2,
            CubeColors.Red => 3,
            CubeColors.Orange => 4,
            CubeColors.Yellow => 5,
            CubeColors.Green => 6,
            _ => throw new Exception("Unknown color")
        };
    }
    
    public static class CubeRotations
    {
        public const string Front = "F";
        public const string FrontPrime = "F'";
        public const string Up = "U";
        public const string UpPrime = "U'";
        public const string Left = "L";
        public const string LeftPrime = "L'";
        public const string Right = "R";
        public const string RightPrime = "R'";
        public const string Down = "D";
        public const string DownPrime = "D'";
        public const string Back = "B";
        public const string BackPrime = "B'";
        public const string CubeX = "X";
        public const string CubeXPrime = "X'";
        public const string CubeY = "Y";
        public const string CubeYPrime = "Y'";
        public const string CubeZ = "Z";
        public const string CubeZPrime = "Z'";

        private static readonly string[] All = [
            Front,
            FrontPrime,
            Up,
            UpPrime,
            Left,
            LeftPrime,
            Right,
            RightPrime,
            Down,
            DownPrime,
            Back,
            BackPrime,
            CubeX,
            CubeXPrime,
            CubeY,
            CubeYPrime,
            CubeZ,
            CubeZPrime
        ];

        public static string[] Random(int count)
        {
            var rnd = new Random((int)DateTime.Now.Ticks);
            var rotations = new List<string>();
            for (var i = 0; i < count; i++)
            {
                rotations.Add(All[rnd.Next(All.Length - 1)]);
            }

            return rotations.ToArray();
        }
    }
}