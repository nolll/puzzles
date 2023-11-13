using FluentAssertions;
using NUnit.Framework;

namespace Puzzles.common.Compression;

public class HuffmanCompressionTests
{
    private const string Charset = "A_DEAD_DAD_CEDED_A_BAD_BABE_A_BEADED_ABACA_BED";

    [Test]
    public void Encode()
    {
        var result = new HuffmanCompression(Charset).Encode("CEDED");

        result.Should().Be("11101100011000");
    }

    [Test]
    public void Decode()
    {
        var result = new HuffmanCompression(Charset).Decode("11101100011000");

        result.Should().Be("CEDED");
    }

    [Test]
    public void GetNodes()
    {
        var result = new HuffmanCompression(Charset).Nodes;

        result[0].Key.Should().Be("C");
        result[0].Weight.Should().Be(2);
        result[1].Key.Should().Be("B");
        result[1].Weight.Should().Be(6);
        result[2].Key.Should().Be("E");
        result[2].Weight.Should().Be(7);
        result[3].Key.Should().Be("D");
        result[3].Weight.Should().Be(10);
        result[4].Key.Should().Be("_");
        result[4].Weight.Should().Be(10);
        result[5].Key.Should().Be("A");
        result[5].Weight.Should().Be(11);
    }

    [Test]
    public void JoinNodes()
    {
        var result = new HuffmanCompression(Charset).Tree;

        result.Count.Should().Be(1);
        result[0].Key.Should().Be("D_AECB");
        result[0].Weight.Should().Be(46);
    }

    [Test]
    public void GetCharCodes()
    {
        var result = new HuffmanCompression(Charset).Encoding;

        result["D"].Should().Be("00");
        result["_"].Should().Be("01");
        result["A"].Should().Be("10");
        result["E"].Should().Be("110");
        result["C"].Should().Be("1110");
        result["B"].Should().Be("1111");
    }
}