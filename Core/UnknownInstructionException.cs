using System;

namespace Core
{
    public class UnknownInstructionException : Exception
    {
        public UnknownInstructionException()
            : base("Unknown instruction")
        {
        }
    }
}