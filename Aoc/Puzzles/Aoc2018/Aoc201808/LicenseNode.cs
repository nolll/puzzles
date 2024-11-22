namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201808;

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