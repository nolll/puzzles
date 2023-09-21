using System.Collections.Generic;
using System.Linq;

namespace Aoc.Puzzles.Year2022.Day13;

public class SignalItem
{
    public int? Value { get; set; }
    public IList<SignalItem> List { get; set; }
    public SignalItem Parent { get; set; }
    public bool IsDivider { get; set; }

    public SignalItem(SignalItem parent)
    {
        Parent = parent;
        List = new List<SignalItem>();
    }

    public string Print()
    {
        if (Value != null)
            return Value.ToString();
        
        return $"[{string.Join(',', List.Select(o => o.Print()))}]";
    }

    public bool IsListItem => Value == null;
    public bool IsValueItem => Value != null;
}