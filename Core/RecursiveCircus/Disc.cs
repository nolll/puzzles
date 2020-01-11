using System.Collections.Generic;

namespace Core.RecursiveCircus
{
    public class Disc
    {
        public string Id { get; }
        public int Weight { get; }
        public IList<Disc> Children { get; }
        public IList<string> ChildrenIds { get; }
        public string ParentId { get; set; }

        public Disc(string id, int weight, IList<string> childrenIds)
        {
            Id = id;
            Weight = weight;
            ChildrenIds = childrenIds;
            Children = new List<Disc>();
        }
    }
}