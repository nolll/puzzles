namespace ConsoleApp.Puzzles.Year2016.Day11
{
    public class Generator : RadioisotopeItem
    {
        public override RadioisotopeType Type => RadioisotopeType.Generator;

        public Generator(string name) : base(name)
        {
        }
    }
}