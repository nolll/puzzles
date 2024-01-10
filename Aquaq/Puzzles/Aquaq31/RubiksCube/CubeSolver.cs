namespace Pzl.Aquaq.Puzzles.Aquaq31.RubiksCube;

public class CubeSolver
{
    public Cube Cube { get; }

    public CubeSolver(Cube cube)
    {
        Cube = cube;
    }

    public void Solve()
    {
    }

    public void BringToFront(char color) => BringToFace(Cube.Front, color, ["X", "X", "X", "X", "XY", "YY"]);
    public void BringToUp(char color) => BringToFace(Cube.Up, color, ["X", "X", "X", "X", "XZ", "ZZ"]);
    public void BringToDown(char color) => BringToFace(Cube.Down, color, ["X", "X", "X", "X", "XZ", "ZZ"]);

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