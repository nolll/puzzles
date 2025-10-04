namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201506;

public class Aoc201506Tests
{
    [Fact]
    public void TurnsOnAllLights()
    {
        var controller = new ChristmasLightsController(5);
        controller.TurnOn(0, 0, 4, 4);

        controller.LitCount.Should().Be(25);
    }

    [Fact]
    public void TurnsOnAllLightsTurnsOffFiveLights()
    {
        var controller = new ChristmasLightsController(5);
        controller.TurnOn(0, 0, 4, 4);
        controller.TurnOff(0, 2, 4, 2);

        controller.LitCount.Should().Be(20);
    }

    [Fact]
    public void TurnsOnAllLightsTurnsOffFiveLightsTogglesAllLights()
    {
        var controller = new ChristmasLightsController(5);
        controller.TurnOn(0, 0, 4, 4);
        controller.TurnOff(0, 2, 4, 2);
        controller.Toggle(0, 0, 4, 4);

        controller.LitCount.Should().Be(5);
    }
}