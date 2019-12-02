using System;

namespace Core
{
    public class UnknownOpcodeException : Exception
    {
        public UnknownOpcodeException(int opCode)
            : base($"Unknown opcode: {opCode}")
        {
        }
    }
}