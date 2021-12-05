namespace ConsoleApp.Puzzles.Year2015.Puzzles.Day22
{
    public class WizardRpgPlayer : WizardRpgCharacter
    {
        public int Mana { get; set; }

        public WizardRpgPlayer(int mana, in int points, in int damage)
            : base(in points, in damage)
        {
            Mana = mana;
        }
    }
}