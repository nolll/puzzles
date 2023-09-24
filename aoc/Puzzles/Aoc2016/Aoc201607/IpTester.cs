using System;
using System.Collections.Generic;
using System.Linq;
using Common.Strings;

namespace Aoc.Puzzles.Aoc2016.Aoc201607;

public class IpTester
{
    public int TlsSupportCount(string input)
    {
        var ips = PuzzleInputReader.ReadLines(input);
        return ips.Count(SupportsTls);
    }

    public int SslSupportCount(string input)
    {
        var ips = PuzzleInputReader.ReadLines(input);
        return ips.Count(SupportsSsl);
    }

    public bool SupportsTls(string ip)
    {
        var parts = ip.Split(new[] { "[", "]" }, StringSplitOptions.None).ToList();
        var strOutsideBrackets = string.Join(' ', parts.Where((x, i) => i % 2 == 0));
        var strInsideBrackets = string.Join(' ', parts.Where((x, i) => i % 2 != 0));
        var hasAbbaOutsideBrackets = HasAbba(strOutsideBrackets);
        var hasAbbaInsideBrackets = HasAbba(strInsideBrackets);

        return hasAbbaOutsideBrackets && !hasAbbaInsideBrackets;
    }

    public bool SupportsSsl(string ip)
    {
        var parts = ip.Split(new[] { "[", "]" }, StringSplitOptions.None).ToList();
        var strOutsideBrackets = string.Join(' ', parts.Where((x, i) => i % 2 == 0));
        var strInsideBrackets = string.Join(' ', parts.Where((x, i) => i % 2 != 0));
        var outsideAbas = GetAbas(strOutsideBrackets);
        var insideAbas = GetAbas(strInsideBrackets);

        foreach (var aba in outsideAbas)
        {
            var bab = GetBab(aba);
            if (insideAbas.Contains(bab))
                return true;
        }

        return false;
    }

    private string GetBab(string aba)
    {
        return string.Concat(new List<char>
        {
            aba[1],
            aba[0],
            aba[1]
        });
    }

    private bool HasAbba(string s)
    {
        for (var i = 0; i < s.Length - 3; i++)
        {
            var test = s.Substring(i, 4);
            if (test[0] == test[3] && test[1] == test[2] && test[0] != test[1])
                return true;
        }

        return false;
    }

    private IList<string> GetAbas(string s)
    {
        var abas = new List<string>();
        for (var i = 0; i < s.Length - 2; i++)
        {
            var test = s.Substring(i, 3);
            if (test[0] == test[2] && test[0] != test[1])
                abas.Add(test);
        }

        return abas;
    }
}