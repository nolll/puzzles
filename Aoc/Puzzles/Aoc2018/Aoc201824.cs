using System.Text.RegularExpressions;
using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2018;

[Name("Immune System Simulator 20XX")]
public class Aoc201824 : AocPuzzle
{
    [Puzzle("84df04e9e9a02e41225db74dadfd8c9d")]
    public int Part1(string input) => RunPart1(input);

    [Puzzle("bfce9d78a8a72d8fd0d76fd5fc479dc8")]
    public int Part2(string input) => FightUntilImmuneSystemWins(input);

    public int RunPart1(string input, int boost = 0)
    {
        var (_, unitCount) = Fight(input, boost);
        return unitCount;
    }

    private static readonly Regex Regex =
        new(@"^(\d+) units each with (\d+) hit points( \(.+\) | )with an attack that does (\d+) (.+) damage at initiative (\d+)$");

    private (ImmuneSystemArmy, int) Fight(string input, int boost = 0)
    {
        var (groups, targets) = Reset(input, boost);
        var fightIsActive = true;
        while (fightIsActive)
        {
            SelectTargets(groups, targets);
            fightIsActive = Attack(groups, targets);
        }

        return (groups.Values.First().Army, groups.Values.Sum(o => o.UnitCount));
    }

    private int FightUntilImmuneSystemWins(string input)
    {
        var boost = 1;
        while (true)
        {
            try
            {
                var (winningArmy, unitCount) = Fight(input, boost);
                if (winningArmy == ImmuneSystemArmy.Immune)
                    return unitCount;
            }
            catch (StalemateException)
            {
            }

            boost++;
        }
    }

    private (IDictionary<string, ImmuneSystemGroup>, Dictionary<string, string>) Reset(string input, int boost) =>
        (Parse(input, boost), new Dictionary<string, string>());

    private static void SelectTargets(IDictionary<string, ImmuneSystemGroup> groups, Dictionary<string, string> targets)
    {
        foreach (var group in groups.Values.OrderByDescending(o => o.EffectivePower).ThenByDescending(o => o.Initiative))
        {
            var targetsWithDamages = groups.Values
                .Where(o => o.Army != group.Army && !targets.Values.Contains(o.Id))
                .Select(o => (o, o.PossibleDamage(group)))
                .Where(o => o.Item2 > 0)
                .ToList();

            if (targetsWithDamages.Count == 0)
                continue;

            var target = targetsWithDamages
                .OrderByDescending(o => o.Item2)
                .ThenByDescending(o => o.Item1.EffectivePower)
                .ThenByDescending(o => o.Item1.Initiative)
                .First().Item1;

            targets.Add(group.Id, target.Id);
        }
    }

    private static bool Attack(IDictionary<string, ImmuneSystemGroup> groups, Dictionary<string, string> targets)
    {
        var fightIsActive = true;
        var unitCountBefore = groups.Values.Sum(o => o.UnitCount);
        foreach (var attacker in groups.Values.OrderByDescending(o => o.Initiative))
        {
            if (fightIsActive)
            {
                if (groups.ContainsKey(attacker.Id) && targets.ContainsKey(attacker.Id) &&
                    groups.TryGetValue(targets[attacker.Id], out var defender))
                {
                    defender.Attack(attacker);

                    if (defender.UnitCount <= 0)
                        groups.Remove(defender.Id);
                }
            }

            fightIsActive = groups.GroupBy(o => o.Value.Army).Count() == 2;
        }

        var unitCount = groups.Values.Sum(o => o.UnitCount);
        if (unitCount == unitCountBefore)
            throw new StalemateException();

        targets.Clear();
        return fightIsActive;
    }

    private static IDictionary<string, ImmuneSystemGroup> Parse(string input, int boost)
    {
        var (immuneInput, infectionInput) = input.Split(LineBreaks.Double);
        List<ImmuneSystemGroup> groups =
        [
            .. ParseGroups(ImmuneSystemArmy.Immune, immuneInput, boost),
            .. ParseGroups(ImmuneSystemArmy.Infection, infectionInput, 0)
        ];

        return groups.ToDictionary(k => k.Id, v => v);
    }

    private static IEnumerable<ImmuneSystemGroup> ParseGroups(ImmuneSystemArmy army, string s, int boost)
    {
        var rows = s.Split(LineBreaks.Single).Skip(1);
        var counter = 0;
        foreach (var row in rows)
        {
            counter++;
            var id = $"{army}{counter}";
            var g = ParseGroup(id, army, row, boost);
            yield return g;
        }
    }

    private static ImmuneSystemGroup ParseGroup(string id, ImmuneSystemArmy army, string s, int boost)
    {
        var match = Regex.Match(s);
        var unitCount = int.Parse(match.Groups[1].Value);
        var hitPoints = int.Parse(match.Groups[2].Value);
        var immunitiesAndWeaknesses = ParseImmunitiesAndWeaknesses(match.Groups[3].Value);
        var immunities = immunitiesAndWeaknesses.immunities;
        var weaknesses = immunitiesAndWeaknesses.weaknesses;
        var damage = int.Parse(match.Groups[4].Value);
        var attackType = match.Groups[5].Value;
        var initiative = int.Parse(match.Groups[6].Value);
        return new ImmuneSystemGroup(army, id, unitCount, hitPoints, immunities, weaknesses, damage, attackType, initiative, boost);
    }

    private static (IList<string> immunities, IList<string> weaknesses) ParseImmunitiesAndWeaknesses(string s)
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

    public enum ImmuneSystemArmy
    {
        Immune,
        Infection
    }

    public class ImmuneSystemGroup(
        ImmuneSystemArmy army,
        string id,
        int unitCount,
        int hitPoints,
        IList<string> immunities,
        IList<string> weaknesses,
        int damage,
        string attackType,
        int initiative,
        int boost)
    {
        public ImmuneSystemArmy Army { get; } = army;
        public string Id { get; } = id;
        public int UnitCount { get; private set; } = unitCount;
        private readonly string _attackType = attackType;
        public int Initiative { get; } = initiative;

        public int EffectivePower => UnitCount * (damage + boost);

        public int PossibleDamage(ImmuneSystemGroup attacker)
        {
            if (immunities.Contains(attacker._attackType))
                return 0;

            var multiplier = weaknesses.Contains(attacker._attackType) ? 2 : 1;
            return attacker.EffectivePower * multiplier;
        }

        public void Attack(ImmuneSystemGroup attacker) => UnitCount -= PossibleDamage(attacker) / hitPoints;
    }

    private class StalemateException() : Exception("Stalemate!");
}