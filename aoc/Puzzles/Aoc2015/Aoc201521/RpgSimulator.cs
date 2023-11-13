using Puzzles.common.Combinatorics;

namespace Puzzles.aoc.Puzzles.Aoc2015.Aoc201521;

public class RpgSimulator
{
    public int RoundsPlayed { get; private set; }

    private readonly IList<RpgProperty> _weapons = new List<RpgProperty>
    {
        new RpgProperty("Dagger", 8, 4, 0),
        new RpgProperty("Shortsword", 10, 5, 0),
        new RpgProperty("Warhammer", 25, 6, 0),
        new RpgProperty("Longsword", 40, 7, 0),
        new RpgProperty("Greataxe", 74, 8, 0)
    };

    private readonly IList<RpgProperty> _armor = new List<RpgProperty>
    {
        new RpgProperty("Leather", 13, 0, 1),
        new RpgProperty("Chainmail", 31, 0, 2),
        new RpgProperty("Splintmail", 53, 0, 3),
        new RpgProperty("Bandedmail", 75, 0, 4),
        new RpgProperty("Platemail", 102, 0, 5)
    };

    private readonly IList<RpgProperty> _rings = new List<RpgProperty>
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

    public int WinWithLowestCost(int bossPoints, int bossDamage, int bossArmor)
    {
        var lowest = int.MaxValue;
        var propertyCombinations = GetPropertyCombinations();
        while (propertyCombinations.Any())
        {
            var properties = propertyCombinations.First();
            propertyCombinations.RemoveAt(0);

            var boss = new RpgBoss(bossPoints, bossDamage, bossArmor);
            var player = new RpgPlayer(100, properties);

            var winner = Run(boss, player);
            if (winner.Name == "player")
            {
                var cost = properties.Sum(o => o.Cost);
                if (cost < lowest)
                    lowest = cost;
            }
        }

        return lowest;
    }

    public int LoseWithHighestCost(int bossPoints, int bossDamage, int bossArmor)
    {
        var highestCost = int.MinValue;
        var propertyCombinations = GetPropertyCombinations();
        while (propertyCombinations.Any())
        {
            var properties = propertyCombinations.First();
            propertyCombinations.RemoveAt(0);

            var boss = new RpgBoss(bossPoints, bossDamage, bossArmor);
            var player = new RpgPlayer(100, properties);

            var winner = Run(boss, player);
            if (winner.Name == "boss")
            {
                var cost = properties.Sum(o => o.Cost);
                if (cost > highestCost)
                    highestCost = cost;
            }
        }

        return highestCost;
    }

    private IList<IList<RpgProperty>> GetPropertyCombinations()
    {
        var weaponCombinations = GetWeaponCombinations();
        var armorCombinations = GetArmorCombinations();
        var ringCombinations = GetRingCombinations();

        var combinations = new List<IList<RpgProperty>>();
        foreach (var weaponCombination in weaponCombinations)
        {
            foreach (var armorCombination in armorCombinations)
            {
                foreach (var ringCombination in ringCombinations)
                {
                    var combination = new List<RpgProperty>();
                    combination.AddRange(weaponCombination);
                    combination.AddRange(armorCombination);
                    combination.AddRange(ringCombination);
                    combinations.Add(combination);
                }
            }
        }

        return combinations;
    }

    private IList<List<RpgProperty>> GetWeaponCombinations()
    {
        return _weapons.Select(weapon => new List<RpgProperty> {weapon}).ToList();
    }

    private IList<List<RpgProperty>> GetArmorCombinations()
    {
        var combinations = new List<List<RpgProperty>> { new List<RpgProperty>() };
        combinations.AddRange(_armor.Select(armor => new List<RpgProperty> { armor }));
        return combinations;
    }

    private IList<List<RpgProperty>> GetRingCombinations()
    {
        var combinations = new List<List<RpgProperty>> { new List<RpgProperty>() };
        combinations.AddRange(_rings.Select(ring => new List<RpgProperty> { ring }));
        combinations.AddRange(PermutationGenerator.GetPermutations(_rings, 2).Select(o => o.ToList()).ToList());
        return combinations;
    }

    public RpgCharacter Run(int bossPoints, int bossDamage, int bossArmor, in int playerPoints, in int playerDamage, in int playerArmor)
    {
        var boss = new RpgBoss(bossPoints, bossDamage, bossArmor);
        var player = new RpgPlayer(playerPoints, playerDamage, playerArmor);
        return Run(boss, player);
    }

    private RpgCharacter Run(RpgCharacter boss, RpgCharacter player)
    {
        while (player.IsAlive && boss.IsAlive)
        {
            var isAlive = boss.Hurt(player.Damage);
            if (isAlive)
                player.Hurt(boss.Damage);
            RoundsPlayed++;
        }

        return player.IsAlive ? player : boss;
    }
}