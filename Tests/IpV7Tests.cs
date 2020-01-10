using Core.IpV7;
using NUnit.Framework;

namespace Tests
{
    public class IpV7Tests
    {
        [TestCase("abba[mnop]qrst", true)]
        [TestCase("abcd[bddb]xyyx", false)]
        [TestCase("aaaa[qwer]tyui", false)]
        [TestCase("ioxxoj[asdfgh]zxcvbn", true)]
        public void SupportsTls(string ip, bool expected)
        {
            var ipTester = new IpTester();
            var result = ipTester.SupportsTls(ip);

            Assert.That(result, Is.EqualTo(result));
        }
    }
}