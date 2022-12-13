using System.Collections.Generic;
using System.Linq;

namespace Core.Puzzles.Year2022.Day13;

public class SignalItem
{
    public int? Value { get; set; }
    public IList<SignalItem> List { get; set; }
    public SignalItem Parent { get; set; }

    public SignalItem(SignalItem parent)
    {
        Parent = parent;
        List = new List<SignalItem>();
    }

    public string Print()
    {
        if (Value != null)
            return Value.ToString();

        //if (List.Count == 1 && List.First().Value != null)
        //    return List.First().Print();

        return $"[{string.Join(',', List.Select(o => o.Print()))}]";
    }
}