namespace Core.Tools.Assembunny
{
    public class JumpSourceNotZeroInstruction : AssembunnyInstruction
    {
        private readonly AssembunnyComputer _control;
        private readonly char _source;
        private readonly int _steps;

        public JumpSourceNotZeroInstruction(AssembunnyComputer control, char source, int steps)
        {
            _control = control;
            _source = source;
            _steps = steps;
        }

        public override void Execute()
        {
            _control.JumpSourceNotZero(_source, _steps);
        }

        public override AssembunnyInstructionType Type => AssembunnyInstructionType.TwoArguments;
    }
}