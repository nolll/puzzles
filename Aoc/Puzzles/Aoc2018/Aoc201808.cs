using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2018;

[Name("Memory Maneuver")]
public class Aoc201808 : AocPuzzle
{
    [Puzzle("9c669208d829c31c0fdab74511ee9b14")]
    public int Part1(string input) => new LicenseNumberCalculator(input).MetadataSum;

    [Puzzle("67f685a992923369c5d0aca6b658a5d0")]
    public int Part2(string input) => new LicenseNumberCalculator(input).RootNodeValue;
    
    public class LicenseNumberCalculator
    {
        private readonly List<int> _numbers;

        public int MetadataSum { get; }
        public int RootNodeValue { get; }

        public LicenseNumberCalculator(string input)
        {
            _numbers = input.Split(' ').Select(int.Parse).ToList();

            var rootNode = ReadNode();
            MetadataSum = rootNode.MetadataSum;
            RootNodeValue = rootNode.Value;
        }

        private LicenseNode ReadNode()
        {
            var nodeCount = ReadAndRemove();
            var metadataCount = ReadAndRemove();

            var children = new List<LicenseNode>();
            for (var i = 0; i < nodeCount; i++)
            {
                children.Add(ReadNode());
            }

            var metadata = new List<int>();
            for (var i = 0; i < metadataCount; i++)
            {
                metadata.Add(ReadAndRemove());
            }

            return new LicenseNode(children, metadata);
        }

        private int ReadAndRemove()
        {
            var val = _numbers.First();
            _numbers.RemoveAt(0);
            return val;
        }
    }
    
    public class LicenseNode
    {
        public IList<LicenseNode> Children { get; }
        public IList<int> Metadata { get; }
        public int MetadataSum => Metadata.Sum() + Children.Sum(o => o.MetadataSum);

        public LicenseNode(IList<LicenseNode> children, IList<int> metadata)
        {
            Children = children;
            Metadata = metadata;
        }

        public int Value
        {
            get
            {
                if (Children.Count == 0)
                    return Metadata.Sum();

                return Metadata.Sum(ChildNodeValue);
            }
        }

        private int ChildNodeValue(int nodeNumber)
        {
            var index = nodeNumber - 1;
            if (Children.Count > index)
                return Children[index].Value;
            return 0;
        }
    }
}