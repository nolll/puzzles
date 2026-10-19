using System.Numerics;
using Pzl.Common;
using Pzl.Tools.Numbers;

namespace Pzl.Aoc.Puzzles.Aoc2021;

[Name("Packet Decoder")]
public class Aoc202116 : AocPuzzle
{
    [Puzzle("25c39d184ba82383f9e2854e892394d4")]
    public int Part1(string input) => Solve(input).VersionSum;

    [Puzzle("0c7656c225e533d843c1637c804609c8")]
    public BigInteger Part2(string input) => Solve(input).Value;
    
    public BitsPacket Solve(string hexString)
    {
        var charToBitString = Enumerable.Range(0, 16).ToDictionary(k => k.ToString("X")[0], v => Conversion.ToBinary(v).PadLeft(4, '0'));
        var binaryStrings = hexString.ToCharArray().Select(o => charToBitString[o]);
        return new BitsPacket(string.Concat(binaryStrings));
    }
    
    public class BitsPacket
    {
        public int Version { get; }
        public int Type { get; }
        public BigInteger? LiteralValue { get; }
        public List<BitsPacket> SubPackets { get; }
        private int BinaryLength { get; set; }

        public int VersionSum => Version + SubPackets.Sum(o => o.VersionSum);

        public BitsPacket(string binary)
        {
            SubPackets = [];
            Version = GetPacketVersion(binary);
            binary = ConsumeBinary(binary, 3);
            Type = GetPacketType(binary);
            binary = ConsumeBinary(binary, 3);

            if (Type == (int)PacketType.LiteralValue)
            {
                LiteralValue = GetLiteralValue(binary);
            }
            else
            {
                var lengthTypeId = binary[..1];
                binary = ConsumeBinary(binary, 1);

                if (lengthTypeId == "0")
                {
                    var subPacketLength = GetSubPacketLength(binary);
                    binary = ConsumeBinary(binary, 15);
                    var totalSubPacketBits = 0;

                    while (totalSubPacketBits < subPacketLength)
                    {
                        var subPacket = new BitsPacket(binary);
                        var binaryLength = subPacket.BinaryLength;
                        totalSubPacketBits += binaryLength;
                        binary = ConsumeBinary(binary, binaryLength);
                        SubPackets.Add(subPacket);
                    }
                }
                else
                {
                    var subPacketCount = GetSubPacketCount(binary);
                    binary = ConsumeBinary(binary, 11);
                    var i = 0;

                    while (i < subPacketCount)
                    {
                        var subPacket = new BitsPacket(binary);
                        var binaryLength = subPacket.BinaryLength;
                        binary = ConsumeBinary(binary, binaryLength);
                        SubPackets.Add(subPacket);
                        i++;
                    }
                }
            }
        }

        private string ConsumeBinary(string binary, int count)
        {
            BinaryLength += count;
            return binary[count..];
        }

        public BigInteger Value => Type switch
        {
            (int)PacketType.Sum => SubPackets.Aggregate((BigInteger)0, (a, b) => a + b.Value),
            (int)PacketType.Product => SubPackets.Aggregate((BigInteger)1, (a, b) => a * b.Value),
            (int)PacketType.Minimum => SubPackets.Min(o => o.Value),
            (int)PacketType.Maximum => SubPackets.Max(o => o.Value),
            (int)PacketType.LiteralValue => LiteralValue ?? 0,
            (int)PacketType.GreaterThan => SubPackets.First().Value > SubPackets.Last().Value ? 1 : 0,
            (int)PacketType.LessThan => SubPackets.First().Value < SubPackets.Last().Value ? 1 : 0,
            (int)PacketType.Equal => SubPackets.First().Value == SubPackets.Last().Value ? 1 : 0,
            _ => 0
        };

        private static int GetSubPacketCount(string binary) => Convert.ToInt32(binary[..11], 2);
        private static int GetSubPacketLength(string binary) => Convert.ToInt32(binary[..15], 2);
        private static int GetPacketVersion(string bitString) => Convert.ToInt32(bitString[..3], 2);
        private static int GetPacketType(string bitString) => Convert.ToInt32(bitString[..3], 2);

        private long GetLiteralValue(string binary)
        {
            var literalBinary = "";
            while (binary.Length > 0)
            {
                var isLast = binary.StartsWith('0');
                literalBinary += binary.Substring(1, 4);
                binary = ConsumeBinary(binary, 5);

                if (isLast)
                    break;
            }

            if (literalBinary.Length == 0)
                return 0;

            return Convert.ToInt64(literalBinary, 2);
        }
    }

    private enum PacketType
    {
        Sum = 0,
        Product = 1,
        Minimum = 2,
        Maximum = 3,
        LiteralValue = 4,
        GreaterThan = 5,
        LessThan = 6,
        Equal = 7
    }
}