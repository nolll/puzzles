namespace Pzl.Aquaq.Puzzles.Aquaq31;

public class RubiksCube
{
    public RubiksCubeFace Front { get; } = CreateFace('b');
    public RubiksCubeFace Up { get; } = CreateFace('w');
    public RubiksCubeFace Left { get; } = CreateFace('r');
    public RubiksCubeFace Right { get; } = CreateFace('o');
    public RubiksCubeFace Down { get; } = CreateFace('y');
    public RubiksCubeFace Back { get; } = CreateFace('g');

    public void Rotate(string instruction)
    {
        var rotateFunc = GetRotateFunc(instruction);
        rotateFunc();
    }

    private Action GetRotateFunc(string instruction) => instruction switch
    {
        "F" => RotateFront,
        "F'" => RotateFrontPrime,
        "U" => RotateUp,
        "U'" => RotateUpPrime,
        "L" => RotateLeft,
        "L'" => RotateLeftPrime,
        "R" => RotateRight,
        "R'" => RotateRightPrime,
        "D" => RotateDown,
        "D'" => RotateDownPrime,
        "B" => RotateBack,
        "B'" => RotateBackPrime,
        "X" => RotateCubeX,
        "X'" => RotateCubeXPrime,
        "Y" => RotateCubeY,
        "Y'" => RotateCubeYPrime,
        "Z" => RotateCubeZ,
        "Z'" => RotateCubeZPrime,
        _ => throw new Exception("Unknown rotation")
    };

    private void RotateFront()
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

    private void RotateFrontPrime()
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

    private void RotateUp()
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

    private void RotateUpPrime()
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

    private void RotateLeft()
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

    private void RotateLeftPrime()
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

    private void RotateRight()
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

    private void RotateRightPrime()
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

    private void RotateDown()
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

    private void RotateDownPrime()
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

    private void RotateBack()
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

    private void RotateBackPrime()
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

    private void RotateCubeZ()
    {
        Back.RotateLeft();
        Front.RotateRight();
        var left = Left.ReadAll();
        var up = Up.ReadAll();
        var right = Right.ReadAll();
        var down = Down.ReadAll();
        Up.WriteAll(left);
        Up.RotateLeft();
        Left.WriteAll(down);
        Left.RotateLeft();
        Right.WriteAll(up);
        Right.RotateLeft();
        Down.WriteAll(right);
        Down.RotateLeft();
    }

    private void RotateCubeZPrime()
    {
        Back.RotateRight();
        Front.RotateLeft();
        var left = Left.ReadAll();
        var up = Up.ReadAll();
        var right = Right.ReadAll();
        var down = Down.ReadAll();
        Up.WriteAll(right);
        Up.RotateRight();
        Left.WriteAll(up);
        Left.RotateRight();
        Right.WriteAll(down);
        Right.RotateRight();
        Down.WriteAll(left);
        Down.RotateRight();
    }

    private void RotateCubeX()
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

    private void RotateCubeXPrime()
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

    private void RotateCubeY()
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

    private void RotateCubeYPrime()
    {
        Up.RotateRight();
        Down.RotateLeft();
        var front = Front.ReadAll();
        var left = Left.ReadAll();
        var right = Right.ReadAll();
        var back = Back.ReadAll();
        Front.WriteAll(left);
        Left.WriteAll(back);
        Right.WriteAll(front);
        Back.WriteAll(right);
    }

    private static RubiksCubeFace CreateFace(char initial) => new(initial);
}