namespace Aoc.Puzzles.Aoc2019.Day06;

public class Body
{
    private readonly string _name;
    public Body? Parent { get; set; }

    public Body(string name)
    {
        _name = name;
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
                return _name;

            return $"{Parent.ParentPath}|{_name}";
        }
    }
}