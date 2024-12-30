using FluentAssertions;
using NUnit.Framework;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201614;

public class Aoc201614Tests
{
    [Test]
    public void GeneratesCorrectKeys()
    {
        var generator = new KeyGenerator(0);
        var index = generator.GetIndexOfNThKey("abc", 64);

        index.Should().Be(22728);
    }

    [Test]
    public void GeneratesCorrectStretchedKeys()
    {
        var generator = new KeyGenerator(10);
        var index = generator.GetIndexOfNThKey("abc", 64);

        index.Should().Be(12665);
    }
    
    [TestCase(0, "577571be4de9dcce85a041ba0410f29f")]
    [TestCase(1, "eec80a0c92dc8a0777c619d9bb51e910")]
    [TestCase(2, "16062ce768787384c81fe17a7a60c7e3")]
    [TestCase(10, "8de2bfc94801e26c8c6729bd30d5c952")]
    public void StretchedHash(int stretchCount, string expected)
    {
        var generator = new KeyGenerator(stretchCount);
        var hashedBytes = generator.CreateHash("abc0");
        var hash = ByteConverter.ToString(hashedBytes);
            
        hash.Should().Be(expected);
    }

    [TestCase("aaa01010101010101010", 'a')]
    [TestCase("bbaaab10101010101010", 'a')]
    [TestCase("bbaaabbbb01010101010", 'a')]
    [TestCase("bbaab010101010101010", byte.MinValue)]
    public void RepeatedChars(string str, char expected)
    {
        var byteHash = str.ToCharArray().Select(o => (byte)o).ToArray();
        KeyGenerator.TryGetRepeatingByte(byteHash, out var c);
        
        c.Should().Be((byte)expected);
    }
    
    [TestCase("aaaaa010101010101010", true)]
    [TestCase("bbaaaaaa101010101010", true)]
    [TestCase("101011010101010aaaaa", true)]
    [TestCase("bbaab010101010101010", false)]
    public void ByteHashFiveInARowOf(string stringHash, bool expected)
    {
        var byteHash = stringHash.ToCharArray().Select(o => (byte)o).ToArray();
        var hasFiveInARow = KeyGenerator.HasFiveInARowOf(byteHash, (byte)'a');

        hasFiveInARow.Should().Be(expected);
    }

    [Test]
    public void Index39IsAKey()
    {
        var generator = new KeyGenerator(0);
        const string salt = "abc";
        const int index = 39;
        var hash = generator.GetHash(salt, index);
        var isKey = generator.IsKey(salt, index, hash);

        isKey.Should().BeTrue();
    }
}