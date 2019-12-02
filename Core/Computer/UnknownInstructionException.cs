using System;

namespace Core.Computer
{
    public class UnknownInstructionException : Exception
    {
        public UnknownInstructionException()
            : base("Unknown instruction")
        {
        }
    }
}