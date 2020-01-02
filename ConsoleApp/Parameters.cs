using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    public class Parameters
    {
        private readonly IDictionary<string, string> _dictionary;

        public int? Day { get; }
        public int? Year { get; }
        public bool ShowHelp { get; }

        public Parameters(IEnumerable<string> args)
        {
            _dictionary = GetDictionary(args);
            Day = GetDay();
            Year = GetYear();
            ShowHelp = GetShowHelp();
        }

        public Parameters(int? day = null, int? year = null, bool showHelp = false)
        {
            Day = day;
            Year = year;
            ShowHelp = showHelp;
        }

        private int? GetDay() => GetIntValue("-d", "--day");
        private int? GetYear() => GetIntValue("-y", "--year");
        private bool GetShowHelp() => GetBoolValue("-h", "--help") ?? false;

        private bool? GetBoolValue(params string[] keys)
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

        private int? GetIntValue(params string[] keys)
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

        private IDictionary<string, string> GetDictionary(IEnumerable<string> args)
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
}