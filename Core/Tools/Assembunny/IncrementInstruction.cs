namespace Core.Tools.Assembunny
{
    public class IncrementInstruction : AssembunnyInstruction
    {
        private readonly AssembunnyComputer _control;
        private readonly char _target;

        public IncrementInstruction(AssembunnyComputer control, char target)
        {
            _control = control;
            _target = target;
        }

        public override void Execute()
        {
            _control.Increment(_target);
        }

        public override AssembunnyInstructionType Type => AssembunnyInstructionType.OneArgument;
    }
}