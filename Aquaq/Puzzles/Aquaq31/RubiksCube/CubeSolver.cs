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

    public void BringToFront(char color)
    {
        if (Cube.Front.Center == color) 
            return;
        
        Cube.RotateX();
        
        if (Cube.Front.Center == color) 
            return;
        
        Cube.RotateX();
        
        if (Cube.Front.Center == color) 
            return;
        
        Cube.RotateX();
        
        if (Cube.Front.Center == color) 
            return;
        
        Cube.RotateX();
        Cube.RotateY();
        
        if (Cube.Front.Center == color) 
            return;
        
        Cube.RotateY();
        Cube.RotateY();
    }
}