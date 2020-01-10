using System;
using System.Linq;
using Core.Tools;

namespace Core.IpV7
{
    public class IpTester
    {
        public int SupportCount(string input)
        {
            var ips = PuzzleInputReader.Read(input);
            return ips.Count(SupportsTls);
        }

        public bool SupportsTls(string ip)
        {
            var parts = ip.Split(new[] { "[", "]" }, StringSplitOptions.None).ToList();
            var index = 0;
            var hasAbbaOutsideBrackets = false;
            var hasAbbaInsideBrackets = false;
            foreach (var part in parts)
            {
                var hasAbba = HasAbba(part);
                if (hasAbba)
                {
                    if (!hasAbbaOutsideBrackets && index % 2 == 0)
                        hasAbbaOutsideBrackets = true;

                    if (!hasAbbaInsideBrackets && index % 2 != 0)
                        hasAbbaInsideBrackets = true;
                }

                index += 1;
            }

            return hasAbbaOutsideBrackets && !hasAbbaInsideBrackets;
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
    }
}