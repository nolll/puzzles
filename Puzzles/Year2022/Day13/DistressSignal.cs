using System.Collections.Generic;
using System.Linq;
using Aoc.Common.Strings;

namespace Aoc.Puzzles.Year2022.Day13;

public class DistressSignal
{
    public int Part1(string input)
    {
        var lineGroups = PuzzleInputReader.ReadLineGroups(input);
        var indexSum = 0;
        
        for (var i = 0; i < lineGroups.Count; i++)
        {
            var group = lineGroups[i];
            var left = ParseSignalItem(group.First());
            var right = ParseSignalItem(group.Last());
            var result = SignalComparer.Compare(left, right);

            if (result < 0)
                indexSum += i + 1;
        }

        return indexSum;
    }

    public int Part2(string input)
    {
        var lines = PuzzleInputReader.ReadLines(input, false);
        var items = lines.Select(ParseSignalItem).ToList();
        var dividerItems = CreateDividerItems();
        items.AddRange(dividerItems);
        items.Sort(SignalComparer.Compare);

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
                    item.List.Add(newItem);
                    item = newItem;
                    break;
                }
                case ',':
                    break;
                case ']':
                    item = item.Parent;
                    break;
                default:
                {
                    var newItem = new SignalItem(item);
                    var v = c == 'A' ? 10 : int.Parse(c.ToString()); 
                    newItem.Value = v;
                    item.List.Add(newItem);
                    break;
                }
            }
        }

        return item;
    }
}