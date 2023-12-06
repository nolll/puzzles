namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201820;

public class RegexNode
{
    public string Path { get; }
    public IList<RegexNode> Children { get; }

    public RegexNode(string path)
    {
        Path = path;
        Children = new List<RegexNode>();
    }
}