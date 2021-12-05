namespace ConsoleApp.Puzzles.Year2019.Puzzles.Day06
{
    public class Body
    {
        public string Name { get; }
        public Body Parent { get; set; }

        public Body(string name)
        {
            Name = name;
        }

        public int OrbitCount
        {
            get
            {
                if (Parent == null)
                    return 0;
                return Parent.OrbitCount + 1;
            }
        }

        public string ParentPath
        {
            get
            {
                if (Parent == null)
                    return Name;
                return $"{Parent.ParentPath}|{Name}";
            }
        }
    }
}