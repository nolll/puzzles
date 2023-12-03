using System.Numerics;

namespace Puzzles.Aoc.Puzzles.Aoc2021.Aoc202116;

public class BitsPacket
{
    public int Version { get; }
    public int Type { get; }
    public BigInteger? LiteralValue { get; }
    public List<BitsPacket> SubPackets { get; }
    private int BinaryLength { get; set; }

    public int VersionSum => Version + SubPackets.Sum(o => o.VersionSum);

    private BitsPacket(string binary)
    {
        SubPackets = new List<BitsPacket>();
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

    public BigInteger Value
    {
        get
        {
            return Type switch
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
        }
    }

    private int GetSubPacketCount(string binary)
    {
        var s = binary[..11];
        return Convert.ToInt32(s, 2);
    }

    private int GetSubPacketLength(string binary)
    {
        var s = binary[..15];
        return Convert.ToInt32(s, 2);
    }

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

    private int GetPacketVersion(string bitString)
    {
        var s = bitString[..3];
        return Convert.ToInt32(s, 2);
    }

    private int GetPacketType(string bitString)
    {
        var s = bitString[..3];
        return Convert.ToInt32(s, 2);
    }

    public static BitsPacket FromHex(string hexString)
    {
        var binaryStrings = hexString.ToCharArray().Select(o => CharToBitString[o]);
        var binaryString = string.Join("", binaryStrings);
        return new BitsPacket(binaryString);
    }

    private static readonly Dictionary<char, string> CharToBitString = new()
    {
        { '0', "0000" },
        { '1', "0001" },
        { '2', "0010" },
        { '3', "0011" },
        { '4', "0100" },
        { '5', "0101" },
        { '6', "0110" },
        { '7', "0111" },
        { '8', "1000" },
        { '9', "1001" },
        { 'A', "1010" },
        { 'B', "1011" },
        { 'C', "1100" },
        { 'D', "1101" },
        { 'E', "1110" },
        { 'F', "1111" }
    };
}