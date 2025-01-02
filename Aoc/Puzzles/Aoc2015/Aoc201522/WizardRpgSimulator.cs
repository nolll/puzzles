namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201522;

public class WizardRpgSimulator(WizardRpgGameMode gameMode)
{
    private readonly IList<WizardRpgSpell> _spells = new List<WizardRpgSpell>
    {
        new ("Magic Missile", 53, 4, 0, 0, 0, 0),
        new ("Drain", 73, 2, 0, 2, 0, 0),
        new ("Shield", 113, 0, 7, 0, 0, 6),
        new ("Poison", 173, 3, 0, 0, 0, 6),
        new ("Recharge", 229, 0, 0, 0, 101, 5),
    };

    public int WinWithLowestCost(int bossPoints, int bossDamage)
    {
        var boss = new WizardRpgBoss(bossPoints, bossDamage);
        var player = new WizardRpgPlayer(500, 50, 0);
        var lowest = Run(boss, player, new List<WizardRpgEffect>(), 0);

        return lowest;
    }

    private int Run(WizardRpgCharacter boss, WizardRpgPlayer player, List<WizardRpgEffect> effects, int cost)
    {
        var costs = new List<int>();
        foreach (var spell in _spells)
        {
            var newBoss = new WizardRpgBoss(boss.Points, boss.Damage);
            var newPlayer = new WizardRpgPlayer(player.Mana, player.Points, player.Damage);
            var newCost = cost + spell.Cost;

            if (gameMode == WizardRpgGameMode.Hard)
                newPlayer.Points--;

            var newEffects = effects.Select(o => new WizardRpgEffect(o.Name, o.Damage, o.Armor, o.Healing, o.Recharge, o.Timer)).ToList();
            var newEffect = spell.GetEffect();

            var hasCastSpell = false;
            if (newEffect.Timer == 0 && CanCastSpell(newEffects, player, spell))
            {
                newPlayer.Mana += newEffect.Recharge;
                newPlayer.Mana -= spell.Cost;
                newPlayer.Points += newEffect.Healing;
                newBoss.Points -= newEffect.Damage;
                hasCastSpell = true;
            }

            var reshargeSum = newEffects.Sum(o => o.Recharge);
            newPlayer.Mana += reshargeSum;
            newPlayer.Points += newEffects.Sum(o => o.Healing);
            var bossDamage = newEffects.Sum(o => o.Damage);
            newBoss.Points -= bossDamage;
            foreach (var effect in newEffects)
                effect.Timer--;
                
            if (!newBoss.IsAlive)
            {
                costs.Add(newCost);
                continue;
            }

            newEffects = newEffects.Where(o => o.Timer > 0).ToList();
            if (newEffect.Timer > 0 && CanCastSpell(newEffects, player, spell))
            {
                newPlayer.Mana -= spell.Cost;
                newEffects.Add(newEffect);
                hasCastSpell = true;
            }

            if(!hasCastSpell)
                continue;
                
            newPlayer.Mana += newEffects.Sum(o => o.Recharge);
            newPlayer.Points += newEffects.Sum(o => o.Healing);
            newBoss.Points -= newEffects.Sum(o => o.Damage);
            var playerDamage = Math.Max(newBoss.Damage - newEffects.Sum(o => o.Armor), 1);
            newPlayer.Points -= playerDamage;
            foreach (var effect in newEffects)
                effect.Timer--;
            newEffects = newEffects.Where(o => o.Timer > 0).ToList();

            if (!newBoss.IsAlive)
            {
                costs.Add(newCost);
                continue;
            }

            if (!newPlayer.IsAlive)
                continue;

            var nextCost = Run(newBoss, newPlayer, newEffects, newCost);

            if (nextCost > 0)
                costs.Add(nextCost);
        }

        return costs.Any() ? costs.Min() : 0;
    }

    private static bool CanCastSpell(IEnumerable<WizardRpgEffect> effects, WizardRpgPlayer player, WizardRpgSpell spell)
    {
        var canAffordSpell = player.Mana >= spell.Cost;
        var spellAlreadyCast = effects.Any(o => o.Name == spell.Name);
        return canAffordSpell && !spellAlreadyCast;
    }
}