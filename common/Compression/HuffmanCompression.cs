using System.Text;

namespace Common.Compression;

public class HuffmanCompression
{
    private readonly string _charset;
    public IList<Node> Nodes { get; }
    public IList<Node> Tree { get; }
    public IDictionary<string, string> Encoding { get; }
    public IDictionary<string, string> Decoding { get; }

    public HuffmanCompression(string charset)
    {
        _charset = charset;
        Nodes = GetNodes();
        Tree = BuildTree();
        Encoding = GetEncoding();
        Decoding = GetDecoding();
    }

    public string Encode(string input)
    {
        var s = new StringBuilder();

        foreach (var c in input)
        {
            s.Append(Encoding[c.ToString()]);
        }

        return s.ToString();
    }

    public string Decode(string input)
    {
        var current = "";
        var result = "";
        foreach (var c in input)
        {
            current += c;
            if (!Decoding.TryGetValue(current, out var decoded))
                continue;

            result += decoded;
            current = "";
        }

        return result;
    }

    private IList<Node> GetNodes()
        =>
            _charset.ToCharArray()
                .GroupBy(o => o)
                .Select(o => new Node(o.Key.ToString(), o.Count(), new List<Node>()))
                .OrderBy(o => o.Weight)
                .ThenBy(o => o.Key.First())
                .ToList();

    private IList<Node> BuildTree()
    {
        var list = Nodes.ToList();
        while (list.Count > 1)
        {
            var children = list.Take(2).ToList();
            var first = children.First();
            var second = children.Last();
            list = list.Skip(2).ToList();
            var node = new Node(string.Concat(first.Key, second.Key), first.Weight + second.Weight, children);
            var firstIndexWithHigherWeight = list.FindIndex(o => o.Weight > node.Weight);
            if(firstIndexWithHigherWeight > -1)
                list.Insert(firstIndexWithHigherWeight, node);
            else
                list.Add(node);
        }

        return list;
    }

    private IDictionary<string, string> GetEncoding()
    {
        var d = new Dictionary<string, string>();
        var queue = new Queue<(Node node, string path)>();
        queue.Enqueue((Tree.First(), ""));

        while (queue.Any())
        {
            var current = queue.Dequeue();
            if (current.node.Children.Count == 0)
            {
                d.Add(current.node.Key, current.path);
            }
            else
            {
                queue.Enqueue((current.node.Children.First(), current.path + "0"));
                queue.Enqueue((current.node.Children.Last(), current.path + "1"));
            }
        }

        return d;
    }

    private IDictionary<string, string> GetDecoding()
        => Encoding.ToDictionary(k => k.Value, v => v.Key);

    public record Node(string Key, int Weight, List<Node> Children);
}