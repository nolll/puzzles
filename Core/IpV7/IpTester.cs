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
            var part1HasAbba = HasAbba(parts[0]);
            var part2HasAbba = HasAbba(parts[1]);
            var part3HasAbba = HasAbba(parts[2]);

            return part1HasAbba && part3HasAbba && !part2HasAbba;
        }

        private bool HasAbba(string s)
        {
            for (var i = 0; i < s.Length - 4; i++)
            {
                var test = s.Substring(i, 4);
                if (test[0] == test[3] && test[1] == test[2] && test[0] != test[1])
                    return true;
            }

            return false;
        }
    }
}