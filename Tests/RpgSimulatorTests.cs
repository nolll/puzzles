using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Tests
{
    public class RpgSimulatorTests
    {
        [Test]
        public void PlayerWinsInFourRounds()
        {
            var simulator = new RpgSimulator();
            simulator.Run(12, 7, 2, 8, 5, 5);

            Assert.That(simulator.RoundsPlayed, Is.EqualTo(4));
            Assert.That(simulator.Winner.Name, Is.EqualTo("player"));
            Assert.That(simulator.Winner.Points, Is.EqualTo(2));
        }
    }

    public class RpgSimulator
    {
        public int RoundsPlayed { get; private set; }
        public RpgPlayer Winner { get; private set; }

        private IList<RpgProperty> Weapons = new List<RpgProperty>
        {
            new RpgProperty("Dagger", 8, 4, 0),
            new RpgProperty("Shortsword", 10, 5, 0),
            new RpgProperty("Warhammer", 25, 6, 0),
            new RpgProperty("Longsword", 40, 7, 0),
            new RpgProperty("Greataxe", 74, 8, 0)
        };

        private IList<RpgProperty> Armor = new List<RpgProperty>
        {
            new RpgProperty("Leather", 13, 0, 1),
            new RpgProperty("Chainmail", 31, 0, 2),
            new RpgProperty("Splintmail", 53, 0, 3),
            new RpgProperty("Bandedmail", 75, 0, 4),
            new RpgProperty("Platemail", 102, 0, 5)
        };

        private IList<RpgProperty> Rings = new List<RpgProperty>
        {
            new RpgProperty("Damage +1", 25, 1, 0),
            new RpgProperty("Damage +2", 50, 2, 0),
            new RpgProperty("Damage +3", 100, 3, 0),
            new RpgProperty("Defense +1", 20, 0, 1),
            new RpgProperty("Defense +2", 40, 0, 2),
            new RpgProperty("Defense +3", 80, 0, 3)
        };

        public RpgSimulator()
        {
            RoundsPlayed = 0;
        }

        public int RunWithLeastAmountOfGold(int bossPoints, int bossDamage, int bossArmor)
        {
            var leastAmountOfGold = int.MaxValue;
            var combinations = GetPropertyCombinations();
            while (combinations.Any())
            {
                var current = combinations.First();
                combinations.RemoveAt(0);

            }

            return leastAmountOfGold;
        }

        private IList<IList<RpgProperty>> GetPropertyCombinations()
        {
            var weaponCombinations = GetWeaponCombinations();
            var armorCombinations = GetArmorCombinations();
            var ringCombinations = GetRingCombinations();

            return new List<IList<RpgProperty>>();
        }

        private IList<IList<RpgProperty>> GetWeaponCombinations()
        {
            return Weapons.Select(weapon => new List<RpgProperty> {weapon}).Cast<IList<RpgProperty>>().ToList();
        }

        private IList<IList<RpgProperty>> GetArmorCombinations()
        {
            var combinations = new List<IList<RpgProperty>> { new List<RpgProperty>() };
            combinations.AddRange(Armor.Select(armor => new List<RpgProperty> { armor }));
            return combinations;
        }

        private IList<IList<RpgProperty>> GetRingCombinations()
        {
            return new List<IList<RpgProperty>>();
        }

        public void Run(int bossPoints, int bossDamage, int bossArmor, in int playerPoints, in int playerDamage, in int playerArmor)
        {
            var boss = new RpgPlayer("boss", bossPoints, bossDamage, bossArmor);
            var player = new RpgPlayer("player", playerPoints, playerDamage, playerArmor);
            Run(boss, player);
        }

        private void Run(RpgPlayer boss, RpgPlayer player)
        {
            while (player.IsAlive && boss.IsAlive)
            {
                var isAlive = boss.Hurt(player.Damage);
                if (isAlive)
                    player.Hurt(boss.Damage);
                RoundsPlayed++;
            }

            Winner = player.IsAlive ? player : boss;
        }
    }

    public class RpgPlayer
    {
        public string Name { get; }
        public int Points { get; private set; }
        public int Damage { get; }
        public int Armor { get; }

        public bool IsAlive => Points > 0;

        public RpgPlayer(string name, in int points, in int damage, in int armor)
        {
            Name = name;
            Points = points;
            Damage = damage;
            Armor = armor;
        }

        public bool Hurt(int attack)
        {
            Points -= Math.Max(attack - Armor, 1);
            return IsAlive;
        }
    }

    public class RpgProperty
    {
        public string Name { get; }
        public int Cost { get; }
        public int Damage { get; }
        public int Armor { get; }

        public RpgProperty(string name, int cost, int damage, int armor)
        {
            Name = name;
            Cost = cost;
            Damage = damage;
            Armor = armor;
        }
    }
}