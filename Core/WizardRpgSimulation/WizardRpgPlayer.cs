namespace Core.WizardRpgSimulation
{
    public class WizardRpgPlayer : WizardRpgCharacter
    {
        public int Mana { get; }

        public WizardRpgPlayer(int mana, in int points, in int damage)
            : base(in points, in damage)
        {
            Mana = mana;
        }
    }
}