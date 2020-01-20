namespace Core.Radioisotope
{
    public class Generator : RadioisotopeItem
    {
        public override RadioisotopeType Type => RadioisotopeType.Generator;

        public Generator(string name) : base(name)
        {
        }
    }
}