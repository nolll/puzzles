using FluentAssertions;
using NUnit.Framework;

namespace Puzzles.aoc.Puzzles.Aoc2015.Aoc201506;

public class Aoc201506Tests
{
    [Test]
    public void TurnsOnAllLights()
    {
        var controller = new ChristmasLightsController(5);
        controller.TurnOn(0, 0, 4, 4);

        controller.LitCount.Should().Be(25);
    }

    [Test]
    public void TurnsOnAllLightsTurnsOffFiveLights()
    {
        var controller = new ChristmasLightsController(5);
        controller.TurnOn(0, 0, 4, 4);
        controller.TurnOff(0, 2, 4, 2);

        controller.LitCount.Should().Be(20);
    }

    [Test]
    public void TurnsOnAllLightsTurnsOffFiveLightsTogglesAllLights()
    {
        var controller = new ChristmasLightsController(5);
        controller.TurnOn(0, 0, 4, 4);
        controller.TurnOff(0, 2, 4, 2);
        controller.Toggle(0, 0, 4, 4);

        controller.LitCount.Should().Be(5);
    }
}