using System.Collections.Generic;
using System.Linq;

namespace Core.NavigationSystemLicense
{
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
    }
}