namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202108;

public class DigitDecoder
{
    private readonly List<string> _signals;
    private readonly List<string> _output;

    public DigitDecoder(string input)
    {
        var parts = input.Split('|');
        _signals = ParseStringList(parts[0]);
        _output = ParseStringList(parts[1]);
    }

    private static List<string> ParseStringList(string input) => input
        .Trim()
        .Split(' ')
        .Select(o => string.Concat(o.OrderBy(c => c)))
        .ToList();

    public int EasyNumberCount
    {
        get
        {
            var c = 0;
            foreach (var i in _output)
            {
                var length = i.Length;
                if (length is 2 or 3 or 4 or 7)
                    c++;
            }

            return c;
        }
    }

    public int DecodedNumber
    {
        get
        {
            var s = new Dictionary<int, string?>
            {
                {0, null},
                {1, _signals.Single(o => o.Length == 2)},
                {2, null},
                {3, null},
                {4, _signals.Single(o => o.Length == 4)},
                {5, null},
                {6, null},
                {7, _signals.Single(o => o.Length == 3)},
                {8, _signals.Single(o => o.Length == 7)},
                {9, null},
            };

            var len6 = _signals.Where(o => o.Length == 6).ToList();
            var len5 = _signals.Where(o => o.Length == 5).ToList();

            s[3] = len5.Single(o => IsSubsetOf(s[1], o));
            len5.Remove(s[3]!);

            s[6] = len6.Single(o => !IsSubsetOf(s[1], o));
            len6.Remove(s[6]!);

            s[9] = len6.Single(o => IsSubsetOf(s[3], o));
            len6.Remove(s[9]!);
                
            s[0] = len6.Single();
                
            s[5] = len5.Single(o => IsSubsetOf(o, s[9]));
            len5.Remove(s[5]!);
                
            s[2] = len5.Single();
                
            var segmentToString = s.Keys.ToDictionary(key => s[key]!.ToString());
            var digits = _output.Select(o => segmentToString[o]);
            var str = string.Join("", digits);

            return int.Parse(str);
        }
    }

    public static bool IsSubsetOf(string? sShort, string? sLong) =>
        sShort is not null &&
        sLong is not null &&
        sShort.All(s => sLong.IndexOf(s) != -1);
}