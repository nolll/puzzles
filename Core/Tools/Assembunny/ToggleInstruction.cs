namespace Core.Tools.Assembunny
{
    public class ToggleInstruction : AssembunnyInstruction
    {
        private readonly AssembunnyComputer _control;
        private readonly char _target;

        public ToggleInstruction(AssembunnyComputer control, char target)
        {
            _control = control;
            _target = target;
        }

        public override void Execute()
        {
            _control.Toggle(_target);
        }

        public override AssembunnyInstructionType Type => AssembunnyInstructionType.OneArgument;
    }
}