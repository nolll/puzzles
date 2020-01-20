namespace Core.Radioisotope
{
    public class Microchip : RadioisotopeItem
    {
        public override RadioisotopeType Type => RadioisotopeType.Microchip;

        public Microchip(string name) : base(name)
        {
        }
    }
}