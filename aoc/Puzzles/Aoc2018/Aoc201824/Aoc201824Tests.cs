using FluentAssertions;
using NUnit.Framework;

namespace Aoc.Puzzles.Aoc2018.Aoc201824;

public class Aoc201824Tests
{
    private const string ImmuneInput = """
Immune System:
17 units each with 5390 hit points (weak to radiation, bludgeoning) with an attack that does 4507 fire damage at initiative 2
989 units each with 1274 hit points (immune to fire; weak to bludgeoning, slashing) with an attack that does 25 slashing damage at initiative 3
""";

    private const string InfectionInput = """
Infection:
801 units each with 4706 hit points (weak to radiation) with an attack that does 116 bludgeoning damage at initiative 1
4485 units each with 2961 hit points (immune to radiation; weak to fire, cold) with an attack that does 12 slashing damage at initiative 4
""";

    [Test]
    public void FightIsCorrect()
    {
        var system = new ImmuneSystem(ImmuneInput.Trim(), InfectionInput.Trim());
        system.Fight();

        system.ImmuneGroups.Count.Should().Be(0);
        system.InfectionGroups.Count.Should().Be(2);
        system.InfectionGroups[0].UnitCount.Should().Be(782);
        system.InfectionGroups[1].UnitCount.Should().Be(4434);
        system.WinningArmyUnitCount.Should().Be(5216);
    }

    [Test]
    public void FightWithBoostIsCorrect()
    {
        var system = new ImmuneSystem(ImmuneInput.Trim(), InfectionInput.Trim());
        system.Fight(1570);

        system.WinningArmyUnitCount.Should().Be(51);
    }

    [Test]
    public void FightUntilImmuneSystemWinsIsCorrect()
    {
        var system = new ImmuneSystem(ImmuneInput.Trim(), InfectionInput.Trim());
        system.FightUntilImmuneSystemWins();

        system.WinningArmyUnitCount.Should().Be(51);
    }
}