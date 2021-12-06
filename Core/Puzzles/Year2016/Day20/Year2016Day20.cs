using Core.PuzzleClasses;

namespace Core.Puzzles.Year2016.Day20
{
    public class Year2016Day20 : Year2016Day
    {
        public override int Day => 20;

        public override PuzzleResult RunPart1()
        {
            var rules = new FirewallRules(FileInput);
            var ip = rules.GetLowestUnblockedIp();
            return new PuzzleResult(ip, 14_975_795);
        }

        public override PuzzleResult RunPart2()
        {
            var rules = new FirewallRules(FileInput);
            var ipCount = rules.GetAllowedIpCount(Upperbound);
            return new PuzzleResult(ipCount, 101);
        }

        private const long Upperbound = 4_294_967_295;
    }
}