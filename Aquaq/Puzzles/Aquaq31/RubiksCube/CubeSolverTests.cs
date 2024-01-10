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
}