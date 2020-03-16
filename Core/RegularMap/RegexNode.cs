using System.Collections.Generic;

namespace Core.RegularMap
{
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
}