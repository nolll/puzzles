using NUnit.Framework;
using System.Linq;

namespace Common.Compression;

public class HuffmanCompressionTests
{
    private const string Charset = "A_DEAD_DAD_CEDED_A_BAD_BABE_A_BEADED_ABACA_BED";

    [Test]
    public void Encode()
    {
        var result = new HuffmanCompression(Charset).Encode("CEDED");

        Assert.That(result, Is.EqualTo("11101100011000"));
    }

    [Test]
    public void Decode()
    {
        var result = new HuffmanCompression(Charset).Decode("11101100011000");

        Assert.That(result, Is.EqualTo("CEDED"));
    }

    [Test]
    public void GetNodes()
    {
        var result = new HuffmanCompression(Charset).Nodes;

        Assert.That(result[0].Key, Is.EqualTo("C"));
        Assert.That(result[0].Weight, Is.EqualTo(2));
        Assert.That(result[1].Key, Is.EqualTo("B"));
        Assert.That(result[1].Weight, Is.EqualTo(6));
        Assert.That(result[2].Key, Is.EqualTo("E"));
        Assert.That(result[2].Weight, Is.EqualTo(7));
        Assert.That(result[3].Key, Is.EqualTo("D"));
        Assert.That(result[3].Weight, Is.EqualTo(10));
        Assert.That(result[4].Key, Is.EqualTo("_"));
        Assert.That(result[4].Weight, Is.EqualTo(10));
        Assert.That(result[5].Key, Is.EqualTo("A"));
        Assert.That(result[5].Weight, Is.EqualTo(11));
    }

    [Test]
    public void JoinNodes()
    {
        var result = new HuffmanCompression(Charset).Tree;

        Assert.That(result.Count, Is.EqualTo(1));
        Assert.That(result[0].Key, Is.EqualTo("D_AECB"));
        Assert.That(result[0].Weight, Is.EqualTo(46));
    }

    [Test]
    public void GetCharCodes()
    {
        var result = new HuffmanCompression(Charset).Encoding;

        Assert.That(result["D"], Is.EqualTo("00"));
        Assert.That(result["_"], Is.EqualTo("01"));
        Assert.That(result["A"], Is.EqualTo("10"));
        Assert.That(result["E"], Is.EqualTo("110"));
        Assert.That(result["C"], Is.EqualTo("1110"));
        Assert.That(result["B"], Is.EqualTo("1111"));
    }
}