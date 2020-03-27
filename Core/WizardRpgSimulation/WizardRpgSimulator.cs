using System.Collections.Generic;
using System.Linq;

namespace Core.WizardRpgSimulation
{
    public class WizardRpgSimulator
    {
        private readonly IList<WizardRpgSpell> _spells = new List<WizardRpgSpell>
        {
            new WizardRpgSpell("Magic Missile", 53, 4, 0, 0, 0, 1),
            new WizardRpgSpell("Drain", 73, 2, 0, 0, 0, 1),
            new WizardRpgSpell("Shield", 113, 0, 7, 0, 0, 6),
            new WizardRpgSpell("Poison", 173, 3, 0, 0, 0, 6),
            new WizardRpgSpell("Recharge", 229, 0, 0, 0, 101, 5)
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
            var isAlive = boss.Hurt(player.Damage);
            if (isAlive)
                player.Hurt(boss.Damage);

            var costs = new List<int>();
            if (player.IsAlive && boss.IsAlive)
            {
                foreach (var spell in _spells)
                {
                    var newEffects = effects.Select(o => o).ToList();
                    newEffects.Add(spell.GetEffect());
                    if (CanCastSpell(newEffects, player, spell))
                    {
                        var newBoss = new WizardRpgBoss(boss.Points, boss.Damage);
                        var newPlayer = new WizardRpgPlayer(player.Mana - spell.Cost, player.Points, player.Damage);
                        var newCost = Run(newBoss, newPlayer, newEffects, cost + spell.Cost);

                        if(newCost > 0)
                            costs.Add(newCost);
                    }
                }
            }

            return costs.Any() ? costs.Min() : 0;
        }

        private bool CanCastSpell(IEnumerable<WizardRpgEffect> effects, WizardRpgPlayer player, WizardRpgSpell spell)
        {
            return player.Mana >= spell.Cost && effects.All(o => o.Name != spell.Name);
        }
    }
}