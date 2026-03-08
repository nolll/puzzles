using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201607;

public class IpTester
{
    public int TlsSupportCount(string input) => input.Split(LineBreaks.Single).Count(SupportsTls);
    public int SslSupportCount(string input) => input.Split(LineBreaks.Single).Count(SupportsSsl);

    public bool SupportsTls(string ip)
    {
        var parts = ip.Split(["[", "]"], StringSplitOptions.None).ToList();
        var strOutsideBrackets = string.Join(' ', parts.Where((x, i) => i % 2 == 0));
        var strInsideBrackets = string.Join(' ', parts.Where((x, i) => i % 2 != 0));
        var hasAbbaOutsideBrackets = HasAbba(strOutsideBrackets);
        var hasAbbaInsideBrackets = HasAbba(strInsideBrackets);

        return hasAbbaOutsideBrackets && !hasAbbaInsideBrackets;
    }

    public bool SupportsSsl(string ip)
    {
        var parts = ip.Split(["[", "]"], StringSplitOptions.None).ToList();
        var strOutsideBrackets = string.Join(' ', parts.Where((_, i) => i % 2 == 0));
        var strInsideBrackets = string.Join(' ', parts.Where((_, i) => i % 2 != 0));
        var outsideAbas = GetAbas(strOutsideBrackets);
        var insideAbas = GetAbas(strInsideBrackets).ToList();

        return outsideAbas.Select(GetBab).Any(bab => insideAbas.Contains(bab));
    }

    private static string GetBab(string aba) => $"{aba[1]}{aba[0]}{aba[1]}";

    private static bool HasAbba(string s)
    {
        for (var i = 0; i < s.Length - 3; i++)
        {
            if (IsAbba(s.Substring(i, 4)))
                return true;
        }

        return false;
    }

    private static bool IsAbba(string test) => test[0] == test[3] && test[1] == test[2] && test[0] != test[1];

    private static IEnumerable<string> GetAbas(string s)
    {
        for (var i = 0; i < s.Length - 2; i++)
        {
            var test = s.Substring(i, 3);
            if (test[0] == test[2] && test[0] != test[1])
                yield return test;
        }
    }
}