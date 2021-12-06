using Core.PuzzleClasses;

namespace Core.Puzzles.Year2016.Day07
{
    public class Year2016Day07 : Year2016Day
    {
        public override int Day => 7;

        public override PuzzleResult RunPart1()
        {
            var tester = new IpTester();
            var tlsSupportCount = tester.TlsSupportCount(FileInput);
            return new PuzzleResult(tlsSupportCount, 105);
        }

        public override PuzzleResult RunPart2()
        {
            var tester = new IpTester();
            var sslSupportCount = tester.SslSupportCount(FileInput);
            return new PuzzleResult(sslSupportCount, 258);
        }
    }
}