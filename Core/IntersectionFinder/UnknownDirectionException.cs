using System;

namespace Core.IntersectionFinder
{
    public class UnknownDirectionException : Exception
    {
        public UnknownDirectionException(char direction)
            : base($"Unknown direction: {direction}")
        {
        }
    }
}