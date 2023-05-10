using System.Collections.Generic;

namespace Aoc.Puzzles.Year2018.Day20;

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