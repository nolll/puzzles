using Pzl.Aoc.Puzzles.Aoc2016;
using Pzl.Tools.Strings;

namespace Tests.Aoc.Aoc2016;

public class Aoc201614Tests : PuzzleTest<Aoc201614>
{
    [Fact]
    public void GeneratesCorrectKeys() => Sut.GetIndexOfNThKey(0, "abc", 64).Should().Be(22728);

    [Fact]
    public void GeneratesCorrectStretchedKeys() => Sut.GetIndexOfNThKey(10, "abc", 64).Should().Be(12665);

    [Theory]
    [InlineData(0, "577571be4de9dcce85a041ba0410f29f")]
    [InlineData(1, "eec80a0c92dc8a0777c619d9bb51e910")]
    [InlineData(2, "16062ce768787384c81fe17a7a60c7e3")]
    [InlineData(10, "8de2bfc94801e26c8c6729bd30d5c952")]
    public void StretchedHash(int stretchCount, string expected)
    {
        var hashedBytes = Sut.CreateHash(Sut.BuildByteCache(), stretchCount, "abc0");
        ByteConverter.ToString(hashedBytes).Should().Be(expected);
    }

    [Theory]
    [InlineData("aaa01010101010101010", 'a')]
    [InlineData("bbaaab10101010101010", 'a')]
    [InlineData("bbaaabbbb01010101010", 'a')]
    [InlineData("bbaab010101010101010", byte.MinValue)]
    public void RepeatedChars(string str, char expected)
    {
        var byteHash = str.ToCharArray().Select(o => (byte)o).ToArray();
        Sut.TryGetRepeatingByte(byteHash, out var c);
        c.Should().Be((byte)expected);
    }
    
    [Theory]
    [InlineData("aaaaa010101010101010", true)]
    [InlineData("bbaaaaaa101010101010", true)]
    [InlineData("101011010101010aaaaa", true)]
    [InlineData("bbaab010101010101010", false)]
    public void ByteHashFiveInARowOf(string stringHash, bool expected)
    {
        var byteHash = stringHash.ToCharArray().Select(o => (byte)o).ToArray();
        Sut.HasFiveInARowOf(byteHash, (byte)'a').Should().Be(expected);
    }
}