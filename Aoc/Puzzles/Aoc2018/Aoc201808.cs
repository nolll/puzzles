using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2018;

[Name("Memory Maneuver")]
public class Aoc201808 : AocPuzzle
{
    [Puzzle("9c669208d829c31c0fdab74511ee9b14")]
    public int Part1(string input) => ReadNode(Parse(input)).MetadataSum;

    [Puzzle("67f685a992923369c5d0aca6b658a5d0")]
    public int Part2(string input) => ReadNode(Parse(input)).Value;

    private static List<int> Parse(string input) => [.. input.Split(' ').Select(int.Parse)];

    private LicenseNode ReadNode(List<int> numbers)
    {
        var nodeCount = ReadAndRemove(numbers);
        var metadataCount = ReadAndRemove(numbers);

        var children = new List<LicenseNode>();
        for (var i = 0; i < nodeCount; i++)
        {
            children.Add(ReadNode(numbers));
        }

        var metadata = new List<int>();
        for (var i = 0; i < metadataCount; i++)
        {
            metadata.Add(ReadAndRemove(numbers));
        }

        return new LicenseNode(children, metadata);
    }

    private static int ReadAndRemove(List<int> numbers)
    {
        var val = numbers.First();
        numbers.RemoveAt(0);
        return val;
    }

    public class LicenseNode(IList<LicenseNode> children, IList<int> metadata)
    {
        private IList<LicenseNode> Children { get; } = children;
        private IList<int> Metadata { get; } = metadata;
        public int MetadataSum => Metadata.Sum() + Children.Sum(o => o.MetadataSum);
        public int Value => Children.Count == 0 ? Metadata.Sum() : Metadata.Sum(ChildNodeValue);

        private int ChildNodeValue(int nodeNumber)
        {
            var index = nodeNumber - 1;
            return Children.Count > index ? Children[index].Value : 0;
        }
    }
}