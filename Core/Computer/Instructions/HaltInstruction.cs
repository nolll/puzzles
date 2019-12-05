namespace Core.Computer.Instructions
{
    public class HaltInstruction : Instruction
    {
        public override InstructionType Type => InstructionType.Halt;
    }
}