using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2022;

[Name("Distress Signal")]
public class Aoc202213 : AocPuzzle
{
    [Puzzle("b7ce4fc8127f3ae910077459ccdd2466")]
    public int Part1(string input)
    {
        var lineGroups = input
            .Split(LineBreaks.Double)
            .Select(o => o.Split(LineBreaks.Single).ToList())
            .ToList();
        
        var indexSum = 0;
        for (var i = 0; i < lineGroups.Count; i++)
        {
            var group = lineGroups[i];
            var left = ParseSignalItem(group.First());
            var right = ParseSignalItem(group.Last());
            var result = Compare(left, right);

            if (result < 0)
                indexSum += i + 1;
        }

        return indexSum;
    }

    [Puzzle("dae06225ebac50b689604b2ca86cfabf")]
    public int Part2(string input)
    {
        var items = input
            .Split(LineBreaks.Single)
            .Where(o => o.Length > 0)
            .Select(ParseSignalItem)
            .ToList();
        
        var dividerItems = CreateDividerItems();
        items.AddRange(dividerItems);
        items.Sort(Compare);

        var indexProduct = 1;
        for (var i = 0; i < items.Count; i++)
        {
            if (items[i].IsDivider)
                indexProduct *= (i + 1);
        }

        return indexProduct;
    }

    private IEnumerable<SignalItem> CreateDividerItems()
    {
        yield return CreateDividerItem(2);
        yield return CreateDividerItem(6);
    }

    private SignalItem CreateDividerItem(int id)
    {
        var dividerItem2 = ParseSignalItem($"[[{id}]]");
        dividerItem2.IsDivider = true;
        return dividerItem2;
    }

    public static SignalItem ParseSignalItem(string input)
    {
        var rootItem = new SignalItem(null);
        var item = rootItem;
        var s = input.Substring(1, input.Length - 2).Replace("10", "A"); // Replace double digit number with A to make parsing easier

        foreach (var c in s)
        {
            switch (c)
            {
                case '[':
                {
                    var newItem = new SignalItem(item);
                    item!.List.Add(newItem);
                    item = newItem;
                    break;
                }
                case ',':
                    break;
                case ']':
                    item = item!.Parent;
                    break;
                default:
                {
                    var newItem = new SignalItem(item);
                    var v = c == 'A' ? 10 : int.Parse(c.ToString());
                    newItem.Value = v;
                    item!.List.Add(newItem);
                    break;
                }
            }
        }

        return item!;
    }

    public static int Compare(SignalItem left, SignalItem right)
    {
        if (left.IsValueItem && right.IsValueItem)
        {
            if (left.Value > right.Value)
                return 1;
            if (left.Value < right.Value)
                return -1;
        }

        if (left.IsListItem && right.IsValueItem)
        {
            var newItem = new SignalItem(right);
            newItem.Value = right.Value;
            right.List.Add(newItem);
            right.Value = null;
        }

        if (left.IsValueItem && right.IsListItem)
        {
            var newItem = new SignalItem(left);
            newItem.Value = left.Value;
            left.List.Add(newItem);
            left.Value = null;
        }

        if (left.IsListItem && right.IsListItem)
        {
            for (var i = 0; i < left.List.Count; i++)
            {
                if (right.List.Count < i + 1)
                    return 1;

                var result = Compare(left.List[i], right.List[i]);
                if (result != 0)
                    return result;
            }

            if (left.List.Count < right.List.Count)
                return -1;
        }

        return 0;
    }

    public class SignalItem(SignalItem? parent)
    {
        public int? Value { get; set; }
        public IList<SignalItem> List { get; } = new List<SignalItem>();
        public SignalItem? Parent { get; } = parent;
        public bool IsDivider { get; set; }
        public bool IsListItem => Value == null;
        public bool IsValueItem => Value != null;
        
        public string Print() => Value is not null
            ? Value.Value.ToString()
            : $"[{string.Join(',', List.Select(o => o.Print()))}]";
    }
}