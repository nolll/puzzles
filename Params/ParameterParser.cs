namespace Pzl.Client.Params;

public class ParameterParser(IEnumerable<string> args)
{
    private readonly Dictionary<string, string?> _dictionary = CreateDictionary(args);

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

    public List<string> GetListValue(params string[] keys)
    {
        var val = GetValue(keys);
        if (val == null)
            return new List<string>();

        return val.Split(',').ToList();
    }

    public string? GetValue(params string[] keys)
    {
        foreach (var key in keys)
        {
            if (!_dictionary.ContainsKey(key))
                continue;

            return _dictionary.TryGetValue(key, out var val)
                ? val 
                : "";
        }

        return null;
    }

    private static Dictionary<string, string?> CreateDictionary(IEnumerable<string> args)
    {
        var argsList = args.ToList();
        var dictionary = new Dictionary<string, string?>();
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