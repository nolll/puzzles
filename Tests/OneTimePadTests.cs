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

        [TestCase("aaa", 'a')]
        [TestCase("bbaaab", 'a')]
        [TestCase("bbaaabbbb", 'a')]
        [TestCase("bbaab", null)]
        public void RepeatedChars(string str, char? expected)
        {
            var generator = new KeyGenerator();
            var b = generator.GetRepeatingChar(Encoding.ASCII.GetBytes(str));
            char? s = b != null ? (char)b.Value : null;
            
            Assert.That(s, Is.EqualTo(expected));
        }
    }
}