using NUnit.Framework;

namespace Core.Puzzles.Year2021.Day16;

public class Year2021Day16Tests
{
    [Test]
    public void Test1()
    {
        var result = BitsPacket.FromHex("D2FE28");

        Assert.That(result.Version, Is.EqualTo(6));
        Assert.That(result.Type, Is.EqualTo(4));
        Assert.That(result.LiteralValue, Is.EqualTo(2021));
        Assert.That(result.VersionSum, Is.EqualTo(6));
        Assert.That(result.SubPackets.Count, Is.EqualTo(0));
    }

    [Test]
    public void Test2()
    {
        var result = BitsPacket.FromHex("38006F45291200");

        Assert.That(result.Version, Is.EqualTo(1));
        Assert.That(result.Type, Is.EqualTo(6));
        Assert.That(result.LiteralValue, Is.EqualTo(null));
        Assert.That(result.SubPackets.Count, Is.EqualTo(2));
        Assert.That(result.SubPackets[0].LiteralValue, Is.EqualTo(10));
        Assert.That(result.SubPackets[1].LiteralValue, Is.EqualTo(20));
    }

    [Test]
    public void Test3()
    {
        var result = BitsPacket.FromHex("EE00D40C823060");

        Assert.That(result.Version, Is.EqualTo(7));
        Assert.That(result.Type, Is.EqualTo(3));
        Assert.That(result.LiteralValue, Is.EqualTo(null));
        Assert.That(result.SubPackets.Count, Is.EqualTo(3));
        Assert.That(result.SubPackets[0].LiteralValue, Is.EqualTo(1));
        Assert.That(result.SubPackets[1].LiteralValue, Is.EqualTo(2));
        Assert.That(result.SubPackets[2].LiteralValue, Is.EqualTo(3));
    }

    [TestCase("8A004A801A8002F478", 16)]
    [TestCase("620080001611562C8802118E34", 12)]
    [TestCase("C0015000016115A2E0802F182340", 23)]
    [TestCase("A0016C880162017C3686B18A3D4780", 31)]
    public void VersionSum(string hex, int expected)
    {
        var result = BitsPacket.FromHex(hex);

        Assert.That(result.VersionSum, Is.EqualTo(expected));
    }

    [TestCase("C200B40A82", 3)]
    [TestCase("04005AC33890", 54)]
    [TestCase("880086C3E88112", 7)]
    [TestCase("CE00C43D881120", 9)]
    [TestCase("D8005AC2A8F0", 1)]
    [TestCase("F600BC2D8F", 0)]
    [TestCase("9C005AC2F8F0", 0)]
    [TestCase("9C0141080250320F1802104A08", 1)]
    public void Value(string hex, long expected)
    {
        var result = BitsPacket.FromHex(hex);

        Assert.That(result.Value, Is.EqualTo(expected));
    }
}