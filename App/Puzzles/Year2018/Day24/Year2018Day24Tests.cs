using NUnit.Framework;

namespace App.Puzzles.Year2018.Day24;

public class Year2018Day24Tests
{
    private const string ImmuneInput = @"
Immune System:
17 units each with 5390 hit points (weak to radiation, bludgeoning) with an attack that does 4507 fire damage at initiative 2
989 units each with 1274 hit points (immune to fire; weak to bludgeoning, slashing) with an attack that does 25 slashing damage at initiative 3";

    private const string InfectionInput = @"
Infection:
801 units each with 4706 hit points (weak to radiation) with an attack that does 116 bludgeoning damage at initiative 1
4485 units each with 2961 hit points (immune to radiation; weak to fire, cold) with an attack that does 12 slashing damage at initiative 4";

    [Test]
    public void FightIsCorrect()
    {
        var system = new ImmuneSystem(ImmuneInput, InfectionInput);
        system.Fight();

        Assert.That(system.ImmuneGroups.Count, Is.EqualTo(0));
        Assert.That(system.InfectionGroups.Count, Is.EqualTo(2));
        Assert.That(system.InfectionGroups[0].UnitCount, Is.EqualTo(782));
        Assert.That(system.InfectionGroups[1].UnitCount, Is.EqualTo(4434));
        Assert.That(system.WinningArmyUnitCount, Is.EqualTo(5216));
    }

    [Test]
    public void FightWithBoostIsCorrect()
    {
        var system = new ImmuneSystem(ImmuneInput, InfectionInput);
        system.Fight(1570);

        Assert.That(system.WinningArmyUnitCount, Is.EqualTo(51));
    }

    [Test]
    public void FightUntilImmuneSystemWinsIsCorrect()
    {
        var system = new ImmuneSystem(ImmuneInput, InfectionInput);
        system.FightUntilImmuneSystemWins();

        Assert.That(system.WinningArmyUnitCount, Is.EqualTo(51));
    }
}