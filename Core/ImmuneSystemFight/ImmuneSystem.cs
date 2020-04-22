using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Core.Tools;

namespace Core.ImmuneSystemFight
{
    public class ImmuneSystem
    {
        private readonly Regex _regex = new Regex(@"^(\d+) units each with (\d+) hit points( \(.+\) | )with an attack that does (\d+) (.+) damage at initiative (\d+)$");
        private readonly IDictionary<string, ImmuneSystemGroup> _groups;
        private readonly IDictionary<string, string> _targets;
        private bool _fightIsActive;

        public IList<ImmuneSystemGroup> ImmuneGroups => _groups.Values.Where(o => o.Army == ImmuneSystemArmy.Immune).ToList();
        public IList<ImmuneSystemGroup> InfectionGroups => _groups.Values.Where(o => o.Army == ImmuneSystemArmy.Infection).ToList();
        public int WinningArmyUnitCount => _groups.Values.Sum(o => o.UnitCount);

        public ImmuneSystem(string immuneInput, string infectionInput)
        {
            _groups = new Dictionary<string, ImmuneSystemGroup>();
            _targets = new Dictionary<string, string>();
            ParseGroups(ImmuneSystemArmy.Immune, immuneInput);
            ParseGroups(ImmuneSystemArmy.Infection, infectionInput);
        }

        public void Fight()
        {
            _fightIsActive = true;
            while (_fightIsActive)
            {
                SelectTargets();
                Attack();
            }
        }

        private void SelectTargets()
        {
            foreach (var group in _groups.Values.OrderByDescending(o => o.EffectivePower).ThenByDescending(o => o.Initiative))
            {
                var targetsWithDamages = _groups.Values
                    .Where(o => o.Army != group.Army && !_targets.Values.Contains(o.Id))
                    .Select(o => (o, o.PossibleDamage(group)))
                    .Where(o => o.Item2 > 0)
                    .ToList();

                if (targetsWithDamages.Any())
                {
                    var target = targetsWithDamages
                        .OrderByDescending(o => o.Item2)
                        .ThenByDescending(o => o.Item1.EffectivePower)
                        .ThenByDescending(o => o.Item1.Initiative)
                        .First().Item1;

                    _targets.Add(group.Id, target.Id);
                }
            }
        }

        private void Attack()
        {
            foreach (var attacker in _groups.Values.OrderByDescending(o => o.Initiative))
            {
                if (_fightIsActive)
                {
                    if (_groups.ContainsKey(attacker.Id) && _targets.ContainsKey(attacker.Id) && _groups.TryGetValue(_targets[attacker.Id], out var defender))
                    {
                        defender.Attack(attacker);

                        if (defender.UnitCount <= 0)
                            _groups.Remove(defender.Id);
                    }
                }

                _fightIsActive = ImmuneGroups.Any() && InfectionGroups.Any();
            }

            _targets.Clear();
        }

        private void ParseGroups(ImmuneSystemArmy army, string s)
        {
            var rows = PuzzleInputReader.Read(s);
            var counter = 0;
            foreach (var row in rows)
            {
                counter++;
                var id = $"{army}{counter}";
                var g = ParseGroup(id, army, row);
                _groups.Add(g.Id, g);
            }
        }

        private ImmuneSystemGroup ParseGroup(string id, ImmuneSystemArmy army, string s)
        {
            var match = _regex.Match(s);
            var unitCount = int.Parse(match.Groups[1].Value);
            var hitPoints = int.Parse(match.Groups[2].Value);
            var immunitiesAndWeaknesses = ParseImmunitiesAndWeaknesses(match.Groups[3].Value);
            var immunities = immunitiesAndWeaknesses.immunities;
            var weaknesses = immunitiesAndWeaknesses.weaknesses;
            var damage = int.Parse(match.Groups[4].Value);
            var attackType = match.Groups[5].Value;
            var initiative = int.Parse(match.Groups[6].Value);
            return new ImmuneSystemGroup(army, id, unitCount, hitPoints, immunities, weaknesses, damage, attackType, initiative);
        }

        private (IList<string> immunities, IList<string> weaknesses) ParseImmunitiesAndWeaknesses(string s)
        {
            s = s.Trim().TrimStart('(').TrimEnd(')');
            var immunities = new List<string>();
            var weaknesses = new List<string>();
            if (s.Length > 0)
            {
                var parts = s.Split(';');
                foreach (var part in parts)
                {
                    var list = part.Trim().StartsWith("immune") ? immunities : weaknesses;
                    var items = part.Replace("immune to", "").Replace("weak to", "").Split(',').Select(o => o.Trim());
                    list.AddRange(items);
                }
            }
            return (immunities, weaknesses);
        }
    }
}