using System.Linq;
using System.Text;

namespace App.Puzzles.Year2016.Day16;

public class DragonCurve
{
    public string Run(string input, int diskSize)
    {
        var data = FillDisk(input, diskSize);
        return Checksum(data);
    }

    public string FillDisk(string s, int diskSize)
    {
        while (s.Length < diskSize)
        {
            s = ApplyAlgorithm(s);
        }

        return s.Substring(0, diskSize);
    }

    public string Checksum(string s)
    {
        while (s.Length % 2 == 0)
        {
            var sb = new StringBuilder();
            for (var i = 0; i < s.Length; i += 2)
            {
                var a = s[i];
                var b = s[i + 1];
                var v = a == b ? '1' : '0';
                sb.Append(v);
            }

            s = sb.ToString();
        }

        return s;
    }

    public string ApplyAlgorithm(string a)
    {
        var b = new StringBuilder();
        b.Append(a);
        b.Append('0');
        foreach (var c in a.Reverse())
        {
            var v = c == '1' ? '0' : '1';
            b.Append(v);
        }

        return b.ToString();
    }
}