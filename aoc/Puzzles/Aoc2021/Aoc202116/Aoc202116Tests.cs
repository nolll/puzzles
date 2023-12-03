using System.Numerics;
using FluentAssertions;
using NUnit.Framework;

namespace Puzzles.Aoc.Puzzles.Aoc2021.Aoc202116;

public class Aoc202116Tests
{
    [Test]
    public void Test1()
    {
        var result = BitsPacket.FromHex("D2FE28");

        result.Version.Should().Be(6);
        result.Type.Should().Be(4);
        result.LiteralValue.Should().Be(new BigInteger(2021));
        result.VersionSum.Should().Be(6);
        result.SubPackets.Count.Should().Be(0);
    }

    [Test]
    public void Test2()
    {
        var result = BitsPacket.FromHex("38006F45291200");

        result.Version.Should().Be(1);
        result.Type.Should().Be(6);
        result.LiteralValue.Should().Be(null);
        result.SubPackets.Count.Should().Be(2);
        result.SubPackets[0].LiteralValue.Should().Be(new BigInteger(10));
        result.SubPackets[1].LiteralValue.Should().Be(new BigInteger(20));
    }

    [Test]
    public void Test3()
    {
        var result = BitsPacket.FromHex("EE00D40C823060");

        result.Version.Should().Be(7);
        result.Type.Should().Be(3);
        result.LiteralValue.Should().Be(null);
        result.SubPackets.Count.Should().Be(3);
        result.SubPackets[0].LiteralValue.Should().Be(new BigInteger(1));
        result.SubPackets[1].LiteralValue.Should().Be(new BigInteger(2));
        result.SubPackets[2].LiteralValue.Should().Be(new BigInteger(3));
    }

    [TestCase("8A004A801A8002F478", 16)]
    [TestCase("620080001611562C8802118E34", 12)]
    [TestCase("C0015000016115A2E0802F182340", 23)]
    [TestCase("A0016C880162017C3686B18A3D4780", 31)]
    public void VersionSum(string hex, int expected)
    {
        var result = BitsPacket.FromHex(hex);

        result.VersionSum.Should().Be(expected);
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

        result.Value.Should().Be(new BigInteger(expected));
    }
}