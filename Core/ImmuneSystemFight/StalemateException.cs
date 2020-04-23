using System;

namespace Core.ImmuneSystemFight
{
    public class StalemateException : Exception
    {
        public StalemateException()
            : base("Stalemate!")
        {
        }
    }
}