using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    public class ImmuneSystemTests
    {
        [Test]
        public void FightIsCorrect()
        {
            const string immuneInput = @"
17 units each with 5390 hit points (weak to radiation, bludgeoning) with an attack that does 4507 fire damage at initiative 2
989 units each with 1274 hit points (immune to fire; weak to bludgeoning, slashing) with an attack that does 25 slashing damage at initiative 3";

            const string infectionInput = @"
801 units each with 4706 hit points (weak to radiation) with an attack that does 116 bludgeoning damage at initiative 1
4485 units each with 2961 hit points (immune to radiation; weak to fire, cold) with an attack that does 12 slashing damage at initiative 4";

            var system = new ImmuneSystem(immuneInput, infectionInput);

            /*
Immune System:
No groups remain.
Infection:
Group 1 contains 782 units
Group 2 contains 4434 units
             */

            Assert.That(system.ImmuneArmy.Groups.Count, Is.EqualTo(0));
            Assert.That(system.InfectionArmy.Groups.Count, Is.EqualTo(2));
            Assert.That(system.InfectionArmy.Groups[0].Units.Count, Is.EqualTo(782));
            Assert.That(system.InfectionArmy.Groups[1].Units.Count, Is.EqualTo(4434));
        }
    }

    public class ImmuneSystem
    {
        public ImmuneSystemArmy ImmuneArmy { get; }
        public ImmuneSystemArmy InfectionArmy { get; }

        public ImmuneSystem(string immuneInput, string infectionInput)
        {
        }
    }

    public class ImmuneSystemArmy
    {
        public IList<ImmuneSystemGroup> Groups { get; }
    }

    public class ImmuneSystemGroup
    {
        public IList<ImmuneSystemUnit> Units { get; }
    }

    public class ImmuneSystemUnit
    {

    }
}