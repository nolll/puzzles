using System.Collections.Generic;
using System.Linq;
using Core.Common.Strings;

namespace Core.Puzzles.Year2022.Day13;

public class DistressSignal
{
    public int Part1(string input)
    {
        var lineGroups = PuzzleInputReader.ReadLineGroups(input);
        var pairs = lineGroups.Select(o => ParsePair(o[0], o[1]));

        return 0;
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
        var s = input.Replace("10", "A").Substring(1, input.Length - 2);

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