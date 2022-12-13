using System;
using System.Collections.Generic;
using System.Linq;
using Core.Common.Strings;

namespace Core.Puzzles.Year2022.Day13;

public class DistressSignal
{
    public int Part1(string input)
    {
        var lineGroups = PuzzleInputReader.ReadLineGroups(input);
        var pairs = lineGroups.Select(o => ParsePair(o[0], o[1])).ToList();

        var compares = pairs.Select(o => o.Compare()).ToList();

        var indexSum = 0;
        for (var i = 0; i < pairs.Count; i++)
        {
            var result = pairs[i].Compare();
            //Console.WriteLine($"{pairs[i].Left.Print()} {pairs[i].Right.Print()} {result}");

            if (compares[i] < 0)
                indexSum += i + 1;
        }

        return indexSum;
    }

    public int Part2(string input)
    {
        var lines = PuzzleInputReader.ReadLines(input, false);
        var items = lines.Select(ParseSignalItem).ToList();
        var dividerItem1 = ParseSignalItem("[[2]]");
        dividerItem1.IsDivider = true;
        var dividerItem2 = ParseSignalItem("[[6]]");
        dividerItem2.IsDivider = true;
        items.Add(dividerItem1);
        items.Add(dividerItem2);

        items.Sort(SignalPair.Compare);

        var indexProduct = 1;
        for (var i = 0; i < items.Count; i++)
        {
            if (items[i].IsDivider)
                indexProduct *= (i + 1);
        }

        return indexProduct;
    }

    private SignalPair ParsePair(string first, string second)
    {
        var a = ParseSignalItem(first);
        var b = ParseSignalItem(second);
        return new SignalPair(a, b);
    }

    public SignalItem ParseSignalItem(string input)
    {
        var rootItem = new SignalItem(null);
        var item = rootItem;
        var s = input.Substring(1, input.Length - 2).Replace("10", "A");

        for (var i = 0; i < s.Length; i++)
        {
            if (s[i] == '[')
            {
                var newItem = new SignalItem(item);
                item.List.Add(newItem);
                item = newItem;
            }
            else if (s[i] == ',')
            {
            }
            else if (s[i] == ']')
            {
                item = item.Parent;
            }
            else
            {
                var newItem = new SignalItem(item);
                var v = s[i] == 'A' ? 10 : int.Parse(s[i].ToString()); 
                newItem.Value = v;
                item.List.Add(newItem);
            }
        }

        return item;
    }
}