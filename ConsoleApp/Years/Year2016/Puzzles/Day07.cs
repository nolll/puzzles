using System;
using Core.IpV7;

namespace ConsoleApp.Years.Year2016.Puzzles
{
    public class Day07 : Day2016
    {
        public Day07() : base(7)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var tester = new IpTester();
            var tlsSupportCount = tester.TlsSupportCount(FileInput);
            Console.WriteLine($"Valid tls ip addresses: {tlsSupportCount}");

            WritePartTitle();
            var sslSupportCount = tester.SslSupportCount(FileInput);
            Console.WriteLine($"Valid ssl ip addresses: {sslSupportCount}");
        }
    }
}