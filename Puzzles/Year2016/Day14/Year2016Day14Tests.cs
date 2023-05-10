using Aoc.Common.Strings;
using NUnit.Framework;

namespace Aoc.Puzzles.Year2016.Day14;

public class Year2016Day14Tests
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

    [Test]
    public void TimeStretchedKeys()
    {
        var generator = new KeyGenerator();
        var index = generator.GetIndexOf64ThKey("abc", 100);

        Assert.That(index, Is.EqualTo(29087));
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
        var c = KeyGenerator.GetRepeatingChar(str);

        Assert.That(c, Is.EqualTo(expected));
    }

    [TestCase("10101aaaaa1010101010", true)]
    [TestCase("aaaaa010101010101010", true)]
    [TestCase("bbaaaaaa101010101010", true)]
    [TestCase("bbaab010101010101010", false)]
    public void FiveInARow(string str, bool expected)
    {
        var hasFiveInARow = new KeyGenerator().HashHasFiveInARowOf(str, 'a');

        Assert.That(hasFiveInARow, Is.EqualTo(expected));
    }

    [Test]
    public void Index39IsAKey()
    {
        var generator = new KeyGenerator();
        const string salt = "abc";
        const int index = 39;
        var hash = generator.GetHash(salt, index, 0);
        var isKey = generator.IsKey(salt, index, hash, 0);

        Assert.That(isKey, Is.True);
    }
}