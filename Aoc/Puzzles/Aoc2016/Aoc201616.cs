using System.Text;
using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2016;

[Name("Dragon Checksum")]
public class Aoc201616 : AocPuzzle
{
    [Puzzle("14684ecac7686be656974d19fb659532")]
    public string Part1(string input) => new DragonCurve().Run(input, 272);

    [Puzzle("e5cc9c18ff1145ba041c85c6de72c9e2")]
    public string Part2(string input) => new DragonCurve().Run(input, 35651584);
    
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
}