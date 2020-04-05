namespace Core.Tools.Assembunny
{
    public class DecrementInstruction : AssembunnyInstruction
    {
        private readonly AssembunnyComputer _control;
        private readonly char _target;

        public DecrementInstruction(AssembunnyComputer control, char target)
        {
            _control = control;
            _target = target;
        }

        public override void Execute()
        {
            _control.Decrement(_target);
        }

        public override AssembunnyInstructionType Type => AssembunnyInstructionType.OneArgument;
    }
}