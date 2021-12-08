using System.Linq;

namespace App.Puzzles.Year2016.Day11
{
    public abstract class RadioisotopeItem
    {
        public string Name { get; }
        public abstract RadioisotopeType Type { get; }

        protected RadioisotopeItem(string name)
        {
            Name = name;
        }

        public string Id
        {
            get
            {
                var n = Name.ToUpper().First();
                var t = Type.ToString().ToUpper().First();
                return string.Concat(n, t);
            }
        }
    }
}