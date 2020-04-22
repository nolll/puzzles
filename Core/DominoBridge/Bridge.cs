namespace Core.DominoBridge
{
    public class Bridge
    {
        public int Strength { get; }
        public int Length { get; }

        public Bridge(int strength, int length)
        {
            Strength = strength;
            Length = length;
        }
    }
}