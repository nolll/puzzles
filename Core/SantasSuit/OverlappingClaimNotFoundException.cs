using System;

namespace Core.SantasSuit
{
    public class OverlappingClaimNotFoundException : Exception
    {
        public OverlappingClaimNotFoundException()
            : base("No overlapping claim was found")
        {
        }
    }
}