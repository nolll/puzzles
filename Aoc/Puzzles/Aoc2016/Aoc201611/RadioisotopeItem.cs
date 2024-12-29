namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201611;

public abstract class RadioisotopeItem
{
    public string Name { get; }
    public RadioisotopeType Type { get; }
    public string Id { get; }

    protected RadioisotopeItem(string name, RadioisotopeType type)
    {
        Name = name;
        Type = type;
        Id = BuildId();
    }
    
    private string BuildId()
    {
        var n = Name.ToUpper().First();
        var t = Type.ToString().ToUpper().First();
        return string.Concat(n, t);
    }
}