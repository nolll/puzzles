using System;

namespace Core.RpgSimulation
{
    public abstract class RpgCharacter
    {
        public string Name { get; }
        public int Points { get; private set; }
        public int Damage { get; }
        public int Armor { get; }

        public bool IsAlive => Points > 0;

        protected RpgCharacter(string name, in int points, in int damage, in int armor)
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
}