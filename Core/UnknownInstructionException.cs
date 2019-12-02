using System;

namespace Core
{
    public class UnknownInstructionException : Exception
    {
        public UnknownInstructionException(int opCode)
            : base($"Unknown opcode: {opCode}")
        {
        }
    }
}