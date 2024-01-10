using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aquaq.Puzzles.Aquaq31.RubiksCube;

public class CubeSolverTests
{
    [Test]
    public void BringToFront()
    {
        var cube = new Cube();
        cube.Scramble();

        var solver = new CubeSolver(cube);
        solver.BringToFront(CubeColors.Blue);

        solver.Cube.Front.Center.Should().Be(CubeColors.Blue);
    }

    [Test]
    public void BringToTop()
    {
        var cube = new Cube();
        cube.Scramble();

        var solver = new CubeSolver(cube);
        solver.BringToUp(CubeColors.Blue);

        solver.Cube.Up.Center.Should().Be(CubeColors.Blue);
    }

    [Test]
    public void BringToDown()
    {
        var cube = new Cube();
        cube.Scramble();

        var solver = new CubeSolver(cube);
        solver.BringToDown(CubeColors.Blue);

        solver.Cube.Down.Center.Should().Be(CubeColors.Blue);
    }
}