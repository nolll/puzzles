using Pzl.Aoc.Puzzles.Aoc2015;
using Pzl.Tools.Grids.Grids2d;

namespace Tests.Aoc.Aoc2015;

public class Aoc201506Tests
{
    private const int Size = 5;

    [Fact]
    public void TurnsOnAllLights()
    {
        var grid = new Grid<int>(Size, Size);
        new Aoc201506.TurnOnCommand(0, 0, 4, 4).Move(grid);
        Aoc201506.LitCount(grid).Should().Be(25);
    }

    [Fact]
    public void TurnsOnAllLightsTurnsOffFiveLights()
    {
        var grid = new Grid<int>(Size, Size);
        new Aoc201506.TurnOnCommand(0, 0, 4, 4).Move(grid);
        new Aoc201506.TurnOffCommand(0, 2, 4, 2).Move(grid);
        Aoc201506.LitCount(grid).Should().Be(20);
    }

    [Fact]
    public void TurnsOnAllLightsTurnsOffFiveLightsTogglesAllLights()
    {
        var grid = new Grid<int>(Size, Size);
        new Aoc201506.TurnOnCommand(0, 0, 4, 4).Move(grid);
        new Aoc201506.TurnOffCommand(0, 2, 4, 2).Move(grid);
        new Aoc201506.ToggleCommand(0, 0, 4, 4).Move(grid);
        Aoc201506.LitCount(grid).Should().Be(5);
    }
}