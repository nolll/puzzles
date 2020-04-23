using System.Collections.Generic;

namespace Core.ImmuneSystemFight
{
    public class ImmuneSystemGroup
    {
        public ImmuneSystemArmy Army { get; }
        public string Id { get; }
        public int UnitCount { get; private set; }
        private readonly int _hitPoints;
        private readonly IList<string> _immunities;
        private readonly IList<string> _weaknesses;
        private readonly int _damage;
        private readonly string _attackType;
        private readonly int _boost;
        public int Initiative { get; }

        public int EffectivePower => UnitCount * (_damage + _boost);

        public ImmuneSystemGroup(
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
            Army = army;
            Id = id;
            UnitCount = unitCount;
            _hitPoints = hitPoints;
            _immunities = immunities;
            _weaknesses = weaknesses;
            _damage = damage;
            _attackType = attackType;
            _boost = boost;
            Initiative = initiative;
        }

        public int PossibleDamage(ImmuneSystemGroup attacker)
        {
            if (_immunities.Contains(attacker._attackType))
                return 0;

            var multiplier = _weaknesses.Contains(attacker._attackType) ? 2 : 1;
            return attacker.EffectivePower * multiplier;
        }

        public void Attack(ImmuneSystemGroup attacker)
        {
            var damage = PossibleDamage(attacker);
            var killedUnits = damage / _hitPoints;
            UnitCount -= killedUnits;
        }
    }
}