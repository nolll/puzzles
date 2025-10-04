using FluentAssertions;

namespace Pzl.Aquaq.Puzzles.Aquaq31.RubiksCube;

public class CubeSolverTests
{
    [Fact]
    public void BringToFront()
    {
        var cube = new Cube();
        cube.Scramble();

        var solver = new CubeSolver(cube);
        solver.BringToFront(CubeColors.Blue);

        solver.Cube.Front.Center.Should().Be(CubeColors.Blue);
    }

    [Fact]
    public void BringToTop()
    {
        var cube = new Cube();
        cube.Scramble();

        var solver = new CubeSolver(cube);
        solver.BringToUp(CubeColors.Blue);

        solver.Cube.Up.Center.Should().Be(CubeColors.Blue);
    }

    [Fact]
    public void BringToDown()
    {
        var cube = new Cube();
        cube.Scramble();

        var solver = new CubeSolver(cube);
        solver.BringToDown(CubeColors.Blue);

        solver.Cube.Down.Center.Should().Be(CubeColors.Blue);
    }

    //[Fact]
    //public void MoveWhiteEdgesToYellowFace()
    //{
    //    var cube = CubeTestHelper.CreateScrambledCube();

    //    cube.YellowFace.Top.Should().Be(CubeColors.White);
    //    cube.YellowFace.Left.Should().Be(CubeColors.White);
    //    cube.YellowFace.Right.Should().Be(CubeColors.White);
    //    cube.YellowFace.Bottom.Should().Be(CubeColors.White);
    //}
}