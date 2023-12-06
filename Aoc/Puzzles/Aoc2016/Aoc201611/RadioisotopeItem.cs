namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201611;

public abstract class RadioisotopeItem
{
    public string Name { get; }
    public int Index { get; }
    public RadioisotopeType Type { get; }
    public string Id { get; }

    protected RadioisotopeItem(string name, int index, RadioisotopeType type)
    {
        Name = name;
        Index = index;
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