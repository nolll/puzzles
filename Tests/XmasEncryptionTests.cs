using Core.XmasEncryption;
using NUnit.Framework;

namespace Tests
{
    public class XmasEncryptionTests
    {
        [Test]
        public void FirstInvalidNumber()
        {
            const string input = @"
35
20
15
25
47
40
62
55
65
95
102
117
150
182
127
219
299
277
309
576";

            var port = new XmasPort(input, 5);
            var num = port.FindFirstInvalidNumber();

            Assert.That(num, Is.EqualTo(127));
        }
    }
}