namespace App.Puzzles.Year2015.Day22
{
    public class WizardRpgEffect
    {
        public string Name { get; }
        public int Damage { get; }
        public int Armor { get; }
        public int Healing { get; }
        public int Recharge { get; }
        public int Timer { get; set; }

        public WizardRpgEffect(string name, int damage, int armor, int healing, int recharge, int timer)
        {
            Name = name;
            Damage = damage;
            Armor = armor;
            Healing = healing;
            Recharge = recharge;
            Timer = timer;
        }
    }
}