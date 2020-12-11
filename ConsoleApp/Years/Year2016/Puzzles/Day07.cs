using System;
using Core.IpV7;

namespace ConsoleApp.Years.Year2016.Puzzles
{
    public class Day07 : Day2016
    {
        public Day07() : base(7)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var tester = new IpTester();
            var tlsSupportCount = tester.TlsSupportCount(FileInput);
            return new PuzzleResult($"Valid tls ip addresses: {tlsSupportCount}");
        }

        public override PuzzleResult RunPart2()
        {
            var tester = new IpTester();
            var sslSupportCount = tester.SslSupportCount(FileInput);
            return new PuzzleResult($"Valid ssl ip addresses: {sslSupportCount}");
        }
    }
}