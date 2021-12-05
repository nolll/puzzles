namespace ConsoleApp.Puzzles.Year2016.Puzzles.Day11
{
    public class Microchip : RadioisotopeItem
    {
        public override RadioisotopeType Type => RadioisotopeType.Microchip;

        public Microchip(string name) : base(name)
        {
        }
    }
}