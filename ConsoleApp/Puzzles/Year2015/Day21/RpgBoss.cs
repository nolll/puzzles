namespace ConsoleApp.Puzzles.Year2015.Day21
{
    public class RpgBoss : RpgCharacter
    {
        public RpgBoss(in int points, in int damage, in int armor)
            : base("boss", in points, in damage, in armor)
        {
        }
    }
}