using System.Linq;
using System.Text;
using Core.OneTimePad;
using Core.Tools;
using NUnit.Framework;

namespace Tests
{
    public class OneTimePadTests
    {
        [Test]
        public void GeneratesCorrectKeys()
        {
            var generator = new KeyGenerator();
            var index = generator.GetIndexOf64ThKey("abc");

            Assert.That(index, Is.EqualTo(22728));
        }

        [Test]
        public void GeneratesCorrectStretchedKeys()
        {
            var generator = new KeyGenerator();
            var index = generator.GetIndexOf64ThKey("abc", 2016);

            Assert.That(index, Is.EqualTo(22551));
        }

        [TestCase(0, "577571be4de9dcce85a041ba0410f29f")]
        [TestCase(1, "eec80a0c92dc8a0777c619d9bb51e910")]
        [TestCase(2, "16062ce768787384c81fe17a7a60c7e3")]
        [TestCase(2016, "a107ff634856bb300138cac6568c0f24")]
        public void StretchedHash(int iterations, string expected)
        {
            var generator = new KeyGenerator();
            var hashedBytes = generator.CreateStretchedHash("abc0", iterations);
            var hash = ByteConverter.ConvertToString(hashedBytes);
            
            Assert.That(hash, Is.EqualTo(expected));
        }

        [TestCase("aaa01010101010101010", 'a')]
        [TestCase("bbaaab10101010101010", 'a')]
        [TestCase("bbaaabbbb01010101010", 'a')]
        [TestCase("bbaab010101010101010", null)]
        public void RepeatedChars(string str, char? expected)
        {
            var generator = new KeyGenerator();
            var b = generator.GetRepeatingChar(Encoding.ASCII.GetBytes(str));
            char? s = b != null ? (char)b.Value : null;

            Assert.That(s, Is.EqualTo(expected));
        }

        [TestCase("10101aaaaa1010101010", true)]
        [TestCase("aaaaa010101010101010", true)]
        [TestCase("bbaaaaaa101010101010", true)]
        [TestCase("bbaab010101010101010", false)]
        public void FiveInARow(string str, bool expected)
        {
            var generator = new KeyGenerator();
            var searchFor = Encoding.ASCII.GetBytes("a").First();
            var hasFiveInARow = generator.HashHasFiveInARowOf(Encoding.ASCII.GetBytes(str), searchFor);

            Assert.That(hasFiveInARow, Is.EqualTo(expected));
        }

        [Test]
        public void Index39IsAKey()
        {
            var generator = new KeyGenerator();
            const string salt = "abc";
            const int index = 39;
            var hashedBytes = generator.GetHash(salt, index, 0);
            var isKey = generator.IsKey(salt, index, hashedBytes, 0);

            Assert.That(isKey, Is.True);
        }
    }
}