using System.Text;
using Pzl.Tools.CoordinateSystems.CoordinateSystem2D;

namespace Pzl.Aquaq.Puzzles.Aquaq31.RubiksCube;

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
        var pm = new Matrix<char>(9, 12, '.');
        var frontMatrix = Front.Matrix;
        var upMatrix = Up.Matrix;
        var leftMatrix = Left.Matrix;
        var rightMatrix = Right.Matrix;
        var downMatrix = Down.Matrix;
        var backMatrix = Back.Matrix.RotateLeft().RotateLeft();

        ApplyToPrintMatrix(pm, upMatrix, new MatrixAddress(3, 0));
        ApplyToPrintMatrix(pm, leftMatrix, new MatrixAddress(0, 3));
        ApplyToPrintMatrix(pm, frontMatrix, new MatrixAddress(3, 3));
        ApplyToPrintMatrix(pm, rightMatrix, new MatrixAddress(6, 3));
        ApplyToPrintMatrix(pm, downMatrix, new MatrixAddress(3, 6));
        ApplyToPrintMatrix(pm, backMatrix, new MatrixAddress(3, 9));

        return pm.Print();
    }

    /// <summary>
    /// Prints front, up, left, right, down, back
    /// </summary>
    public string Print()
    {
        var pm = new Matrix<char>(23, 3, ' ');
        var frontMatrix = Front.Matrix;
        var upMatrix = Up.Matrix;
        var leftMatrix = Left.Matrix;
        var rightMatrix = Right.Matrix;
        var downMatrix = Down.Matrix;
        var backMatrix = Back.Matrix;

        ApplyToPrintMatrix(pm, frontMatrix, new MatrixAddress(0, 0));
        ApplyToPrintMatrix(pm, upMatrix, new MatrixAddress(4, 0));
        ApplyToPrintMatrix(pm, leftMatrix, new MatrixAddress(8, 0));
        ApplyToPrintMatrix(pm, rightMatrix, new MatrixAddress(12, 0));
        ApplyToPrintMatrix(pm, downMatrix, new MatrixAddress(16, 0));
        ApplyToPrintMatrix(pm, backMatrix, new MatrixAddress(20, 0));

        return pm.Print();
    }

    private void ApplyToPrintMatrix(Matrix<char> printMatrix, Matrix<char> faceMatrix, MatrixAddress startAddress)
    {
        foreach (var coord in faceMatrix.Coords)
        {
            printMatrix.WriteValueAt(startAddress.X + coord.X, startAddress.Y + coord.Y, faceMatrix.ReadValueAt(coord));
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