namespace Aquaq.Puzzles.Aquaq31;

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
        if (instruction == "U")
            RotateUp();
        if (instruction == "U'")
            RotateUpPrime();
        if (instruction == "L")
            RotateLeft();
        if (instruction == "B")
            RotateBack();
        if (instruction == "R")
            RotateRight();
    }

    private void RotateUp()
    {
        Up.RotateRight();
        var fromFront = Front.ReadRow(0);
        var fromLeft = Left.ReadRow(0);
        var fromBack = Back.ReadRow(0);
        var fromRight = Right.ReadRow(0);
        Front.WriteRow(0, fromRight);
        Left.WriteRow(0, fromFront);
        Right.WriteRow(0, fromBack);
        Back.WriteRow(0, fromLeft);
    }

    private void RotateUpPrime()
    {
        Up.RotateLeft();
        var fromFront = Front.ReadRow(0);
        var fromLeft = Left.ReadRow(0);
        var fromBack = Back.ReadRow(0);
        var fromRight = Right.ReadRow(0);
        Front.WriteRow(0, fromLeft);
        Left.WriteRow(0, fromBack);
        Right.WriteRow(0, fromFront);
        Back.WriteRow(0, fromRight);
    }

    private void RotateLeft()
    {
        Left.RotateRight();
        var fromFront = Front.ReadColumn(0);
        var fromUp = Up.ReadColumn(0);
        var fromDown = Down.ReadColumn(0);
        var fromBack = Back.ReadColumn(2);
        Front.WriteColumn(0, fromUp);
        Up.WriteReverseColumn(0, fromBack);
        Down.WriteColumn(0, fromFront);
        Back.WriteReverseColumn(2, fromDown);
    }

    private void RotateBack()
    {
        Back.RotateRight();
        var fromUp = Up.ReadRow(0);
        var fromLeft = Left.ReadColumn(0);
        var fromDown = Down.ReadRow(2);
        var fromRight = Right.ReadColumn(2);
        Left.WriteReverseColumn(0, fromUp);
        Down.WriteRow(2, fromLeft);
        Right.WriteReverseColumn(2, fromDown);
        Up.WriteRow(0, fromRight);
    }

    private void RotateRight()
    {
        Right.RotateRight();
        var fromFront = Front.ReadColumn(2);
        var fromUp = Up.ReadColumn(2);
        var fromDown = Down.ReadColumn(2);
        var fromBack = Back.ReadColumn(0);
        Up.WriteColumn(2, fromFront);
        Front.WriteColumn(2, fromDown);
        Down.WriteReverseColumn(2, fromBack);
        Back.WriteReverseColumn(0, fromUp);
    }

    private static RubiksCubeFace CreateFace(char initial) => new(initial);
}