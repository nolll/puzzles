namespace Puzzles.aoc.Puzzles.Aoc2018.Aoc201808;

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