using System;

namespace Core.Tools.Assembunny
{
    public abstract class AssembunnyInstruction
    {
        public abstract void Execute();
        public abstract AssembunnyInstructionType Type { get; }
        public abstract string Name { get; }
    }
}