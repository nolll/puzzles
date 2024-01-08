using NUnit.Framework;

namespace Pzl.Aquaq.Puzzles.Aquaq31;

public class CubeSolverTests
{
    [Test]
    public void SolveWhiteCross()
    {
        var cube = new RubiksCube();
        var solver = new RubiksCubeSolver(cube);

        solver.SolveWhiteCross();
    }
}

public class RubiksCubeSolver
{
    private readonly RubiksCube _cube;

    public RubiksCubeSolver(RubiksCube cube)
    {
        _cube = cube;
    }

    public void SolveWhiteCross()
    {
        //_cube.Rotate("F");
        _cube.Scramble();
        Console.WriteLine(_cube.Print());
        Console.WriteLine();
        Console.WriteLine(_cube.PrintFlat());
    }
}