namespace Puzzles.aoc.Puzzles.Aoc2022.Aoc202213;

public class SignalItem
{
    public int? Value { get; set; }
    public IList<SignalItem> List { get; }
    public SignalItem? Parent { get; }
    public bool IsDivider { get; set; }

    public SignalItem(SignalItem? parent)
    {
        Parent = parent;
        List = new List<SignalItem>();
    }

    public string Print() => Value is not null
        ? Value.Value.ToString()
        : $"[{string.Join(',', List.Select(o => o.Print()))}]";

    public bool IsListItem => Value == null;
    public bool IsValueItem => Value != null;
}