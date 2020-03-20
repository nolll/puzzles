namespace Core.RpgSimulation
{
    public class RpgBoss : RpgCharacter
    {
        public RpgBoss(in int points, in int damage, in int armor) 
            : base("boss", in points, in damage, in armor)
        {
        }
    }
}