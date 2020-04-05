namespace Core.Tools.Assembunny
{
    public class SetValueInstruction : AssembunnyInstruction
    {
        private readonly AssembunnyComputer _control;
        private readonly int _value;
        private readonly char _target;

        public SetValueInstruction(AssembunnyComputer control, int value, char target)
        {
            _control = control;
            _value = value;
            _target = target;
        }

        public override void Execute()
        {
            _control.SetValue(_value, _target);
        }

        public override AssembunnyInstructionType Type => AssembunnyInstructionType.TwoArguments;
    }
}