using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Everybody.Puzzles.Ecs03.Ecs0301;

[Name("Scales, Bags and a Bit of a Mess")]
public class Ecs0301 : EverybodyStoryPuzzle
{
    [Puzzle("f53ab300aa62ab2e8a5e077d2166592a")]
    public int Part1(string input) => ParseDucks(input).Where(o => o.g > o.r && o.g > o.b).Sum(duck => duck.scale);

    [Puzzle("92c6e926b88305ce851562ac3de0460a")]
    public int Part2(string input)
    {
        var ducks = ParseDucks(input).ToArray();
        var maxShine = ducks.Select(o => o.s).Max();
        var darkest = ducks.Where(o => o.s == maxShine).OrderBy(o => o.r + o.g + o.b).First();
        return darkest.scale;
    }

    [Puzzle("223bb40782130b1addaa4909da48b31f")]
    public int Part3(string input)
    {
        var ducks = ParseDucks(input).ToArray();
        var buckets = new Dictionary<string, List<int>>
        {
            { "rm", [] },
            { "rs", [] },
            { "gm", [] },
            { "gs", [] },
            { "bm", [] },
            { "bs", [] }
        };

        foreach (var (scale, r, g, b, s) in ducks)
        {
            var cb = GetColorBucket(r, g, b);
            var sb = GetShineBucket(s);

            if (cb == null || sb == null)
                continue;

            buckets[$"{cb}{sb}"].Add(scale);
        }

        return buckets.Values.MaxBy(o => o.Count)?.Sum() ?? 0;
    }

    private static char? GetColorBucket(int r, int g, int b)
    {
        if (r > g && r > b) return 'r';
        if (g > r && g > b) return 'g';
        if (b > r && b > g) return 'b';
        return null;
    }

    private static char? GetShineBucket(int s) => s switch
    {
        <= 30 => 'm',
        >= 33 => 's',
        _ => null
    };

    private static IEnumerable<(int scale, int r, int g, int b, int s)> ParseDucks(string input) => 
        input.Split(LineBreaks.Single).Select(ParseLine);

    private static (int scale, int r, int g, int b, int s) ParseLine(string line)
    {
        var parts = line.Split(':');
        var scale = int.Parse(parts.First());
        var components = parts.Last().Split();
        var r = ToNumber(components[0]);
        var g = ToNumber(components[1]);
        var b = ToNumber(components[2]);
        var s = components.Length > 3 ? ToNumber(components[3]) : 0;

        return (scale, r, g, b, s);
    }

    private static int ToNumber(string rs) => Convert.ToInt32(string.Join("", ToNumber(rs.ToCharArray())), 2);
    private static IEnumerable<char> ToNumber(char[] chars) => chars.Select(c => char.IsUpper(c) ? '1' : '0');
}