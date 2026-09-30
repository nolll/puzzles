using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2015;

[Name("Wizard Simulator 20XX")]
public class Aoc201522 : AocPuzzle
{
    [Puzzle("1f020968b40b91444beee0e8a33624d1")]
    public int Part1(string input)
    {
        var p = GetParams(input);
        return WinWithLowestCost(WizardRpgGameMode.Easy, p.HitPoints, p.Damage);
    }

    [Puzzle("d76b3b0ad8b9bce7fab0c1ba0de0d20e")]
    public int Part2(string input)
    {
        var p = GetParams(input);
        return WinWithLowestCost(WizardRpgGameMode.Hard, p.HitPoints, p.Damage);
    }

    private static Params GetParams(string input)
    {
        var rows = input.Split(LineBreaks.Single);
        return new Params(GetIntFromRow(rows[0]), GetIntFromRow(rows[1]));
    }

    private static int GetIntFromRow(string s) => int.Parse(s.Split(':')[1].Trim());

    private record Params(int HitPoints, int Damage);

    private readonly IList<WizardRpgSpell> _spells = new List<WizardRpgSpell>
    {
        new("Magic Missile", 53, 4, 0, 0, 0, 0),
        new("Drain", 73, 2, 0, 2, 0, 0),
        new("Shield", 113, 0, 7, 0, 0, 6),
        new("Poison", 173, 3, 0, 0, 0, 6),
        new("Recharge", 229, 0, 0, 0, 101, 5),
    };

    public int WinWithLowestCost(WizardRpgGameMode gameMode, int bossPoints, int bossDamage)
    {
        var boss = new WizardRpgBoss(bossPoints, bossDamage);
        var player = new WizardRpgPlayer(500, 50, 0);
        var lowest = Run(gameMode, boss, player, new List<WizardRpgEffect>(), 0);

        return lowest;
    }

    private int Run(WizardRpgGameMode gameMode, WizardRpgCharacter boss, WizardRpgPlayer player, List<WizardRpgEffect> effects, int cost)
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

            if (!hasCastSpell)
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

            var nextCost = Run(gameMode, newBoss, newPlayer, newEffects, newCost);

            if (nextCost > 0)
                costs.Add(nextCost);
        }

        return costs.Count > 0 ? costs.Min() : 0;
    }

    private static bool CanCastSpell(IEnumerable<WizardRpgEffect> effects, WizardRpgPlayer player, WizardRpgSpell spell)
    {
        var canAffordSpell = player.Mana >= spell.Cost;
        var spellAlreadyCast = effects.Any(o => o.Name == spell.Name);
        return canAffordSpell && !spellAlreadyCast;
    }

    public abstract class WizardRpgCharacter(int points, int damage)
    {
        public int Points { get; set; } = points;
        public int Damage { get; } = damage;

        public bool IsAlive => Points > 0;
    }

    private class WizardRpgBoss(int points, int damage) : WizardRpgCharacter(points, damage);

    private class WizardRpgPlayer(int mana, int points, int damage) : WizardRpgCharacter(points, damage)
    {
        public int Mana { get; set; } = mana;
    }

    public enum WizardRpgGameMode
    {
        Easy,
        Hard
    }

    private class WizardRpgEffect(string name, int damage, int armor, int healing, int recharge, int timer)
    {
        public string Name { get; } = name;
        public int Damage { get; } = damage;
        public int Armor { get; } = armor;
        public int Healing { get; } = healing;
        public int Recharge { get; } = recharge;
        public int Timer { get; set; } = timer;
    }

    private class WizardRpgSpell(string name, int cost, int damage, int armor, int healing, int recharge, int timer)
    {
        public string Name { get; } = name;
        public int Cost { get; } = cost;

        public WizardRpgEffect GetEffect() => new(Name, damage, armor, healing, recharge, timer);
    }
}