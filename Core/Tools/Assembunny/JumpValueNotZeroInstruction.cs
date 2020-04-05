namespace Core.Tools.Assembunny
{
    public class JumpValueNotZeroInstruction : AssembunnyInstruction
    {
        private readonly AssembunnyComputer _control;
        private readonly int _value;
        private readonly int _steps;

        public JumpValueNotZeroInstruction(AssembunnyComputer control, int value, int steps)
        {
            _control = control;
            _value = value;
            _steps = steps;
        }

        public override void Execute()
        {
            _control.JumpValueNotZero(_value, _steps);
        }

        public override AssembunnyInstructionType Type => AssembunnyInstructionType.TwoArguments;
    }
}