using System.Collections.Generic;
using System.Linq;

namespace Aoc.ConsoleTools;

public class ParameterParser
{
    private readonly IDictionary<string, string> _dictionary;

    public ParameterParser(IEnumerable<string> args)
    {
        _dictionary = CreateDictionary(args);
    }

    public bool? GetBoolValue(params string[] keys)
    {
        var val = GetValue(keys);
        if (val == null)
            return false;

        if (val == "")
            return true;

        if (!bool.TryParse(val, out var target))
            return null;

        return target;
    }

    public int? GetIntValue(params string[] keys)
    {
        var val = GetValue(keys);
        if (val == null)
            return null;

        if (!int.TryParse(val, out var target))
            return null;

        return target;
    }

    private string GetValue(params string[] keys)
    {
        foreach (var key in keys)
        {
            if (_dictionary.ContainsKey(key))
            {
                if (_dictionary.TryGetValue(key, out var val))
                    return val;

                return "";
            }
        }

        return null;
    }

    private IDictionary<string, string> CreateDictionary(IEnumerable<string> args)
    {
        var argsList = args.ToList();
        var dictionary = new Dictionary<string, string>();
        for (var i = 0; i < argsList.Count; i++)
        {
            var item = argsList[i];
            var isKeyword = item.StartsWith("-");
            var value = argsList.Count > i + 1 ? argsList[i + 1] : "";
            var hasValue = !value?.StartsWith("-") ?? false;
            value = hasValue ? value : "";
            if (isKeyword)
            {
                dictionary.Add(item, value);
            }

            if (hasValue)
            {
                i++;
            }
        }

        return dictionary;
    }
}