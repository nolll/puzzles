using System;

namespace Core.WizardRpgSimulation
{
    public abstract class WizardRpgCharacter
    {
        public int Points { get; private set; }
        public int Damage { get; }

        public bool IsAlive => Points > 0;

        protected WizardRpgCharacter(in int points, in int damage)
        {
            Points = points;
            Damage = damage;
        }

        public bool Hurt(int attack)
        {
            Points -= attack;
            return IsAlive;
        }
    }
}